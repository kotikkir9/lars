import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { iEducationSubject } from 'src/app/DTO/education';

@Component({
  selector: 'app-create-teacher',
  templateUrl: './create-teacher.component.html',
  styleUrls: ['./create-teacher.component.scss']
})
export class CreateTeacherComponent implements OnInit {

  firstFormGroup: FormGroup;

  educationSubject: iEducationSubject[] = [];

  constructor(private _formBuilder: FormBuilder) {}

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

}
