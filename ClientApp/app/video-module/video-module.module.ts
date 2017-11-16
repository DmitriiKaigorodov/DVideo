import { CategoriesService } from './services/categories.service';
import { AppModule } from './../app.module.browser';
import { VideosService } from './services/videos.service';

import { BrowserXhr } from '@angular/http';
import { ProgressService, ProgressBrowserXhr } from './../progress/services/progress.service';
import { ProgressModule } from './../progress/progress.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { TagInputModule } from 'ng2-tag-input/dist/modules';


import { FormsModule } from '@angular/forms';
import { ThumbnailsService } from './services/thumbnails.service';
import { VideoFilesService } from './services/video-files.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VideoRoutingModule } from './video-module-routing.module';
import { CreateVideoFormComponent } from './create-video-form/create-video-form.component';
import { VideoPreviewComponent } from './video-preview-component/video-preview/video-preview.component';
import { VideoUploadComponent } from './video-upload/video-upload.component';
import { ThumbnailUploadComponent } from './thumbnail-upload/thumbnail-upload.component';
import { SharedModule } from "../shared/shared.module";
import { ToastyService, ToastyConfig } from "ng2-toasty";
import { CompleterService } from "ng2-completer";
import { CategoriesSelectorComponent } from './categories-selector/categories-selector.component';
import { VideoViewerComponent } from './video-viewer/video-viewer.component';
import { CategoriesViewerComponent } from './categories-viewer/categories-viewer.component';
import { DescriptionComponent } from './description/description.component';
import { VideoListComponent } from './video-list/video-list.component';
import { VideoTileComponent } from './video-tile/video-tile.component';
import { CategorySwitcherComponent } from './category-switcher/category-switcher.component';
import { VideoLengthFilterComponent } from './video-length-filter/video-length-filter.component';

@NgModule({
  imports: [
    CommonModule,
    VideoRoutingModule,
    FormsModule,
    ProgressModule,
    SharedModule
  ],
  declarations: 
  [ CreateVideoFormComponent, VideoPreviewComponent, VideoUploadComponent,
    ThumbnailUploadComponent, CategoriesSelectorComponent, VideoViewerComponent,
    CategoriesViewerComponent,DescriptionComponent, VideoListComponent, VideoTileComponent
  , CategorySwitcherComponent, VideoLengthFilterComponent],
  providers: [
          VideoFilesService, ThumbnailsService, 
        { provide: BrowserXhr, useClass: ProgressBrowserXhr},
        ProgressService, ToastyService,
        ToastyConfig, CompleterService, VideosService, CategoriesService
     ]
})
export class VideoModule {

  
 }
