import { Component, forwardRef, OnInit } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material/chips';
import { AbstractControl, ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-datepicker-chips-input',
  templateUrl: './datepicker-chips-input.component.html',
  styleUrls: ['./datepicker-chips-input.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => DatepickerChipsInputComponent)
    }
  ]
})
export class DatepickerChipsInputComponent implements OnInit, ControlValueAccessor {
  
  invalidDate: boolean = false;

  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;
  dateList: string[] = [];

  private onChange: (data: string[]) => void;
  private onTouched: () => void;

  dateCtrl = new FormControl();

  writeValue(obj: string[]): void {
    if(obj){
      this.dateList = obj;
    }else{
      this.dateList = [];
    }
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    if(isDisabled){
      this.dateCtrl.disable();
    } else {
      this.dateCtrl.enable();
    }
  }

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
    this.onChange(this.dateList);
    this.dateCtrl.setValue(null);
  }

  remove(date: string): void {
    const index = this.dateList.indexOf(date);

    if (index >= 0) {
      this.dateList.splice(index, 1);
    }
    this.onChange(this.dateList);
  }

  ngOnInit(): void {
  }

  doInput() {
      this.onChange(this.dateList);
  }

  doBlur() {
    this.onTouched();
  }

}

export function DatepickerChipsInputOneOrMany(control: AbstractControl): {[key: string]: any} | null  {
  let data: string[] = control.value;

  if (!data || data.length <= 0) {
    return { 'TeacherDropdownInvalid': true };
  }
  return null;
}
