import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { iEducationSubject } from 'src/app/DTO/educationSubject';

@Component({
  selector: 'app-create-udbud',
  templateUrl: './create-udbud.component.html',
  styleUrls: ['./create-udbud.component.scss']
})
export class CreateUdbudComponent implements OnInit {

  firstFormGroup: FormGroup;

  constructor(private _formBuilder: FormBuilder) { }

  addEducationSubject(data: iEducationSubject): void {
    // this.educationSubject.push(data);
  }


  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      phoneNumber: ['', Validators.required],
    });
  }

}
