import { Query } from './../Query';
export class VideoQuery extends Query
{
    categoryName : String
    minLength : Number = 1;
    maxLength : Number = 9;


}