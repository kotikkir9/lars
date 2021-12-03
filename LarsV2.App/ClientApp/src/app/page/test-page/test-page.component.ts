import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.scss']
})
export class TestPageComponent implements OnInit {

  dropdownCtl: FormControl = new FormControl;

  constructor(private socket: LecturersService) { }

  ngOnInit(): void {
  }

  test(){
    if(this.dropdownCtl.enabled){
      this.dropdownCtl.disable();
    } else {
      this.dropdownCtl.enable();
    }
  }

}
