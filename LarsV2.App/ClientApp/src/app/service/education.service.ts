import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { iEducationSubject, iEducationSubjectArray } from '../DTO/educationSubject';

export interface iEducationServiceData {
	EducationSubject: iEducationSubject[];
	Education: string[];
}

@Injectable({
	providedIn: 'root'
})
export class EducationService {

	private readonly url = "/api/educations";

	constructor(private http: HttpClient) { }

	getData(): Observable<iEducationServiceData> {
		return this.http.get<iEducationSubjectArray>(this.url).pipe(
			map(datas => this.convetHttpData(datas))
		);
	}

	private convetHttpData(datas): iEducationServiceData {
		let data: iEducationServiceData = {
			EducationSubject: [],
			Education: []
		}

		datas.forEach(item => {
			data.EducationSubject.push.apply(data.EducationSubject, this.convetEducationData(item))
			data.Education.push(item.education);
		});

		return data;
	}

	private convetEducationData(data: iEducationSubjectArray): iEducationSubject[] {
		let newData: iEducationSubject[] = [];

		data.subjects.forEach(subject => {
			newData.push({ education: data.education, subject: subject });
		})

		return newData;
	}
}
