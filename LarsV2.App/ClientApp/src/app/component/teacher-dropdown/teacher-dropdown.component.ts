import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { MatOptionSelectionChange } from '@angular/material/core';
import { take } from 'rxjs/operators';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';
import { iLecturer } from 'src/app/DTO/lecturers';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-teacher-dropdown',
  templateUrl: './teacher-dropdown.component.html',
  styleUrls: ['./teacher-dropdown.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => TeacherDropdownComponent)
    }
  ]
})
export class TeacherDropdownComponent implements OnInit, ControlValueAccessor {

  selectCtl: FormControl = new FormControl;
  lecturers: iLecturer[] = [];

  private onChange: (data: iLecturer) => void;
  private onTouched: () => void;

  @Input() set filter(data: iEducationSubject){
    if(data)
      this.loadData(data);
  }

  constructor(private socket: LecturersService) { }
  writeValue(obj: iLecturer): void {
    if(obj){
      this.selectCtl.setValue(obj.name);
    }else{
      this.selectCtl.setValue('');
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
      this.selectCtl.disable();
    }else{
      this.selectCtl.enable();
    }
  }

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(filter:iEducationSubject = new NullEducationSubject): void {
    this.socket.getAllData(filter).pipe(take(1)).subscribe(data => {
      this.lecturers = data.records;
    });
  }

  doInput(event: MatOptionSelectionChange, teacher: iLecturer) {
    if(event.isUserInput)
      this.onChange(teacher);
  }

  doBlur() {
    this.onTouched();
  }

}

export function TeacherDropdownRequired(control: AbstractControl): {[key: string]: any} | null  {
  let data: iLecturer = control.value;

  if (!data || data.id == -1) {
    return { 'TeacherDropdownInvalid': true };
  }
  return null;
}
