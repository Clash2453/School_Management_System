import { type InternetError } from '@/interfaces/InternetError'
import { AxiosError } from 'axios';

export class ErrorHandlingService {
    public isError = (err: unknown): err is Error => err instanceof Error;
    public isAxiosError = (err: unknown):err is AxiosError => err instanceof AxiosError;

public ensureError(e:unknown) : Error | InternetError{
  if(this.isAxiosError(e)){
    const internetError:InternetError = {
      cause: e.response?.status,
      name: e.name,
      message: e.message
    }
    return internetError
  }

  if(this.isError(e)){
    const internetError:InternetError = {
      stack: e.stack,
      name: e.name,
      message: e.message
    }
    return internetError
  }

  let stringified =  '[Unable to stringify the thrown value]'

  try {
    stringified = JSON.stringify(e)
  }
  catch { 
    return new Error('Failed to stringify error')
   }

  const error:InternetError = new Error(`Thrown after stringify ${stringified}`)
  return error
}
}