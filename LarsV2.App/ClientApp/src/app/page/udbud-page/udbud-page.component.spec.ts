import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UdbudPageComponent } from './udbud-page.component';

describe('UdbudPageComponent', () => {
  let component: UdbudPageComponent;
  let fixture: ComponentFixture<UdbudPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UdbudPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UdbudPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
