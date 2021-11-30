import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { iLecturer } from 'src/app/DTO/lecturers';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-teacher-dropdown',
  templateUrl: './teacher-dropdown.component.html',
  styleUrls: ['./teacher-dropdown.component.scss']
})
export class TeacherDropdownComponent implements OnInit {

  selectedValue: string;

  lecturers: iLecturer[] = [];

  constructor(private socket: LecturersService) { }

  ngOnInit(): void {
    this.socket.getAllData().pipe(take(1)).subscribe(data => {
      this.lecturers = data.records;
    });
  }

}
