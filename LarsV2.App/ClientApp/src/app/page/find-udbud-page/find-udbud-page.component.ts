import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { iUdbudTableInput, NullUdbudTableInput } from 'src/app/component/udbud-table/udbud-table.component';
import { UddannelseInputComponent } from 'src/app/component/uddannelse-input/uddannelse-input.component';
import { iEducationSubject } from 'src/app/DTO/educationSubject';

@Component({
  selector: 'app-find-udbud-page',
  templateUrl: './find-udbud-page.component.html',
  styleUrls: ['./find-udbud-page.component.scss']
})
export class FindUdbudPageComponent implements OnInit {

  udbudTableInputData: iUdbudTableInput = new NullUdbudTableInput

  searchInputRef: string;
  startdatoInputRef: string;
  slutdatoInputRef: string;

  @ViewChild('uddannelseInput') filterInputRef: UddannelseInputComponent;
  uddannelseInputCtl: FormControl = new FormControl;

  constructor() { }

  ngOnInit(): void {
  }

  resetFilter(): void {
    this.filterInputRef.resetAll();

    this.udbudTableInputData = new NullUdbudTableInput;
    this.searchInputRef = "";
    this.slutdatoInputRef = "";
    this.startdatoInputRef = "";
  }

  searchButton(): void {
    this.udbudTableInputData.filterData = this.uddannelseInputCtl.value;
    this.udbudTableInputData.searchData = this.searchInputRef;
    this.udbudTableInputData.toDate = this.slutdatoInputRef;
    this.udbudTableInputData.fromDate = this.startdatoInputRef;
  }

}
