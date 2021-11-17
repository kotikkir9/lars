import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpretUdbudStepComponent } from './opret-udbud-step.component';

describe('OpretUdbudStepComponent', () => {
  let component: OpretUdbudStepComponent;
  let fixture: ComponentFixture<OpretUdbudStepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpretUdbudStepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpretUdbudStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
