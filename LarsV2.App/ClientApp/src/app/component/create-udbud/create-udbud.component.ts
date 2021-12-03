import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
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

  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      uddannelseInputCtl: [null, UddannelseInputRequired],
    });

    this.secondFormGroup = this._formBuilder.group({
      teacherDropdownCtl: [null, TeacherDropdownRequired],
    });
  }
}
