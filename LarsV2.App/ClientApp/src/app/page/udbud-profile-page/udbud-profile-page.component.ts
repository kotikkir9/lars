import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { iCourses, NullCourses } from 'src/app/DTO/courses';
import { CoursesService } from 'src/app/service/courses.service';

@Component({
  selector: 'app-udbud-profile-page',
  templateUrl: './udbud-profile-page.component.html',
  styleUrls: ['./udbud-profile-page.component.scss']
})
export class UdbudProfilePageComponent implements OnInit {

  coursesData: iCourses = new NullCourses;

  constructor(private socket: CoursesService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(param => {
      const id = +param.get('id');
      this.socket.getThisCourses(id).pipe(take(1)).subscribe(data => {
        this.coursesData = data;
      })
    });
  }

}
