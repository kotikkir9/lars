import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { iEducationSubject } from 'src/app/DTO/educationSubject';
import { iLecturerSend } from 'src/app/DTO/lecturers';
import { Subject } from 'src/app/DTO/subject';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-create-teacher',
  templateUrl: './create-teacher.component.html',
  styleUrls: ['./create-teacher.component.scss']
})
export class CreateTeacherComponent implements OnInit {

  firstFormGroup: FormGroup;

  educationSubject: iEducationSubject[] = [];

  constructor(private _formBuilder: FormBuilder, private socket: LecturersService) {}

  addEducationSubject(data: iEducationSubject): void {
    this.educationSubject.push(data);
  }

  removeEducationSubject(data: iEducationSubject): void {
    let index: number = this.educationSubject.indexOf(data);

    this.educationSubject.splice(index,1);
  }

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      phoneNumber: ['', Validators.required],
    });
  }

  sendData(): void {
    if(!this.firstFormGroup.valid)
      return

    let inputData = this.firstFormGroup.value;

    let teacher: iLecturerSend = {
      firstName: inputData.firstName,
      lastName: inputData.lastName,
      id: null,
      email: inputData.email,
      phoneNumber: inputData.phoneNumber,
      cvPath: null,
      imagePath: null,
      isExternal: false,
      subjects: []
    }

    this.educationSubject.forEach(sub => {
      teacher.subjects.push(new Subject(sub.subject.id, sub.subject.subject, sub.education, null));
    });

    this.socket.createLecturer(teacher);
  }

}
