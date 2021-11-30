import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { iLecturer, NullLecturer } from 'src/app/DTO/lecturers';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {

  lecturesData: iLecturer = new NullLecturer;

  constructor(private socket: LecturersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(param => {
      const id = +param.get('id');
      this.socket.getThisLecturer(id).pipe(take(1)).subscribe(data => {
        this.lecturesData = data;
      })
    });
  }

}
