import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iEducationSubject, NullEducationSubject } from '../DTO/educationSubject';
import { iLecturer } from '../DTO/lecturers';
import { iMetadata } from '../DTO/metadata';

export interface iLecturersServiceData {
  metadata: iMetadata;
  records: iLecturer[];
}

@Injectable({
  providedIn: 'root'
})
export class LecturersService {

  private readonly url = "/api/lecturers";

  constructor(private http: HttpClient) { }

  getData(pageSize: number, pageIndex: number, filter:iEducationSubject = new NullEducationSubject, search: string = ""): Observable<iLecturersServiceData> {
      return this.http.get<iLecturersServiceData>(this.url, {
        params: new HttpParams()
          .set("PageSize", pageSize.toString())
          .set("PageNumber", (pageIndex + 1).toString())
          .set("Subject", filter.subject.subject)
          .set("Education", filter.education)
          .set("SearchQuery", search)
      });
  }

  getAllData(filter:iEducationSubject = new NullEducationSubject): Observable<iLecturersServiceData> {
      return this.http.get<iLecturersServiceData>(this.url, {
        params: new HttpParams()
          .set("Subject", filter.subject.subject)
          .set("Education", filter.education)
      });
  }

  getThisLecturer(id: number): Observable<iLecturer> {
    return this.http.get<iLecturer>(this.url + `/${id}`);
  }

  // createLecturer(data: iLecturer): void {
  //   this.http.post(this.url, data);
  // }
}
