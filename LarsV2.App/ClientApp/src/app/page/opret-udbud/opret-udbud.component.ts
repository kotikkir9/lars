import { Component, OnInit } from '@angular/core';
import { CoursesService } from 'src/app/service/courses.service';
import { take } from 'rxjs/operators'

@Component({
  selector: 'app-opret-udbud',
  templateUrl: './opret-udbud.component.html',
  styleUrls: ['./opret-udbud.component.scss']
})
export class OpretUdbudComponent implements OnInit {

  constructor(private cs: CoursesService) {}

  ngOnInit() {
  }

  sendData(): void {
    // console.log(this.firstFormGroup.value);
    // this.cs.getData().pipe(take(1)).subscribe(x =>  {
    //   console.log(x);
    // },err => console.log(err));
  }

}
