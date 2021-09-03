import { Component, OnInit } from '@angular/core';
import { StatisticService } from 'src/app/services/statistic.service';
import { Statistic } from 'src/app/models/statistic';
import { Observable, EMPTY } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-statistics',
  templateUrl: './statistics.component.html',
  styleUrls: ['./statistics.component.scss'],
})
export class StatisticsComponent implements OnInit {
  public statistics: Observable<Statistic[]> = EMPTY;

  constructor(private statisticService: StatisticService, private router: Router) {}

  ngOnInit(): void {
    this.statistics = this.statisticService.getStatistics();
  }

  hasRoute(route: string) {
    return this.router.url === route;
  }
}
