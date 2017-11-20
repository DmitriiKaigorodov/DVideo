import { CategoriesService } from './../services/categories.service';
import { Component, OnInit } from '@angular/core';
import { Category } from '../models/Category';

@Component({
  selector: 'category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories : Category[];
  constructor(private categoriesService : CategoriesService) { }

  ngOnInit() {

    this.categoriesService.getAllCategories().subscribe( categories =>
      {
        this.categories = categories
      });
  }

}
