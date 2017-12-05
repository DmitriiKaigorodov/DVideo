import { AuthGuard } from './../auth/services/auth-guard.service';
import { VideoListComponent } from './video-list/video-list.component';
import { VideoViewerComponent } from './video-viewer/video-viewer.component';
import { CreateVideoFormComponent} from './create-video-form/create-video-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: "video/new" , component : CreateVideoFormComponent, canActivate : [AuthGuard]},
  { path: "video/edit/:id" , component : CreateVideoFormComponent, canActivate : [AuthGuard]},
  { path: "video/watch/:id" , component : VideoViewerComponent},
  { path : "videos" , component: VideoListComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VideoRoutingModule { }
