import { CategoriesService } from './../../category/services/categories.service';
import { Category } from './../../category/models/Category';
import { VideoQuery } from './../models/Video/VideoQuery';
import { MainVideoInfo } from './../models/Video/MainVideoInfo';
import { VideosService } from './../services/videos.service';
import { Video } from './../models/Video/Video';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-video-list',
  templateUrl: './video-list.component.html',
  styleUrls: ['./video-list.component.css']
})
export class VideoListComponent implements OnInit {

  videosInfo : MainVideoInfo[] = []
  categories : Category[] = [];
  totalItems : number;
  filterButtonText = "Show video filters";
  showFilters = false;
  query = new VideoQuery();

  constructor(private videosService : VideosService,
              private categoriesService : CategoriesService)
  {
    
  }

  retrieveVideos()
  {
    this.videosService.getAllVideos(this.query).subscribe( result =>
      {
        this.totalItems = result.totalItems;
        this.videosInfo = result.entries;
      }
    );
  }


  ngOnInit() {

    this.retrieveVideos();
    this.categoriesService.getAllCategories().subscribe(
        categories => this.categories = categories
    );
  }

  toggleFilters()
  {
    this.showFilters = !this.showFilters;
    this.filterButtonText = !this.showFilters ? "Show video filters" 
    : "Hide video filters";

  }

  categoryChanged(category : any)
  {
    this.query.categoryName = category ? category.name : "";
    this.retrieveVideos();
  }

  lengthChanged(event : any)
  {
    this.query.maxLength = event.maxLength;
    this.query.minLength = event.minLength;

    this.retrieveVideos();
  }

  onPageChanged(page : number)
  {
    this.query.page = page;
    this.retrieveVideos();
  }

}
