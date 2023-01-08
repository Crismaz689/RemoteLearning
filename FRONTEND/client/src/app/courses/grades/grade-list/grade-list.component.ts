import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { GradeService } from 'src/app/_services/grade.service';
import { IGrade } from '../../models/grades/grade';

@Component({
  selector: 'app-grade-list',
  templateUrl: './grade-list.component.html',
  styleUrls: ['./grade-list.component.scss']
})
export class GradeListComponent implements OnInit {

  @Input()
  grades: IGrade[] = [];

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  displayedColumns: string[] = ['delete', 'update', 'value', 'title', 'description', 'categoryName'];

  dataSource: MatTableDataSource<IGrade>;

  isSpinning: boolean = true;

  constructor(private gradeService: GradeService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
      this.paginate();
  }

  paginate(): void {
    this.dataSource = new MatTableDataSource(this.grades);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteGrade(gradeId: number): void {
    this.gradeService.deleteGrade(gradeId).subscribe((isDeleted) => {
      if (isDeleted) {
        const gradeIndex = this.grades.findIndex((g) => g.id === gradeId);
        this.grades.splice(gradeIndex, 1);
        this.paginate();
        this.snackBar.open("Ocena usunięta.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Błąd podczas usuwania oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas usuwania oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  updateGrade(grade: IGrade): void {
    
  }

}
