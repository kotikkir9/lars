import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iCourses } from '../DTO/courses';
import { iCoursesSearchParmas } from '../DTO/coursesSearchParmas';
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

  getData(data: iCoursesSearchParmas): Observable<iCoursesServiceData> {
    return this.http.get<iCoursesServiceData>(this.url, {
      params: new HttpParams()
        .set("PageSize", data.pageSize.toString())
        .set("PageNumber", (data.pageIndex + 1).toString())
        .set("Subject", data.filter.subject.subject)
        .set("Education", data.filter.education)
        .set("SearchQuery", data.search)
        .set("FromDate", data.fromDate)
        .set("ToDate", data.toDate)
    });
  }

  getThisCourses(id: number): Observable<iCourses> {
    return this.http.get<iCourses>(this.url + `/${id}`);
  }
}
