import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThumbnailUploadComponent } from './thumbnail-upload.component';

describe('ThumbnailUploadComponent', () => {
  let component: ThumbnailUploadComponent;
  let fixture: ComponentFixture<ThumbnailUploadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThumbnailUploadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThumbnailUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
