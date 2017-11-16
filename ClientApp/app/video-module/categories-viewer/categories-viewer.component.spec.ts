import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriesViewerComponent } from './categories-viewer.component';

describe('CategoriesViewerComponent', () => {
  let component: CategoriesViewerComponent;
  let fixture: ComponentFixture<CategoriesViewerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoriesViewerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoriesViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
