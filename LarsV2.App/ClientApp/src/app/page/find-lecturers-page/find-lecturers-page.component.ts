import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { UddannelseInputComponent } from 'src/app/component/uddannelse-input/uddannelse-input.component';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';

@Component({
  selector: 'app-find-lecturers-page',
  templateUrl: './find-lecturers-page.component.html',
  styleUrls: ['./find-lecturers-page.component.scss']
})
export class FindLecturersPageComponent implements OnInit {

  filterData: iEducationSubject = new NullEducationSubject;

  searchData: string = "";

  searchInputRef: string;

  @ViewChild('uddannelseInput') filterInputRef: UddannelseInputComponent;
  uddannelseInputCtl: FormControl = new FormControl;

  constructor() { }

  ngOnInit(): void {
  }

  resetFilter(): void {
    this.filterInputRef.resetAll();
    this.filterData = new NullEducationSubject;
    this.searchData = "";
    this.searchInputRef = "";
  }

  searchButton(): void {
    this.filterData = this.uddannelseInputCtl.value ? this.uddannelseInputCtl.value : new NullEducationSubject;
    this.searchData = this.searchInputRef;
  }

}
