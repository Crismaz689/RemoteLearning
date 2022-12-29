import { Input } from '@angular/core';
import { Component } from '@angular/core';
import { IFile } from '../../models/files/file';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent {

  @Input()
  files: IFile[] = [];

  constructor() { }
}
