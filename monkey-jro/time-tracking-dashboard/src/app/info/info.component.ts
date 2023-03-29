import { Component, OnInit } from '@angular/core';
import { InfoServiceService } from '../info-service.service';
import { InfoData } from '../info.interface';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent implements OnInit {
  data: InfoData[] = []
  
  constructor(private infoServiceService:InfoServiceService) {}
  
  ngOnInit() {
      this.data = this.infoServiceService.getData()
  }

}
