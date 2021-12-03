import { Component, OnInit } from '@angular/core';
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
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  dateList: string[] = [];

  dateCtrl = new FormControl();

  add(event: MatChipInputEvent): void {
    const value = (event.value || '').trim();

    if (value) {
      this.dateList.push(value);
    }

    this.dateCtrl.setValue(null);
  }

  addDate(event: MatDatepickerInputEvent<Date>){
    this.dateList.push(event.value.toJSON());
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
