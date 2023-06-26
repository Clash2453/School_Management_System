export interface Admin extends User {
    attributes: {
      Faculty:string,
      Specialty:string,
      Course:string
    }
  }