import { Component, OnInit } from '@angular/core';
import { RoleMapper } from '../_helpers/role-mapper';
import { Role } from '../_helpers/role.enum';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent implements OnInit {
  role = Role;

  userRole: Role = Role.Undefined;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.userRole = RoleMapper.RoleMapping(this.accountService.getRole());
  }

}
