import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public items = [{
    header: "Work",
    hours: 5,
    total: 8,
    background: "#FF8B64"
  }, {
    header: "Play",
    hours: 6,
    total: 10,
    background: "#56C2E6"
  }, {
    header: "Play",
    hours: 6,
    total: 10,
    background: "#FF5E7D"
  }, {
    header: "Play",
    hours: 6,
    total: 10,
    background: "#4CCF81"
  }, {
    header: "Play",
    hours: 6,
    total: 10,
    background: "#7235D1"
  }, {
    header: "Play",
    hours: 6,
    total: 10,
    background: "#F1C75B"
  }];
  public timeframe = "Yesterday";
}
