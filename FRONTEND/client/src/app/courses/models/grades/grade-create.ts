export interface IGradeCreate {
    value: number;
    title: string;
    description?: string;
    courseId: number;
    userId: number;
    categoryId: number;
}