import { HttpClient } from '@angular/common/http';
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

const testData: iLecturersServiceData = {
  metadata: {
    totalCount: 10,
    pageSize: 10,
    currentPage: 1,
    totalPages: 2
  },
  records: [
    {
      id: 1,
      firstName: "Jan Pan",
      lastName: "Nees",
      email: "jan@eamv.dk",
      phoneNumber: "+45 12345678",
      cvPath: null,
      imagePath: null,
      isExternal: true,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 2,
      firstName: "James",
      lastName: "Hetfield",
      email: "jameshetfield@metallica.com",
      phoneNumber: "+45 69696969",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 3,
      firstName: "Flemming",
      lastName: "Efternavn",
      email: "flemming@eamv.dk",
      phoneNumber: "+45 11111111",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 4,
      firstName: "Till",
      lastName: "Lindemann",
      email: "lindemann@eamv.dk",
      phoneNumber: "+45 98765432",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 5,
      firstName: "Bob",
      lastName: "Ross",
      email: "bob@eamv.dk",
      phoneNumber: "+45 44444444",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 6,
      firstName: "Vladimir",
      lastName: "Putin",
      email: "putin@eamv.dk",
      phoneNumber: "+45 55555555",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 7,
      firstName: "Donald",
      lastName: "Trump",
      email: "trump@eamv.dk",
      phoneNumber: "+45 66666666",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 8,
      firstName: "Joe",
      lastName: "Rogan",
      email: "joe@eamv.dk",
      phoneNumber: "+45 77777777",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 9,
      firstName: "Max",
      lastName: "Verstappen",
      email: "max@eamv.dk",
      phoneNumber: "+45 88888888",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    },
    {
      id: 10,
      firstName: "Lionel",
      lastName: "Messi",
      email: "messi@eamv.dk",
      phoneNumber: "+45 99999999",
      cvPath: null,
      imagePath: null,
      isExternal: false,
      knowledge: null,
      lecturerSubjects: null
    }
  ]
}

@Injectable({
  providedIn: 'root'
})
export class LecturersService {

  constructor(private http: HttpClient) { }

  getData(pageSize: number, pageIndex: number): Observable<iLecturersServiceData> {
    let buildData: iLecturersServiceData = {
      metadata: testData.metadata,
      records: []
    };

    buildData.records = testData.records.slice(pageSize * pageIndex, Math.min(testData.records.length , (pageSize * pageIndex + pageSize)));

    console.log(`pageSize: ${pageSize}, pageIndex: ${pageIndex}`);
    return new Observable(subscriber => {
      subscriber.next(buildData);
    });
  }

  getThisLecturers(id: number): Observable<iLecturers> {
    return new Observable(subscriber => {
      subscriber.next(testData.records[id]);
    });
  }
}
