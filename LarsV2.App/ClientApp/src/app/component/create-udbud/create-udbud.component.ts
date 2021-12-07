import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { iCoursesSend } from 'src/app/DTO/courses';
import { iEducationSubject } from 'src/app/DTO/educationSubject';
import { iLecturer } from 'src/app/DTO/lecturers';
import { iSubject } from 'src/app/DTO/subject';
import { CoursesService } from 'src/app/service/courses.service';
import { DatepickerChipsInputOneOrMany } from '../datepicker-chips-input/datepicker-chips-input.component';
import { TeacherDropdownRequired } from '../teacher-dropdown/teacher-dropdown.component';
import { UddannelseInputRequired } from '../uddannelse-input/uddannelse-input.component';

@Component({
  selector: 'app-create-udbud',
  templateUrl: './create-udbud.component.html',
  styleUrls: ['./create-udbud.component.scss']
})
export class CreateUdbudComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  treeFormGroup: FormGroup;

  constructor(private _formBuilder: FormBuilder, private socket: CoursesService) { }

  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      uddannelseInputCtl: [null, UddannelseInputRequired],
    });

    this.secondFormGroup = this._formBuilder.group({
      teacherDropdownCtl: [null, TeacherDropdownRequired],
    });

    this.treeFormGroup = this._formBuilder.group({
      datePickCtl: [null, DatepickerChipsInputOneOrMany],
    });
  }

  send(): void {
    if(this.firstFormGroup.invalid || this.secondFormGroup.invalid || this.treeFormGroup.invalid)
      return;

    let lecturer: iLecturer = this.secondFormGroup.controls['teacherDropdownCtl'].value;
    let educationSubject: iEducationSubject = this.firstFormGroup.controls['uddannelseInputCtl'].value;
    let subject: iSubject = {
      id: educationSubject.subject.id,
      title: educationSubject.subject.subject,
      education: educationSubject.education,
      description: null
    };

    let courseDates: string[] = this.treeFormGroup.controls['datePickCtl'].value;

    let data: iCoursesSend = {
      courseDates: courseDates,
      subject: subject,
      lecturer: lecturer,
      description: null
    }

    this.socket.createCourses(data);
  }
}
