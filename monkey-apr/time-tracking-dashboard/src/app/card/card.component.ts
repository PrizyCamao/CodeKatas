import { Component, Input, OnInit } from '@angular/core';
import { Timeframe } from '../timeframe.enum';
import { TimeframeService } from '../timeframe.service';
import { Card, CardDetail } from './card.model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardComponent implements OnInit {
  @Input() public card!: Card;

  public currentTimeFrame!: Timeframe;

  constructor(private readonly _timeframeService: TimeframeService) { }

  public ngOnInit(): void {
    this.currentTimeFrame = this._timeframeService.get();
  }

  public getCurrentValue(): number {
    return this.getTimeframe().current;
  }

  public getPreviousValue(): number {
    return this.getTimeframe().previous;
  }

  public getTimeframe(): CardDetail {
    switch (this.currentTimeFrame) {
      case Timeframe.Daily:
        return this.card.timeframes.daily;
      case Timeframe.Weekly:
        return this.card.timeframes.weekly;
      case Timeframe.Monthly:
        return this.card.timeframes.monthly;
    }
  }
}
