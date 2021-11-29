import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iCourses } from '../DTO/courses';
import { iMetadata } from '../DTO/metadata';

export interface iCoursesServiceData {
  metadata: iMetadata;
  records: iCourses[];
}

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  private readonly url = "/api/courses";

  constructor(private http: HttpClient) { }

  getData(): Observable<iCoursesServiceData> {
    return this.http.get<iCoursesServiceData>(this.url);
  }
}
