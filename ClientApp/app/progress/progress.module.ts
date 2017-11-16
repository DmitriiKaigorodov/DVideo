import { ProgressBrowserXhr, ProgressService } from './services/progress.service';
import { BrowserXhr } from '@angular/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers :
  [
    { provide : BrowserXhr, useClass: ProgressBrowserXhr},
    ProgressService
  ]
})
export class ProgressModule { }
