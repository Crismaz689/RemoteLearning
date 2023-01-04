import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/_services/account.service';
import { IAccount } from '../../models/account';

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.scss']
})
export class AccountsListComponent implements OnInit {

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  @Input()
  accounts$: Observable<IAccount[]> | undefined;

  accounts: IAccount[] = [];

  displayedColumns: string[] = ['delete', 'firstName', 'surname', 'pesel', 'email'];

  dataSource: MatTableDataSource<IAccount>;

  isSpinning: boolean = true;

  constructor(private accountService: AccountService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.accounts$.subscribe((accounts) => {
      this.accounts = accounts;
      this.paginate();
      this.isSpinning = false;
    });
  }

  paginate(): void {
    this.dataSource = new MatTableDataSource(this.accounts);
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

  deleteAccount(accountId: number): void {
    this.accountService.deleteAccount(accountId).subscribe((isDeleted) => {
      if (isDeleted) {
        const accountIndex = this.accounts.findIndex((acc) => acc.id === accountId);
        this.accounts.splice(accountIndex, 1);
        this.paginate();
        this.snackBar.open("Konto usunięte.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Błąd podczas usuwania konta.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas usuwania konta.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

}
