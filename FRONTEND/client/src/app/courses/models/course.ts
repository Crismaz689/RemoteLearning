import { ICourseCreate } from "./course-create";

export interface ICourse extends ICourseCreate {
    id: number,
    creatorId: number,
    creatorFirstName: string,
    creatorSurname: string
}