import { iCourses } from "./courses";
import { iSubject } from "./subject";

interface iLecturerExtends {
	id: number
	email: string;
	phoneNumber: string;
	cvPath: string;
	imagePath: string;
	isExternal: boolean;
	subjects: iSubject[];
}

export interface iLecturer extends iLecturerExtends {
	name: string;
	courses: iCourses[];
}

export interface iLecturerSend extends iLecturerExtends {
	firstName: string;
	lastName: string;
}

export interface iLecturer {

}

export class Lecturer implements iLecturer {
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

export class NullLecturer extends Lecturer {
	constructor(){
		super(-1,"","","",false, "", "", [], []);
	}
}