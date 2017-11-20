import { ToastyService } from 'ng2-toasty';
import { VideosService } from './../services/videos.service';
import { Video } from './../models/Video/Video';
import { Category } from './../../category/models/Category';
import { SaveVideo } from './../models/Video/SaveVideo';
import { Thumbnail } from './../models/Thumbnail';
import { ThumbnailsService } from './../services/thumbnails.service';
import { VideoFile } from './../models/VideoFile';
import { VideoFilesService } from './../services/video-files.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'create-video-form-component',
  templateUrl: './create-video-form.component.html',
  styleUrls: ['./create-video-form.component.css']
})
export class CreateVideoFormComponent implements OnInit {


  video = new Video();

  isVideoEditing = false;
  formAppearanceInfo : any = 
  {
    formHeader : "Publish new video",
    actionButtonText : "Publish"
  }

  constructor(private videosService : VideosService, 
              private toatyService: ToastyService,
              private activatedRoute : ActivatedRoute,
              private router : Router) 
  {

    activatedRoute.params.subscribe(
      params =>
      {
        this.video.id = +params['id'];
      }
    )
    this.video.author.id = 2;
  }

  ngOnInit() {

    if(this.video.id > 0)
    {
        this.videosService.getVideo(this.video.id).subscribe( video =>
        {
          this.video = video;
          this.formAppearanceInfo = {
            formHeader: "Edit published video",
            actionButtonText: "Save changes"
          }
          this.isVideoEditing = true;
        },
       (error) => 
        {
          this.router.navigate(['home']);
        });
    }

  }

  submit()
  {
      var videoApiData : any = 
      {
        fileId: this.video.file.id,
        title: this.video.title,
        authorId: this.video.author.id,
        description: this.video.description,
        categories: this.video.categories.map(c => c.id),
      };

      if(this.video.thumbnail)
      {
        videoApiData.thumbnailId = this.video.thumbnail.id;
      }

      if(!this.isVideoEditing)
      {
        this.publishVideo(videoApiData);
      }
      else
      {
        this.updateVideo(this.video.id, videoApiData);
      }

  }

  private updateVideo(id : Number, videoApiData : any)
  {
    this.videosService.updateVideo(id, videoApiData).subscribe(
      (response) =>  {
          this.toatyService.success({
            msg: "Video updated successfully",
            title: "Success",
            theme: "bootstrap"
        });
      },
      (error) => {
        this.toatyService.error({
        msg: "Something is going wrong",
        title: "Error",
        theme: "bootstrap"
        });
      }
    );   
  }

  private publishVideo(videoApiData: any)
  {
        this.videosService.publishVideo(videoApiData).subscribe(
        (response) =>  {
            this.toatyService.success({
              msg: "Video added successfully",
              title: "Success",
              theme: "bootstrap"
          });
        },
        (error) => {
          this.toatyService.error({
          msg: "Something is going wrong",
          title: "Error",
          theme: "bootstrap"
          });
        }
      );
  }
}

