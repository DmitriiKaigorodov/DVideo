import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class CategoriesService {


  private readonly categoriesEndpoint = "api/categories/";
  constructor(private http : Http) { }

  
  getAllCategories()
  {
    return this.http.get(this.categoriesEndpoint).map(
      response => response.json()
    );
  }

}
