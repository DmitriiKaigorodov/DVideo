import { PagingComponent } from './paging/paging.component';
import { TitlePipe } from './title-pipe/title.pipe';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ToastyModule } from 'ng2-toasty';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProgressBarComponent } from "./ProgressBar/progressbar.component";
import { Ng2CompleterModule } from "ng2-completer";
import { LikesPanelComponent } from './likes-panel/likes-panel.component';
import { NouisliderModule } from 'ng2-nouislider/src/nouislider';
import { LoaderComponent } from './loader/loader.component'
import { objectToQueryString } from './utils';

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    ToastyModule.forRoot(),
    Ng2CompleterModule,
    FormsModule
  ],
  exports: [ ProgressBarComponent, ToastyModule, Ng2CompleterModule,
     LikesPanelComponent, NouisliderModule, TitlePipe, PagingComponent, LoaderComponent],
  declarations: [ProgressBarComponent, LikesPanelComponent,
     TitlePipe, PagingComponent, LoaderComponent ]
})
export class SharedModule { }
