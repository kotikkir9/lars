export interface iLecturers {
	id: number
	firstName: string;
	lastName: string;
	email: string;
	phoneNumber: string;
	cvPath: string;
	imagePath: string;
	isExternal: boolean;
	knowledge: string;
	lecturerSubjects: string;
}

export class Lecturers implements iLecturers {
	id: number;
	firstName: string;
	lastName: string;
	email: string;
	phoneNumber: string;
	cvPath: string;
	imagePath: string;
	isExternal: boolean;
	knowledge: string;
	lecturerSubjects: string;

	constructor(id: number, firstName: string, lastName: string, email: string, phoneNumber: string, isExternal: boolean, cvPath: string, imagePath: string, knowledge: string, lecturerSubjects: string) {
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.email = email;
		this.phoneNumber = phoneNumber;
		this.cvPath = cvPath;
		this.imagePath = imagePath;
		this.isExternal = isExternal;
		this.knowledge = knowledge;
		this.lecturerSubjects = lecturerSubjects;
	}
}

export class NullLecturers extends Lecturers {
	constructor(){
		super(-1,"","","","",false, null, null, null, null);
	}
}