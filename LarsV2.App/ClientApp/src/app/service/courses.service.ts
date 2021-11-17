import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface iCourses {
  key1: string[];
  key2: string[];
}

@Injectable({
  providedIn: 'root'
})
export class CoursesService {

  constructor(private http: HttpClient) {
  }

  getData(): Observable<iCourses> {
    return this.http.get<iCourses>("/api/courses");
  }

}
