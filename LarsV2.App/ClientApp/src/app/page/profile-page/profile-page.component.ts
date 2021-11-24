import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { iLecturers, NullLecturers } from 'src/app/DTO/lecturers';
import { LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {

  lecturesData: iLecturers = new NullLecturers;

  constructor(private socket: LecturersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap.get('id')!

    this.socket.getThisLecturers(id).subscribe(data => {
      this.lecturesData = data;
    })
  }

}
