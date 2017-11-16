import { Query } from './../Query';
export class VideoQuery extends Query
{
    categoryName : String
    minLength : Number
    maxLength : Number


    constructor() {
        super();
        this.limit = 9;
        this.page = 1;
    }
}