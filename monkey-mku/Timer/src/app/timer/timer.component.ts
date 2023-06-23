import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, Subject, interval, takeUntil, takeWhile } from 'rxjs';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.css']
})
export class TimerComponent implements OnInit {
  private _start$ = new Subject<void>();
  private _stop$ = new Subject<void>();

  public time$ = new BehaviorSubject<Date>(new Date(0, 0, 1, 0, 1));

  public ngOnInit(): void {
  }

  public start(): void {
    interval(1000).pipe(
      takeUntil(this._stop$),
      takeWhile(() => {
        var running = this.time$.value.getHours() !== 0 || this.time$.value.getMinutes() !== 0 || this.time$.value.getSeconds() !== 0;
        if (!running) {
          alert("Ringadingding!");
        }
        return running;
      })
    ).subscribe({
      next: (i) => this.time$.next(new Date(this.time$.value.getTime() - 1000)),
      complete: () => {
        this.time$.next(new Date(0, 0, 1, 0, 0));
      }
    });
  }

  public stop(): void {
    this._stop$.next();
  }

  public add(seconds: number): void {
    this.time$.next(new Date(this.time$.value.getTime() + seconds * 1000));
  }
}
