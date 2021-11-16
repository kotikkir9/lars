import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CoursesService } from 'src/app/service/courses.service';
import { take } from 'rxjs/operators'

@Component({
  selector: 'app-opret-udbud',
  templateUrl: './opret-udbud.component.html',
  styleUrls: ['./opret-udbud.component.scss']
})
export class OpretUdbudComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  constructor(private _formBuilder: FormBuilder, private cs: CoursesService) {}

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
      firstAge: ['', Validators.required],
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
  }

  sendData(){
    // console.log(this.firstFormGroup.value);
    this.cs.getData().pipe(take(1)).subscribe(x =>  {
      console.log(x);
    },err => console.log(err));
  }

}
