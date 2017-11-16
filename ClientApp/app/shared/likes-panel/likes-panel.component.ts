import { Video } from './../../video-module/models/Video/Video';
import { Component, OnInit, Input } from '@angular/core';

export const  LIKED = 1;
export const DISLIKED = 2;
export const  NEUTRAL = 3;

@Component({
  selector: 'likes-panel',
  templateUrl: './likes-panel.component.html',
  styleUrls: ['./likes-panel.component.css']
})
export class LikesPanelComponent implements OnInit {



  state = NEUTRAL;
  @Input() video : Video = new Video();

  constructor() { }

  ngOnInit() {
    
  }

  like()
  {
    this.state = this.state == LIKED ? NEUTRAL : LIKED;
  }

  dislike()
  {
    this.state = this.state == DISLIKED ? NEUTRAL : DISLIKED;
  }

}
