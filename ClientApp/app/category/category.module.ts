import { SharedModule } from './../shared/shared.module';
import { CategoriesService } from './services/categories.service';
import { CategoriesSelectorComponent } from './categories-selector/categories-selector.component';
import { CategorySwitcherComponent } from './category-switcher/category-switcher.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoriesViewerComponent } from './categories-viewer/categories-viewer.component';



@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  declarations: [ CategoryListComponent, CategorySwitcherComponent,
     CategoriesViewerComponent,  CategoriesSelectorComponent],

  exports:  [ CategoryListComponent, CategorySwitcherComponent,
    CategoriesViewerComponent,  CategoriesSelectorComponent],

  providers : [CategoriesService]
})
export class CategoryModule { }
