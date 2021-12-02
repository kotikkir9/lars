import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindUdbudPageComponent } from './find-udbud-page.component';

describe('UdbudPageComponent', () => {
  let component: FindUdbudPageComponent;
  let fixture: ComponentFixture<FindUdbudPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindUdbudPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindUdbudPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
