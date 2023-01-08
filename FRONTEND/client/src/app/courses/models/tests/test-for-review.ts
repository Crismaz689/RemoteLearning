import { ITextQuestionAnswer } from "../text-questions/text-question-answer";

export interface ITestForReview {
    testId: number;
    answers: Array<ITextQuestionAnswer>;
}