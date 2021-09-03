import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Statistic } from '../models/statistic';

@Injectable({
  providedIn: 'root',
})
export class StatisticService {
  private apiUrl = 'https://localhost:5001/statistics';

  constructor(private httpClient: HttpClient) {}

  getStatistics(): Observable<Statistic[]> {
    return this.httpClient.get<Statistic[]>(this.apiUrl);
  }
}
