using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.Exceptions;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Services.DataManipulation;

public class FileService : IFileService
{
    private readonly MinioClient _minioClient;
    private readonly SchoolDbContext _context;
    private const string BucketName = "profile-pictures";

    public FileService(IConfiguration configuration,
        SchoolDbContext schoolDbContext)
    {
        _context = schoolDbContext;
        var endpoint = configuration["MinIOConfig:Endpoint"];
        var accessKey = configuration["MinIOConfig:AccessKey"];
        var secretKey = configuration["MinIOConfig:SecretKey"];
        _minioClient = new MinioClient()
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey)
            // .WithSSL() Enable in production
            .Build();
    }

    public async Task<Status> UploadFileAsync(IFormFile profilePicture, int userId)
    {
        string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
        string fileExtension = Path.GetExtension(profilePicture.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension))
        {
            return Status.Fail;
        }

        const int maxFileSizeBytes = 10 * 1024 * 1024;

        if (profilePicture.Length > maxFileSizeBytes)
        {
            return Status.Fail;
        }

        var existingEntry = await _context.UserFiles.FirstOrDefaultAsync(entry => entry.UserId == userId);
        
        var data = await GetBytesTask(profilePicture);
        var contentType = $"application/{fileExtension}";
        try
        {
            if (existingEntry != null)
            {
                UploadFile(existingEntry.ObjectName, contentType, profilePicture.Length, data);
                existingEntry.UploadTimestamp = DateTime.Now;
                await _context.SaveChangesAsync();
                return Status.Success;
            }

            var objectName = Guid.NewGuid() + fileExtension;
            
            UploadFile(objectName, contentType, profilePicture.Length, data);
            
            var userFileEntry = new UserFile
            {
                UserId = userId,
                ObjectName = objectName,
                UploadTimestamp = DateTime.Now
            };

            _context.UserFiles.Add(userFileEntry); 
            await _context.SaveChangesAsync();
        }
        catch (MinioException e)
        {
            Console.WriteLine("File Upload Error: {0}", e.Message);
            return Status.Fail;
        }

        return Status.Success;
    }

    public async Task<string> GetProfilePicture(int userId)
    {
        var linkToFile = string.Empty;
        try
        {
            var fileEntry = await _context.UserFiles.FirstOrDefaultAsync(f => f.UserId == userId);

            if (fileEntry == null)
                throw new Exception();
            PresignedGetObjectArgs args = new PresignedGetObjectArgs()
                .WithBucket(BucketName)
                .WithObject(fileEntry.ObjectName)
                .WithExpiry(60 * 60 * 24);
            linkToFile = await _minioClient.PresignedGetObjectAsync(args);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred: " + e); 
        }

        return linkToFile;
    }

    private async Task<byte[]> GetBytesTask(IFormFile formFile)
    {
        using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    private async void UploadFile(string objectName, string contentType, long fileLength, byte[] data)
    {
        var beArgs = new BucketExistsArgs()
            .WithBucket(BucketName);
        bool found = await _minioClient.BucketExistsAsync(beArgs).ConfigureAwait(true);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs()
                .WithBucket(BucketName);
            await _minioClient.MakeBucketAsync(mbArgs).ConfigureAwait(false);
        }
        // Upload a file to bucket.

        var putObjectArgs = new PutObjectArgs()
            .WithBucket(BucketName)
            .WithObject(objectName)
            .WithObjectSize(fileLength)
            .WithStreamData(new MemoryStream(data))
            .WithContentType(contentType);
        await _minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);
        Console.WriteLine("Successfully uploaded " + objectName);
    }
}