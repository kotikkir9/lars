import { Component, OnInit, ViewChild } from '@angular/core';
import { iUdbudTableInput, NullUdbudTableInput } from 'src/app/component/udbud-table/udbud-table.component';
import { UddannelseInputComponent } from 'src/app/component/uddannelse-input/uddannelse-input.component';
import { iEducationSubject } from 'src/app/DTO/educationSubject';

@Component({
  selector: 'app-udbud-page',
  templateUrl: './udbud-page.component.html',
  styleUrls: ['./udbud-page.component.scss']
})
export class UdbudPageComponent implements OnInit {

  udbudTableInputData: iUdbudTableInput = new NullUdbudTableInput

  searchInputRef: string;
  startdatoInputRef: string;
  slutdatoInputRef: string;

  @ViewChild('uddannelseInput') filterInputRef: UddannelseInputComponent;

  constructor() { }

  ngOnInit(): void {
  }

  addEducationSubject(data: iEducationSubject): void {
    this.udbudTableInputData.filterData = data;
  }

  resetFilter(): void {
    this.filterInputRef.reset();

    this.udbudTableInputData = new NullUdbudTableInput;
    this.searchInputRef = "";
    this.slutdatoInputRef = "";
    this.startdatoInputRef = "";
  }

  searchButton(): void {
    this.filterInputRef.getDataFormInput(false, false);
    this.udbudTableInputData.searchData = this.searchInputRef;
    this.udbudTableInputData.toDate = this.slutdatoInputRef;
    this.udbudTableInputData.fromDate = this.startdatoInputRef;
  }

}
