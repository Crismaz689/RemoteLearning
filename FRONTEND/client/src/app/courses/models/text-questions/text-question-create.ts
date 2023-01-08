export interface ITextQuestionCreate {
    title: string;
    correctAnswer: string;
    wrongAnswerA: string;
    wrongAnswerB: string;
    wrongAnswerC: string;
    points: number;
    timeMinutes: number;
    testId: number;
}