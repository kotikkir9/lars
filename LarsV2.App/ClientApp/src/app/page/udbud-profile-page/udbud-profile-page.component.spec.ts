import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UdbudProfilePageComponent } from './udbud-profile-page.component';

describe('UdbudProfilePageComponent', () => {
  let component: UdbudProfilePageComponent;
  let fixture: ComponentFixture<UdbudProfilePageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UdbudProfilePageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UdbudProfilePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
