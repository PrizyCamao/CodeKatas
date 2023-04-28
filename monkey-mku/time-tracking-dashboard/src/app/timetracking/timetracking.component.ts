import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-timetracking',
  templateUrl: './timetracking.component.html',
  styleUrls: ['./timetracking.component.scss']
})
export class TimetrackingComponent implements OnInit {
  @Input() public hours = 0;
  @Input() public total = 0;
  @Input() public timeframe = "";
  @Input() public header = "";
  @Input() public background = "";

  constructor() { }

  ngOnInit(): void {
  }

}
