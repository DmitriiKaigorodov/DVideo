import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LikesPanelComponent } from './likes-panel.component';

describe('LikesPanelComponent', () => {
  let component: LikesPanelComponent;
  let fixture: ComponentFixture<LikesPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LikesPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LikesPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
