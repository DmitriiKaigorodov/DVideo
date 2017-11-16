import { Category } from './../models/Categories/Category';
import { CompleterService, CompleterData } from 'ng2-completer';
import { Component, OnInit, Output, EventEmitter, OnChanges, SimpleChanges, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';


const CATEGORIES_ACCESSOR = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => CategoriesSelectorComponent),
  multi: true
};

@Component({
  selector: 'categories-selector',
  templateUrl: './categories-selector.component.html',
  styleUrls: ['./categories-selector.component.css'],
  providers : [CATEGORIES_ACCESSOR]

})
export class CategoriesSelectorComponent implements OnInit, OnChanges, ControlValueAccessor {
  onTouched : () => void = () => {};
  onChange : (_ : any)  => {};
  selectedCategories : Category[] = [];

  categoriesData : CompleterData;
  constructor(private completerService : CompleterService) { }

  ngOnInit() {
    this.categoriesData = this.completerService.remote("/api/categories?Name=", "name", "name");
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes)
  }

  onCategorySelected(event : any)
  {   
    if(!event)
      return;
      
     var category : Category = event.originalObject;
     this.selectedCategories.push(category);
     this.onChange(this.selectedCategories);

  }

  onBlur()
  {
    this.onTouched();
  }

  writeValue(obj: any): void {
    if(obj)
    {
      this.selectedCategories = obj;
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  removeCategory(category : Category)
  {
    var index = this.selectedCategories.indexOf(category);
    this.selectedCategories.splice(index, 1);
    this.onChange(this.selectedCategories);

  }




}
