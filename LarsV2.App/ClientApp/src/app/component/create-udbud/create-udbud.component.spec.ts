import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUdbudComponent } from './create-udbud.component';

describe('CreateUdbudComponent', () => {
  let component: CreateUdbudComponent;
  let fixture: ComponentFixture<CreateUdbudComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateUdbudComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateUdbudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
