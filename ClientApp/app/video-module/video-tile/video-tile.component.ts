import { MainVideoInfo } from './../models/Video/MainVideoInfo';
import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'video-tile',
  templateUrl: './video-tile.component.html',
  styleUrls: ['./video-tile.component.css']
})
export class VideoTileComponent implements OnInit, OnChanges {

  private previewStartTime = 0;
  ngOnChanges(changes: SimpleChanges): void {

  }

  @Input() videoInfo : MainVideoInfo;
  constructor() { 


  }

  ngOnInit() {

    if(window.stop !== undefined) {
      window.stop();
    } else if(document.execCommand !== undefined) {
        document.execCommand("Stop", false);
    }
  }

  stopVideo(video : any)
  {
    video.currentTime = this.previewStartTime;
    video.pause();
  }


  onMouseOverVideo(event : any)
  {
    event.target.play();
  }


  onMouseLeaveVideo(event : any)
  {
    this.stopVideo(event.target);
  }

  onVideoTimeChanged(event : any)
  {
    var videoPlayer = event.target;
    var previewPlayTime = videoPlayer.duration*0.1 + this.previewStartTime;
    
    if(previewPlayTime < 5)
      previewPlayTime = 5;

    if(videoPlayer.currentTime  >= previewPlayTime)
    {
      this.stopVideo(videoPlayer);
    }
  }

  onMetadataLoaded(event : any)
  {
      event.target.volume = 0;
      var duration = event.target.duration;
      this.previewStartTime = Math.random() * (duration/1.5 + 1); 
      event.target.currentTime = this.previewStartTime;

  }


}
