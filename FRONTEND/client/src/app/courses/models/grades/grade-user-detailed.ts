import { IUserGrade } from "./grade-user";

export interface IUserGradeDetailed extends IUserGrade {
    firstName: string;
    surname: string;
}