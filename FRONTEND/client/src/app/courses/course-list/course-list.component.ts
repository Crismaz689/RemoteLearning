import { Component, Input } from '@angular/core';
import { ICourse } from '../models/course';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent {

  @Input()
  courses!: ICourse[];

  constructor() { }

}
