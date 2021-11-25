import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindLecturersPageComponent } from './find-lecturers-page.component';

describe('FindLecturersPageComponent', () => {
  let component: FindLecturersPageComponent;
  let fixture: ComponentFixture<FindLecturersPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindLecturersPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindLecturersPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
