import { iSubject } from "./subject";

export interface iEducationSubject {
	/** Uddannelse */
	education: string;
	/** fag */
	subject: iSubject;
}

export class EducationSubject implements iEducationSubject {
	education: string;
	subject: iSubject;
	
	constructor(education: string, subject: string, subjectId: number = -1){
		this.education = education;
		this.subject = {
			id: subjectId,
			subject: subject
		};
	}
}