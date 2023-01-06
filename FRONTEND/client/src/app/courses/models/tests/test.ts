import { ITextQuestion } from "../text-questions/text-question";

export interface ITest {
    id: number;
    name: string;
    points: number;
    timeMinutes: number;
    textQuestions: Array<ITextQuestion>;
    isCollapsed: boolean;
}