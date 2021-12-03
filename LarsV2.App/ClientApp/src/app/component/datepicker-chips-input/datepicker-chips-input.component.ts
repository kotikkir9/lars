import { Component, OnInit, ViewChild } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { FormControl } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';

@Component({
  selector: 'app-datepicker-chips-input',
  templateUrl: './datepicker-chips-input.component.html',
  styleUrls: ['./datepicker-chips-input.component.scss']
})
export class DatepickerChipsInputComponent implements OnInit {
  invalidDate: boolean = false;

  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  dateList: string[] = [];

  dateCtrl = new FormControl();

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      let date: Date = new Date(value)
      if(date.toString() != "Invalid Date"){
        this.invalidDate = false;
        this.dateList.push(date.toJSON());
      }else{
        this.invalidDate = true;
        return;
      }
    }

    this.dateCtrl.setValue(null);
  }

  remove(date: string): void {
    const index = this.dateList.indexOf(date);

    if (index >= 0) {
      this.dateList.splice(index, 1);
    }
  }

  ngOnInit(): void {
  }

}
