import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, map, switchMap } from 'rxjs/operators';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent implements OnInit, OnDestroy {
  public user: User = {
    id: undefined,
    firstName: '',
    lastName: '',
    age: 0,
    favoriteColor: '',
  };

  public userForm: FormGroup = this.formBuilder.group({
    id: null,
    firstName: [
      null,
      [Validators.required, Validators.minLength(3), Validators.maxLength(50)],
    ],
    lastName: [
      null,
      [Validators.required, Validators.minLength(3), Validators.maxLength(50)],
    ],
    age: [null, [Validators.required, Validators.min(1), Validators.max(255)]],
    favoriteColor: [
      null,
      [Validators.required, Validators.minLength(3), Validators.maxLength(50)],
    ],
  });

  public submitted: boolean = false;

  private subscriptions: Subscription = new Subscription();

  constructor(
    private actRoute: ActivatedRoute,
    private userService: UserService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subscriptions.add(
      this.actRoute.paramMap
        .pipe(
          map((params) => params.get('id')),
          filter((id) => id !== null),
          switchMap((id) => {
            let idNumber = parseInt(id as string);
            return this.userService.getUser(idNumber);
          })
        )
        .subscribe((user) => {
          this.user = user;
          this.userForm.patchValue({
            ...this.user,
          });
        })
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  get fields() {
    return this.userForm.controls;
  }

  onSubmit() {
    this.submitted = true;

    if (!this.userForm.valid) {
      return;
    }

    if (this.user.id) {
      this.subscriptions.add(
        this.userService
          .updateUser(this.userForm.value)
          .subscribe(() => this.router.navigate(['/']))
      );
    } else {
      this.subscriptions.add(
        this.userService
          .addUser(this.userForm.value)
          .subscribe(() => this.router.navigate(['/']))
      );
    }
  }
}
