/** Insterface til uddannelse */
export interface iEducation {
	/** Uddannelse */
	education: string;
	/** Alle fag */
	subjects: iSubject[];
}

/** Insterface til fag*/
export interface iSubject {
	id: number;
	/** Fag */
	subject: string;
}

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
