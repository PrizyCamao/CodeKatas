import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-info-card',
  templateUrl: './info-card.component.html',
  styleUrls: ['./info-card.component.scss']
})
export class InfoCardComponent {
  @Input() public bgColor!: string;
  @Input() public title!: string;
  @Input() public hours!: string;
  @Input() public lastWeekHours!: string;
  @Input() public icon!: string;
}
