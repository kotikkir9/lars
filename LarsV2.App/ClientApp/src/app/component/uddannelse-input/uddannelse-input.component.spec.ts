import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UddannelseInputComponent } from './uddannelse-input.component';

describe('UddannelseInputComponent', () => {
  let component: UddannelseInputComponent;
  let fixture: ComponentFixture<UddannelseInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UddannelseInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UddannelseInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
