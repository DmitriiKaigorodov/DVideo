
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ThumbnailsService {

    private thumbnailEndpount = "api/videos/thumbnail";

    constructor(private http: Http) { }

    uploadThumbnail(fileData : FormData)
    {
        return this.http.post(this.thumbnailEndpount, fileData);
    }
  
    deleteThumbnail(id :Number)
    {
      return this.http.delete(this.thumbnailEndpount + "/" + id);
    }    
}