import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';


@Injectable()
export class VideoFilesService {

  private _videoFileEndpoint = "api/videos/videofile"
  constructor(private http : Http) { 

  }

  uploadVideoFile(fileData : FormData)
  {
      return this.http.post(this._videoFileEndpoint, fileData);
  }

  deleteVideoFile(id :Number)
  {
    return this.http.delete(this._videoFileEndpoint + "/" + id);
  }

  updateVideoFile( id: Number,  fileInfo : any)
  {
    return this.http.put(this._videoFileEndpoint + "/" + id, fileInfo);
  }

}
