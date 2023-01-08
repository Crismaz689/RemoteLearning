import { AfterContentInit, Component, Input, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ITestResult } from '../../models/tests/test-result';

@Component({
  selector: 'app-tests-results',
  templateUrl: './tests-results.component.html',
  styleUrls: ['./tests-results.component.scss']
})
export class TestsResultsComponent implements AfterContentInit {

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  displayedColumns: string[] = ['firstName', 'surname', 'points', 'finishDate'];

  dataSource: MatTableDataSource<ITestResult>;

  @Input()
  results: ITestResult[] = [];

  isCollapsed: boolean = false;
  
  constructor() { }

  showResults(): void {
    this.isCollapsed = !this.isCollapsed;
  }

  ngAfterContentInit(): void {
    this.paginate();
  }

  paginate(): void {
    this.dataSource = new MatTableDataSource(this.results);
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

}
