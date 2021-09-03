import { Component, OnInit } from '@angular/core';
import { Observable, EMPTY } from 'rxjs';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';
import { faPencilAlt } from '@fortawesome/free-solid-svg-icons';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent implements OnInit {
  public users: Observable<User[]> = EMPTY;

  private userRoutePath = 'user';

  faPencilAlt = faPencilAlt;
  faTrashAlt = faTrashAlt;

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.users = this.userService.getUsers();
  }

  addUser(): void {
    this.router.navigate([this.userRoutePath]);
  }

  editUser(id?: number): void {
    console.log('edit user > ' + id);
    this.router.navigate([this.userRoutePath, id]);
  }

  deleteUser(id?: number): void {
    this.users = this.userService
      .deleteUser(id)
      .pipe(switchMap(() => this.userService.getUsers()));
  }
}
