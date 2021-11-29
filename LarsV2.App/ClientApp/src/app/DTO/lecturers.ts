import { iCourses } from "./courses";
import { iSubject } from "./subject";

export interface iLecturers {
	id: number
	name: string;
	email: string;
	phoneNumber: string;
	cvPath: string;
	imagePath: string;
	isExternal: boolean;
	subjects: iSubject[];
	courses: iCourses[];
}

export class Lecturers implements iLecturers {
	id: number;
	name: string;
	email: string;
	phoneNumber: string;
	cvPath: string;
	imagePath: string;
	isExternal: boolean;
	subjects: iSubject[];
	courses: iCourses[];

	constructor(id: number, name: string, email: string, phoneNumber: string, isExternal: boolean, cvPath: string, imagePath: string, subjects: iSubject[], courses: iCourses[]) {
		this.id = id;
		this.name = name;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.cvPath = cvPath;
		this.imagePath = imagePath;
		this.isExternal = isExternal;
		this.subjects = subjects;
		this.courses = courses;
	}
	
}

export class NullLecturers extends Lecturers {
	constructor(){
		super(-1,"","","",false, "", "", [], []);
	}
}