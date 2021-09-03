import { Component, OnInit, Input } from '@angular/core';
import { Statistic } from 'src/app/models/statistic';

@Component({
  selector: 'app-statistic',
  templateUrl: './statistic.component.html',
  styleUrls: ['./statistic.component.scss'],
})
export class StatisticComponent implements OnInit {
  @Input() statistic!: Statistic;

  constructor() {}

  ngOnInit(): void {}
}
