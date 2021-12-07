import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DatepickerChipsInputOneOrMany } from 'src/app/component/datepicker-chips-input/datepicker-chips-input.component';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.scss']
})
export class TestPageComponent implements OnInit {

  datePick: FormControl = new FormControl(null, DatepickerChipsInputOneOrMany);

  constructor(private socket: LecturersService) { }

  ngOnInit(): void {
  }

  test() {
    console.log(this.datePick.valid);
    console.log(this.datePick.value);
  }

}
