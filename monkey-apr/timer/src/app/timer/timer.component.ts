import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Observable, Subject, filter, interval, map, pairwise, shareReplay, startWith, takeUntil, tap } from 'rxjs';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent implements OnInit {
  private stop$ = new Subject<void>();
  private paused = false;

  public timer$ = interval(1000)
    .pipe(
      takeUntil(this.stop$),
      pairwise(),
      filter(() => !this.paused),
      map(([prevTimer,]) =>  prevTimer + 2000),
      shareReplay(1)
    );

  public ngOnInit(): void {

  }

  public startOrPause(): void {
    this.paused = !this.paused;
  }

  public stop(): void {
    this.stop$.complete();
  }
}
