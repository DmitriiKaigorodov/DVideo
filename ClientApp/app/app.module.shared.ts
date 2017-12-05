import { AuthConfig } from 'angular2-jwt';
import { UsersModule } from './users/users.module';
import { UsersRoutingModule } from './users/users-routing.module';
import { CategoryRoutingModule } from './category/category-module-routing.module';
import { ToastyModule, ToastyConfig,ToastyService } from 'ng2-toasty';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VideoRoutingModule } from './video-module/video-module-routing.module';
import { VideoModule } from './video-module/video-module.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, CanActivate } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { AuthGuard } from './auth/services/auth-guard.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent        
    ],
    providers :[ToastyConfig, ToastyService],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        VideoModule,
        UsersModule,
        VideoRoutingModule,
        CategoryRoutingModule,
        UsersRoutingModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent},
            { path: 'counter', component: CounterComponent , canActivate : [AuthGuard]},
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]),       
    ]
})
export class AppModuleShared {
}
