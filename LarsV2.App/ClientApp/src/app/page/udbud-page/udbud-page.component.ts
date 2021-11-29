import { Component, OnInit, ViewChild } from '@angular/core';
import { UddannelseInputComponent } from 'src/app/component/uddannelse-input/uddannelse-input.component';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';

@Component({
  selector: 'app-udbud-page',
  templateUrl: './udbud-page.component.html',
  styleUrls: ['./udbud-page.component.scss']
})
export class UdbudPageComponent implements OnInit {

  filterData: iEducationSubject = new NullEducationSubject;

  searchData: string = "";

  searchInputRef: string;

  @ViewChild('uddannelseInput') filterInputRef: UddannelseInputComponent;

  constructor() { }

  ngOnInit(): void {
  }

  addEducationSubject(data: iEducationSubject): void {
    this.filterData = data;
  }

  resetFilter(): void {
    this.filterInputRef.reset();
    this.filterData = new NullEducationSubject;
    this.searchData = "";
    this.searchInputRef = "";
  }

  searchButton(): void {
    this.filterInputRef.getDataFormInput(false, false);
    this.searchData = this.searchInputRef;
  }

}
