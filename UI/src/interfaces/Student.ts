export interface Student extends User {
    attributes: {
        Faculty: string;
        Specialty: string;
        Course: string;
      };
}