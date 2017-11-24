import { VideoQuery } from './../models/Video/VideoQuery';
import { Video } from './../models/Video/Video';
import { ProgressService } from './../../progress/services/progress.service';
import { Injectable,InjectionToken, Inject } from '@angular/core';
import { Http, HttpModule, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { objectToQueryString } from '../../shared/utils';


@Injectable()
export class VideosService {


    private videoEndPoint : string = "api/videos/";
    private serverUrl : string;
    constructor(private http: Http) { 

       // this.serverUrl = originUrl;

        console.log(this.serverUrl)
    }

    publishVideo(videoData : any)
    {
        return this.http.post(this.videoEndPoint, videoData);
    }

    updateVideo(id : Number, videoData : any)
    {
        return this.http.put(this.videoEndPoint + id, videoData);
    }

    getVideo(id : Number)
    {
        return this.http.get(this.videoEndPoint + id).map( r=> r.json());
    }

    getAllVideos(query : VideoQuery)
    {
        let queryString = "";
        if(query)
        {
             queryString = objectToQueryString(query);
        }
        return this.http.get(this.videoEndPoint + queryString).map( r=> r.json());
    }


    
}