/** Insterface til fag*/
export interface iEducationSubjectObject {
	id: number;
	/** Fag */
	subject: string;
}

/** Insterface til uddannelse.
 * Hvor fag er i array */
export interface iEducationSubjectArray {
	/** Uddannelse */
	education: string;
	/** Alle fag */
	subjects: iEducationSubjectObject[];
}

export interface iEducationSubject {
	/** Uddannelse */
	education: string;
	/** fag */
	subject: iEducationSubjectObject;
}

export class EducationSubject implements iEducationSubject {
	education: string;
	subject: iEducationSubjectObject;
	
	constructor(education: string, subject: string, subjectId: number = -1){
		this.education = education;
		this.subject = {
			id: subjectId,
			subject: subject
		};
	}
}

export class NullEducationSubject extends EducationSubject {
	constructor(){
		super("","", -1);
	}
}