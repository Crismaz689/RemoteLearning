import { ICourseCreate } from "./course-create";
import { IGrade } from "./grades/grade";
import { ISection } from "./sections/section";
import { ITest } from "./tests/test";

export interface ICourseAllData extends ICourseCreate {
    id: number,
    creatorId: number
    sections: Array<ISection>
    tests: Array<ITest>
    grades: Array<IGrade>
}