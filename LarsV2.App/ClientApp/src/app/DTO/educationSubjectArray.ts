import { iEducationSubjectObject } from "./educationSubject";

/** Insterface til uddannelse */
export interface iEducationSubjectArray {
	/** Uddannelse */
	education: string;
	/** Alle fag */
	subjects: iEducationSubjectObject[];
}