import { IFile } from "../files/file";

export interface ISection {
    id: number,
    name: string,
    description: string,
    date: Date,
    files: Array<IFile>
}