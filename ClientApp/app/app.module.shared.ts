import { CategoryRoutingModule } from './category/category-module-routing.module';
import { ToastyModule, ToastyConfig,ToastyService } from 'ng2-toasty';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VideoRoutingModule } from './video-module/video-module-routing.module';
import { VideoModule } from './video-module/video-module.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

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
        VideoRoutingModule,
        CategoryRoutingModule,
        ToastyModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]),       
    ]
})
export class AppModuleShared {
}
