import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

  constructor(private http: HttpClient) { }


  getData(): iLecturersServiceData {
    return {
      metadata: {
        totalCount: 13,
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
          phoneNumber: "+4512345678",
          cvPath: null,
          imagePath: null,
          isExternal: false,
          knowledge: null,
          lecturerSubjects: null
        },
        {
          id: 2,
          firstName: "James",
          lastName: "Hetfield",
          email: "jameshetfield@metallica.com",
          phoneNumber: "+4569696969",
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
          phoneNumber: "+4511111111",
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
          phoneNumber: "+4598765432",
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
          phoneNumber: "+4544444444",
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
          phoneNumber: "+4555555555",
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
          phoneNumber: "+4566666666",
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
          phoneNumber: "+4577777777",
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
          phoneNumber: "+4588888888",
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
          phoneNumber: "+4599999999",
          cvPath: null,
          imagePath: null,
          isExternal: false,
          knowledge: null,
          lecturerSubjects: null
        }
      ]
    }
  }
}
