import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ToastyService } from 'ng2-toasty';
import { ProgressService } from './../../progress/services/progress.service';
import { ThumbnailsService } from './../services/thumbnails.service';
import { Thumbnail } from './../models/Thumbnail';
import { Component, OnInit, Output, EventEmitter, forwardRef } from '@angular/core';

const THUMBNAIL_UPLOAD_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => ThumbnailUploadComponent),
  multi: true
};

@Component({
  selector: 'thumbnail-upload',
  templateUrl: './thumbnail-upload.component.html',
  styleUrls: ['./thumbnail-upload.component.css'],
  providers: [THUMBNAIL_UPLOAD_ACCESSOR]
})
export class ThumbnailUploadComponent implements OnInit , ControlValueAccessor{


  thumbnail : Thumbnail;
  progressPercentage : Number;

  onTouched : () => void = () => {};
  onChange : (_ : any)  => {};

  constructor(private thumbnailsService : ThumbnailsService,
  private progressService : ProgressService, private toastyService : ToastyService) 
  {

      
  }

  writeValue(obj: Thumbnail): void {
    if(obj)
    {
      this.thumbnail = obj;
    }
  }
  registerOnChange(fn: any): void {
   this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  uploadThumbnailFile(fileData : FormData)
  {
      this.thumbnailsService.uploadThumbnail(fileData).subscribe(
        (response )=> 
        {
          this.thumbnail = response.json()
          this.onChange(this.thumbnail);
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

  onThumbnailSelected(event : any)
  {
    this.onTouched();
    if(event.target.files.length > 0)
      {
        this.progressService.startTracking().subscribe( progress =>
          {
            console.log(progress);
            this.progressPercentage = progress.percentage;
    
          } );

          
          let file = event.target.files[0]
          let fileData  = new FormData();
          fileData.append('file', file);
          
          if(this.thumbnail && this.thumbnail.url && this.thumbnail.url.length > 0)
          {
            this.thumbnailsService.deleteThumbnail(this.thumbnail.id).subscribe(
              response =>
              {
                this.uploadThumbnailFile(fileData);
              }
            )
          }
          else
          {
            this.uploadThumbnailFile(fileData);
          }
  
      }
      else
      {
  
          this.thumbnailsService.deleteThumbnail(this.thumbnail.id).subscribe(
            response => 
            {
              this.thumbnail = new Thumbnail();
              this.onChange(null);
            }
          )
      }
  }

  ngOnInit() {
  }

}
