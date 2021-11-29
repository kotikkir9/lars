import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UdbudTableComponent } from './udbud-table.component';

describe('UdbudTableComponent', () => {
  let component: UdbudTableComponent;
  let fixture: ComponentFixture<UdbudTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UdbudTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UdbudTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
