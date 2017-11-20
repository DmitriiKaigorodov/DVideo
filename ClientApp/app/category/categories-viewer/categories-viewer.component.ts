import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Category } from './../../category/models/Category';
import { Component, OnInit, forwardRef } from '@angular/core';


const CATEGORIES_VIEWER = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => CategoriesViewerComponent),
  multi: true
};

@Component({
  selector: 'categories-viewer',
  templateUrl: './categories-viewer.component.html',
  styleUrls: ['./categories-viewer.component.css'],
  providers: [CATEGORIES_VIEWER]
})
export class CategoriesViewerComponent implements OnInit, ControlValueAccessor {

  selectedCategories : Category[] = [];
  constructor() { }

  ngOnInit() {
  }

  writeValue(obj: any): void {
    if(obj)
    {
      this.selectedCategories = obj;
    }
  }
  registerOnChange(fn: any): void {
  }
  registerOnTouched(fn: any): void {
  }

}
