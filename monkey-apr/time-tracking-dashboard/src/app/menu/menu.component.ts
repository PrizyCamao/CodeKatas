import { Component, Input } from '@angular/core';
import { Timeframe } from '../timeframe.enum';
import { TimeframeService } from '../timeframe.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {
  @Input() public name!: string;

  public timeframe = Timeframe;
  public currentTimeframe: Timeframe = Timeframe.Daily;

  constructor(private readonly _timeframeService: TimeframeService) {}

  public setTimeframe(timeframe: Timeframe): void {
    this._timeframeService.set(timeframe);
    this.currentTimeframe = timeframe;
  }
}
