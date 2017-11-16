import { Video } from './../models/Video/Video';
import { ActivatedRoute, Router } from '@angular/router';
import { VideosService } from './../services/videos.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-video-viewer',
  templateUrl: './video-viewer.component.html',
  styleUrls: ['./video-viewer.component.css']
})
export class VideoViewerComponent implements OnInit {

  private video : Video = new Video();

  constructor(private videoService : VideosService, 
              private activatedRoute : ActivatedRoute,
              private title : Title,
              private router : Router)
     { 
        activatedRoute.params.subscribe( params =>
        {
            this.video.id = +params['id'];
        });

        
     }

  ngOnInit() {

    if(this.video.id > 0)
    {
      this.videoService.getVideo(this.video.id).subscribe( video =>
      {
          this.video = video;
          this.title.setTitle("DVideo · " + this.video.title);
      },
    error => 
      {
        this.router.navigate(['home']);
      });
    }
    else
    {
      this.router.navigate(['home']);
    }
  }

}
