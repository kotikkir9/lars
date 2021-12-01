export interface iSubject{
	id: number | null;
	title: string;
	education: string;
	description: string;
}

export class Subject implements iSubject {
	id: number | null;
	title: string;
	education: string;
	description: string;
	
	constructor(id: number | null, title: string, education: string, description: string) {
		this.id = id;
		this.title = title;
		this.education = education;
		this.description = description;
	}
}

export class NullSubject extends Subject {
	constructor(){
		super(null, "", "", "");
	}
}