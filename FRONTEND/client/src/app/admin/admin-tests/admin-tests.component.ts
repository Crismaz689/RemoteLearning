import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ITestAdmin } from 'src/app/courses/models/tests/test-admin';
import { TestService } from 'src/app/_services/test.service';

@Component({
  selector: 'app-admin-tests',
  templateUrl: './admin-tests.component.html',
  styleUrls: ['./admin-tests.component.scss']
})
export class AdminTestsComponent implements OnInit {

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  tests: ITestAdmin[] = [];

  displayedColumns: string[] = ['delete', 'testName', 'courseName', 'points', 'timeMinutes'];

  dataSource: MatTableDataSource<ITestAdmin>;

  isSpinning: boolean = true;

  constructor(private testService: TestService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.testService.getAdminAllTests().subscribe((tests) => {
      this.tests = tests;
      this.paginate();
      this.isSpinning = false;
    });
  }

  paginate(): void {
    this.dataSource = new MatTableDataSource(this.tests);
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

  deleteTest(testId: number): void {
    this.testService.deleteTest(testId).subscribe((isDeleted) => {
      if (isDeleted) {
        const testIndex = this.tests.findIndex((t) => t.id === testId);
        this.tests.splice(testIndex, 1);
        this.paginate();
        this.snackBar.open("Test usunięty.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Błąd podczas usuwania testu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas usuwania testu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
