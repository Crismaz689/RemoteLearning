import { ITextQuestionForStudent } from "../text-questions/text-question-for-student";

export interface ITestForStudent {
    id: number;
    textQuestions: Array<ITextQuestionForStudent>;
}