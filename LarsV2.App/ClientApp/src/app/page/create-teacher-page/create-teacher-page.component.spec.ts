import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTeacherPageComponent } from './create-teacher-page.component';

describe('CreateTeacherPageComponent', () => {
  let component: CreateTeacherPageComponent;
  let fixture: ComponentFixture<CreateTeacherPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateTeacherPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateTeacherPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
