import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpretUdbudComponent } from './opret-udbud.component';

describe('OpretUdbudComponent', () => {
  let component: OpretUdbudComponent;
  let fixture: ComponentFixture<OpretUdbudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpretUdbudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpretUdbudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
