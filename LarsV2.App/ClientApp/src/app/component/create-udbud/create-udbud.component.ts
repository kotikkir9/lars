import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-udbud',
  templateUrl: './create-udbud.component.html',
  styleUrls: ['./create-udbud.component.scss']
})
export class CreateUdbudComponent implements OnInit {

  // firstFormGroup: FormGroup;
  uddannelseInputCtl: FormControl = new FormControl;

  constructor(private _formBuilder: FormBuilder) { }

  ngOnInit(): void {
    // this.firstFormGroup = this._formBuilder.group({
    //   firstName: ['', Validators.required],
    //   lastName: ['', Validators.required],
    //   email: ['', [Validators.email, Validators.required]],
    //   phoneNumber: ['', Validators.required],
    // });
  }

}
