import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iCourses } from '../DTO/courses';
import { iEducationSubject, NullEducationSubject } from '../DTO/educationSubject';
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

  getData(pageSize: number, pageIndex: number, filter:iEducationSubject = new NullEducationSubject, search: string = ""): Observable<iCoursesServiceData> {
    return this.http.get<iCoursesServiceData>(this.url, {
      params: new HttpParams()
        .set("PageSize", pageSize.toString())
        .set("PageNumber", (pageIndex + 1).toString())
        .set("Subject", filter.subject.subject)
        .set("Education", filter.education)
        .set("SearchQuery", search)
    });
  }
}
