import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iLecturers } from '../DTO/lecturers';

export interface iMetadata {
  totalCount: number;
  pageSize: number;
  currentPage: number;
  totalPages: number;
}

export interface iLecturersServiceData {
  metadata: iMetadata;
  records: iLecturers[];
}

@Injectable({
  providedIn: 'root'
})
export class LecturersService {

  private readonly url = "/api/lecturers";

  constructor(private http: HttpClient) { }

  getData(pageSize: number, pageIndex: number): Observable<iLecturersServiceData> {

    return this.http.get<iLecturersServiceData>(this.url, {
      params: new HttpParams()
        .set("PageSize", pageSize.toString())
        .set("PageNumber", (pageIndex + 1).toString())
    });
  }

  getThisLecturers(id: number): Observable<iLecturers> {
    return this.http.get<iLecturers>(this.url + `/${id}`);
  }
}
