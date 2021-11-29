export interface iSubject{
	id: number;
	title: string;
	education: string;
	description: string;
}

class Subject implements iSubject {
	id: number;
	title: string;
	education: string;
	description: string;
	
	constructor(id: number, title: string, education: string, description: string) {
		this.id = id;
		this.title = title;
		this.education = education;
		this.description = description;
	}
}

export class NullSubject extends Subject {
	constructor(){
		super(-1, "", "", "");
	}
}