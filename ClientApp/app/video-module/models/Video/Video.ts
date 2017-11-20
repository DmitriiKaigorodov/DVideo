import { Author } from './../Author';
import { Thumbnail } from './../Thumbnail';
import { VideoFile } from './../VideoFile';
import { Category } from '../../../category/models/Category';
export class Video
{
    id : number = 0;
    title : string;
    description : string = "";
    thumbnail : Thumbnail;
    publishDate: string;
    file : VideoFile = new VideoFile();
    author : Author = new Author();
    categories : Category[] = [];   
    likes : Number;
    dislikes: Number;

    
}