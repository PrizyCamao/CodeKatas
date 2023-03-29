import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Timeframe } from './timeframe.enum';

@Injectable({
  providedIn: 'root'
})
export class TimeframeService {
  private _timeFrame$ = new BehaviorSubject<Timeframe>(Timeframe.Daily);

  public set(timeframe: Timeframe): void {
    this._timeFrame$.next(timeframe);
  }

  public get$(): Observable<Timeframe> {
    return this._timeFrame$.asObservable();
  }

  public get(): Timeframe {
    return this._timeFrame$.value;
  }
}
