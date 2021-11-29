import { iSubject } from "./subject";

export interface iLecturers {
	id: number
	name: string;
	email: string;
	phoneNumber: string;
	cvPath: string;
	imagePath: string;
	isExternal: boolean;
	subjects?: iSubject[];
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

	constructor(id: number, name: string, email: string, phoneNumber: string, isExternal: boolean, cvPath: string, imagePath: string, subjects: iSubject[]) {
		this.id = id;
		this.name = name;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.cvPath = cvPath;
		this.imagePath = imagePath;
		this.isExternal = isExternal;
		this.subjects = subjects;
	}
	
}

export class NullLecturers extends Lecturers {
	constructor(){
		super(-1,"","","",false, "", "", []);
	}
}