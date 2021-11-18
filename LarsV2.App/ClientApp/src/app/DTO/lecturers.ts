export interface iLecturers {
	firstName: string;
	lastName: string;
	email: string;
	phoneNumber: string;
}

export class Lecturers implements iLecturers {
	firstName: string;
	lastName: string;
	email: string;
	phoneNumber: string;

	constructor(firstName: string, lastName: string, email: string, phoneNumber: string) {
		this.firstName = firstName;
		this.lastName = lastName;
		this.email = email;
		this.phoneNumber = phoneNumber;
	}
}

export class NullLecturers extends Lecturers {
	constructor(){
		super("","","","");
	}
}