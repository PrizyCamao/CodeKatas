import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TimetrackingComponent } from './timetracking/timetracking.component';
import { SummaryComponent } from './summary/summary.component';

@NgModule({
  declarations: [
    AppComponent,
    TimetrackingComponent,
    SummaryComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
