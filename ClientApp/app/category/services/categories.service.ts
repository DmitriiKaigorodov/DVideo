import { CategoryQuery } from './../models/CategoryQuery';
import { Category } from '../models/Category';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { objectToQueryString } from '../../shared/utils';


@Injectable()
export class CategoriesService {


  private readonly categoriesEndpoint = "api/categories/";
  constructor(private http : Http) { }

  
  getCategories(categoryQuery : CategoryQuery)
  {
    return this.http.get(this.categoriesEndpoint + objectToQueryString(categoryQuery))
    .map(
      response => response.json()
    );   
  }
  
  getAllCategories()
  {
    return this.http.get(this.categoriesEndpoint)
    .map(
      response => response.json()
    );
  }

  addCategory(category : Category)
  {
    return this.http.post(this.categoriesEndpoint, category).map( 
        response => response.json()
    );
  }

  updateCategory(id : Number, category: Category)
  {
   
    return this.http.put(this.categoriesEndpoint + id, category).map( 
      response => response.json()
    );
  }

  deleteCategory(id: Number)
  {
    return this.http.delete(this.categoriesEndpoint + id);
  }

}
