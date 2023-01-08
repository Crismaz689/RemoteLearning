import { ITextQuestion } from "../text-questions/text-question";
import { ITestResult } from "./test-result";

export interface ITest {
    id: number;
    name: string;
    points: number;
    timeMinutes: number;
    textQuestions: Array<ITextQuestion>;
    testResults: Array<ITestResult>;
    isCollapsed: boolean;
}