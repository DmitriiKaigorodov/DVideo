import { CategoryQuery } from './../models/CategoryQuery';
import { Observable } from 'rxjs/Observable';
import { CategoriesService } from './../services/categories.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Category } from '../models/Category';
import { ToastyService } from 'ng2-toasty';
import 'rxjs/add/observable/fromEvent'
import 'rxjs/add/operator/debounceTime'
import { Subscription } from 'rxjs/Subscription';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit, AfterViewInit {

  @ViewChild("searchField") searchField : ElementRef
  currentCategory = new Category();
  categories : Category[] = [];
  loading = true;
  isUpdate = false;
  categoryQuery = new CategoryQuery();

  constructor(private categoriesService : CategoriesService,
     private toatyService: ToastyService)
     {

     }

  
  ngOnInit() {
    this.retrieveCategories();
  }

  retrieveCategories()
  {
    this.loading = true;
    this.categoriesService.getCategories(this.categoryQuery).subscribe( categories =>
      {
        this.categories = categories
        this.loading = false;
      });
  }



  ngAfterViewInit(): void {

    Observable.fromEvent(this.searchField.nativeElement, 'keyup').debounceTime(400)
    .subscribe( event => 
      {
        if(!this.loading)
        {
           this.retrieveCategories();
        }
      });
  }


  onEditButtonClick(category : Category)
  {
    this.isUpdate = true;  
    this.currentCategory = Object.assign(this.currentCategory, category);
  }

  onAddButtonClick()
  {
    this.currentCategory = new Category();
    this.isUpdate = false;
  }

  addCategory()
  {
    this.categoriesService.addCategory(this.currentCategory).subscribe( category =>
      {
          this.categories.push(category);
          this.toatyService.success({
            msg: "Category was successfully added!",
            title: "",
            theme: "bootstrap"
          })
      },
     (error)=>
     {
      this.toatyService.error({
        msg: "Something is going wrong",
        title: "Error",
        theme: "bootstrap"
      })
     });
  }

  updateCategory()
  {
    this.categoriesService.updateCategory(this.currentCategory.id, this.currentCategory)
      .subscribe( category => 
      {
          let index = this.categories.findIndex( c => c.id == this.currentCategory.id)
          this.categories[index] = category;
          this.toatyService.success({
            msg: "Category was successfully updated!",
            title: "",
            theme: "bootstrap"
          })
         
      },
      (error)=>
      {
        this.toatyService.error({
          msg: "Something is going wrong",
          title: "Error",
          theme: "bootstrap"
        })
      });
  }

  removeCategory(id : Number)
  {
    this.categoriesService.deleteCategory(id).subscribe(
      (success) =>
      {
        let index = this.categories.findIndex(c => c.id == id);
        this.categories.splice(index, 1);
        this.toatyService.success({
          msg: "Category was successfully deleted!",
          title: "",
          theme: "bootstrap"
        })
      },
      (error) => 
      {
        this.toatyService.error({
          msg: "Something is going wrong",
          title: "Error",
          theme: "bootstrap"
        })      
      }
    )
  }

  clearSearchText()
  {
    this.categoryQuery.name = "";
    this.retrieveCategories();
  }
  onModalFormOkClicked()
  {
      if(this.isUpdate)
      {
        this.updateCategory();
      }
      else
      {
        this.addCategory();
      }
  }
}
