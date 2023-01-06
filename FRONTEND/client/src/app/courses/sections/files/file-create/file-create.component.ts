import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ISection } from 'src/app/courses/models/sections/section';
import { FileService } from 'src/app/_services/file.service';

@Component({
  selector: 'app-file-create',
  templateUrl: './file-create.component.html',
  styleUrls: ['./file-create.component.scss']
})
export class FileCreateComponent {

  public selectedSection: ISection;

  fileUploaded: boolean = false;

  description: string = "";

  file: any = undefined;

  constructor(private snackBar: MatSnackBar,
    private fileService: FileService) { }

  selectFile(file: any): void {
    this.file = file?.target?.files[0];
  }

  getFileName(): string {
    return this.file ? this.file?.name : "";
  }

  uploadFile(): void {
    const formData = new FormData();
    formData.append('File', this.file);
    formData.append('SectionId', this.selectedSection.id.toString());
    formData.append('Description', this.description);

    this.fileService.createFile(formData).subscribe((file) => {
      if (file.length !== 0) {
        this.snackBar.open("Plik wgrany.", '', { panelClass: ['text-white', 'bg-success'] });
        this.fileUploaded = true;
      }
      else {
        this.snackBar.open("Nie udało się wgrać pliku.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Nie udało się wgrać pliku.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
