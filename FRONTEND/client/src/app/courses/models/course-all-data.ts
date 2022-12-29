import { ICourseCreate } from "./course-create";
import { ISection } from "./sections/section";

export interface ICourseAllData extends ICourseCreate {
    id: number,
    creatorId: number
    sections: Array<ISection>
}