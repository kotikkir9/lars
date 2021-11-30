import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DatepickerChipsInputComponent } from './datepicker-chips-input.component';

describe('DatepickerChipsInputComponent', () => {
  let component: DatepickerChipsInputComponent;
  let fixture: ComponentFixture<DatepickerChipsInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DatepickerChipsInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DatepickerChipsInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
