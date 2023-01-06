import { Input } from '@angular/core';
import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IUser } from 'src/app/account/models/User';
import { Role } from 'src/app/_helpers/role.enum';
import { FileService } from 'src/app/_services/file.service';
import { IFile } from '../../models/files/file';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent {

  @Input()
  files: IFile[] = [];

  @Input()
  currentUser: IUser;

  @Input()
  creatorId: number;

  @Input()
  userRole = Role.Undefined;

  role = Role;

  constructor(private fileService: FileService,
    private snackBar: MatSnackBar) { }

  deleteFile(fileId: number): void {
    this.fileService.deleteFile(fileId).subscribe((isDeleted) => {
      if (isDeleted) {
        this.snackBar.open("Plik usunięty.", '', { panelClass: ['text-white', 'bg-success'] });
        const fileIndex = this.files.findIndex((file) => file.id == fileId);
        this.files.splice(fileIndex, 1);
      }
      else {
        this.snackBar.open("Nie udało się usunąć pliku.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Nie udało się usunąć pliku.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  downloadFile(fileId: number): void {
    this.fileService.getFile(fileId).subscribe((file) => {
      const link = document.createElement("a");
      link.href = file.data;
      link.download = file.fullName;
      link.click();
    },
    (err) => {
      this.snackBar.open("Nie udało się pobrać pliku.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
