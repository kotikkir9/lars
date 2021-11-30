import { Component, OnInit } from '@angular/core';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.scss']
})
export class TestPageComponent implements OnInit {

  constructor(private socket: LecturersService) { }

  ngOnInit(): void {
  }

  async buttonPush(){
    console.log(await this.socket.getThisLecturer(1).toPromise());
  }

}
