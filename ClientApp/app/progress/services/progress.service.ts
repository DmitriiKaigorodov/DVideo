
import { Injectable } from '@angular/core';
import { Subject } from "rxjs/Subject";
import { BrowserXhr } from "@angular/http";


@Injectable()
export class ProgressService {

  private uploadProgress : Subject<any>;


  constructor() {  
  }

  startTracking()
  {
    this.uploadProgress = new Subject<any>();
    return this.uploadProgress;
  }

  notify(percentage : Number)
  {
    if(this.uploadProgress)
    {
        this.uploadProgress!.next(
          {
            percentage: percentage
          }
        );
    }
  }

  stopTracking()
  {
    if(this.uploadProgress)
    {
      this.uploadProgress.complete();
    }

  }

}

@Injectable()
export class ProgressBrowserXhr extends BrowserXhr {

  constructor(private progressService :ProgressService ) { 
    super();
  }

  build() : XMLHttpRequest
  {
    var xhr = super.build();

    xhr.upload.onprogress = (event : any) =>
    {
      var percentage = (event.loaded/event.total)*100;
      this.progressService.notify(percentage);
    };

    xhr.upload.onloadend = () =>
    {
      this.progressService.stopTracking();
    }
  
    return xhr;
  }
}
