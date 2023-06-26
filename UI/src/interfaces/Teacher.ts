export interface Teacher extends User {
  attributes: {
    Faculty:string,
    Specialty:string,
    Course:string
  }
}