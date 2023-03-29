import { Component, OnInit } from '@angular/core';
import { Card } from './card/card.model';
import { data } from "../assets/data";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'time-tracking-dashboard';
  public dataIntern!: Card[];

  public ngOnInit(): void {
    this.dataIntern = data;
  }
}
