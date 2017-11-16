import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoLengthFilterComponent } from './video-length-filter.component';

describe('VideoLengthFilterComponent', () => {
  let component: VideoLengthFilterComponent;
  let fixture: ComponentFixture<VideoLengthFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VideoLengthFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoLengthFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
