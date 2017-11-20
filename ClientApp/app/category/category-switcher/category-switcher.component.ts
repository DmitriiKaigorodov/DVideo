import { Category } from './../../category/models/Category';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'category-switcher',
  templateUrl: './category-switcher.component.html',
  styleUrls: ['./category-switcher.component.css']
})
export class CategorySwitcherComponent implements OnInit {

  @Input() categories : Category[] = [];
  @Input() selectedCategoryId : Number;
  @Output() categoryChanged = new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  onCategoryClicked(event: any, category : Category)
  {
    event.preventDefault();

    if(this.selectedCategoryId == category.id)
    {
      this.selectedCategoryId = 0;
      this.categoryChanged.emit(undefined);
    }
    else
    {
      this.selectedCategoryId = category.id;
      this.categoryChanged.emit(category);
    }

  }

}
