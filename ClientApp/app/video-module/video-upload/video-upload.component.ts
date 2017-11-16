import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ToastyService } from 'ng2-toasty';
import { ProgressService } from './../../progress/services/progress.service';
import { VideoFile } from './../models/VideoFile';
import { Component, OnInit, Output, EventEmitter, forwardRef, Input } from '@angular/core';
import { VideoFilesService } from "../services/video-files.service";


const VIDEO_UPLOAD_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => VideoUploadComponent),
  multi: true
};


@Component({
  selector: 'video-upload',
  templateUrl: './video-upload.component.html',
  styleUrls: ['./video-upload.component.css'],
  providers: [VIDEO_UPLOAD_ACCESSOR]
})
export class VideoUploadComponent implements OnInit, ControlValueAccessor {

  @Input() enabled = true;

  videoFile : VideoFile;
  progressPercentage : Number;
  progressBarVisible : boolean
  onTouched : () => void = () => {};
  onChange : (_ : any)  => {};

  constructor(private videoFilesService : VideoFilesService,
     private progressService : ProgressService, private toastyService : ToastyService) 
  {

  }

  ngOnInit() {
  }

  writeValue(obj: any): void {
   
    if(obj)
    {
      this.videoFile = obj;
    }
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  uploadVideoFile(fileData : FormData)
  {
      this.videoFilesService.uploadVideoFile(fileData).subscribe(
        (response) => 
        {
          console.log("RESPONSE");
          if(response.ok)
          {
              this.videoFile = response.json()
              this.onChange(this.videoFile);
          }
          else
          {
            console.log("TEXT", response.text());
          }

        }, 
        (errorResponse) =>
        {
          this.toastyService.error( {

            title : 'Upload error',
            msg : errorResponse.text(),
            theme : 'bootstrap'
          });
        } 
      );
  }

  onVideoSelected(event : any)
  {
    this.onTouched();
    if(event.target.files.length > 0)
    {
      this.progressService.startTracking().subscribe( progress =>
        {
          console.log(progress);
          this.progressBarVisible = true;
          this.progressPercentage = progress.percentage;
  
        } );

        let file = event.target.files[0]
        let fileData  = new FormData();
        fileData.append('file', file);

        
        if(this.videoFile && this.videoFile.url && this.videoFile.url.length > 0)
        {
          this.videoFilesService.deleteVideoFile(this.videoFile.id).subscribe(
            response =>
            {
              this.uploadVideoFile(fileData);
            }
          )
        }
        else
        {
          this.uploadVideoFile(fileData);
        }

    }
    else
    {

        this.videoFilesService.deleteVideoFile(this.videoFile.id).subscribe(
          response => 
          {
              this.videoFile = new VideoFile();
              this.onChange(null);
          }
        )
    }

  }

}
