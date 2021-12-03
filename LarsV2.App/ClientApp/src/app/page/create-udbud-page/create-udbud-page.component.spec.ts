import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUdbudPageComponent } from './create-udbud-page.component';

describe('CreateUdbudPageComponent', () => {
  let component: CreateUdbudPageComponent;
  let fixture: ComponentFixture<CreateUdbudPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateUdbudPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateUdbudPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
