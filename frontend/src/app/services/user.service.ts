import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'https://localhost:5001/users';

  constructor(private httpClient: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.apiUrl);
  }

  getUser(id: number): Observable<User> {
    return this.httpClient.get<User>(`${this.apiUrl}/${id}`);
  }

  addUser(user: User): Observable<User> {
    return this.httpClient.post<User>(this.apiUrl, user, httpOptions);
  }

  updateUser(user: User): Observable<User> {
    return this.httpClient.put<User>(this.apiUrl, user, httpOptions);
  }

  deleteUser(id?: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiUrl}/${id}`);
  }
}
