import { Input } from '@angular/core';
import { Component } from '@angular/core';
import { ISection } from '../models/sections/section';

@Component({
  selector: 'app-sections',
  templateUrl: './sections.component.html',
  styleUrls: ['./sections.component.scss']
})
export class SectionsComponent {

  @Input()
  sections: ISection[] = [];

  @Input()
  courseId!: number;

  constructor() { }

}
