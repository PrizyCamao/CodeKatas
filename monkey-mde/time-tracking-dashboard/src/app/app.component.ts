import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public cards: ICard[] = [
    {
      bgColor: '#ff8b64',
      title: 'Work',
      hours: '32',
      lastWeekHours: '36',
      icon: 'work'
    },
    {
      bgColor: '#56c2e6',
      title: 'Play',
      hours: '10',
      lastWeekHours: '8',
      icon: 'play'
    },
    {
      bgColor: '#ff5e7d',
      title: 'Study',
      hours: '4',
      lastWeekHours: '7',
      icon: 'study'
    },
    {
      bgColor: '#4bcf83',
      title: 'Exercise',
      hours: '4',
      lastWeekHours: '5',
      icon: 'exercise'
    },
    {
      bgColor: '#7235d1',
      title: 'Social',
      hours: '5',
      lastWeekHours: '10',
      icon: 'social'
    },
    {
      bgColor: '#f1c65a',
      title: 'Self Care',
      hours: '2',
      lastWeekHours: '2',
      icon: 'self-care'
    },
  ]
}

interface ICard {
  bgColor: string;
  title: string;
  hours: string;
  lastWeekHours: string;
  icon: string;
}
