import { Component, forwardRef, Input, OnInit } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
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
    this.loadData(data);
  }

  constructor(private socket: LecturersService) { }
  writeValue(obj: iLecturer): void {
    if(obj){
      this.selectCtl.setValue(obj.name);
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

  doInput() {
    let teacherName = this.selectCtl.value;
    let teacherList: iLecturer = this.lecturers.find(data => {
      return data.name === teacherName;
    });
    
    this.onChange(teacherList);
  }

  doBlur() {
    this.onTouched();
  }

}
