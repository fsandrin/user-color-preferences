import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { UserComponent } from './components/user/user.component';
import { UsersComponent } from './components/users/users.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'statistics', component: StatisticsComponent },
  { path: 'users', component: UsersComponent },
  { path: 'user/:id', component: UserComponent },
  { path: 'user', component: UserComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
