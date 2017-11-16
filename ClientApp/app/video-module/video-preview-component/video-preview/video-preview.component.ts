import { VideoFilesService } from './../../services/video-files.service';
import { VideoFile } from './../../models/VideoFile';
import { Component, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';

@Component({
  selector: 'video-preview',
  templateUrl: './video-preview.component.html',
  styleUrls: ['./video-preview.component.css']
})
export class VideoPreviewComponent implements OnInit, OnChanges {

  @Input() videoFile : VideoFile;
  constructor(private videoFileService : VideoFilesService) { }

  ngOnInit() {
  }


  ngOnChanges(changes: SimpleChanges) {
    console.log(changes);
  }

  onMetadataLoaded(event: any)
  {
    console.log(event.target.duration);

    var duration = Math.round(event.target.duration);

    if(this.videoFile)
    {
      this.videoFileService.updateVideoFile(this.videoFile.id, {
        durationInSeconds : duration
      }).subscribe( response => console.log(response))
    }
  }

}
