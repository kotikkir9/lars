import { iSubject } from "./subject";

/** Insterface til uddannelse */
export interface iEducation {
	/** Uddannelse */
	education: string;
	/** Alle fag */
	subjects: iSubject[];
}