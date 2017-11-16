import { Author } from './../Author';
import { Category } from './../Categories/Category';
import { Thumbnail } from './../Thumbnail';
import { VideoFile } from './../VideoFile';
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