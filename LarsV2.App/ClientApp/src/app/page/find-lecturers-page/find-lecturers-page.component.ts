import { Component, OnInit, ViewChild } from '@angular/core';
import { UddannelseInputComponent } from 'src/app/component/uddannelse-input/uddannelse-input.component';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';

@Component({
  selector: 'app-find-lecturers-page',
  templateUrl: './find-lecturers-page.component.html',
  styleUrls: ['./find-lecturers-page.component.scss']
})
export class FindLecturersPageComponent implements OnInit {

  filterData: iEducationSubject = new NullEducationSubject;

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
  }

}
