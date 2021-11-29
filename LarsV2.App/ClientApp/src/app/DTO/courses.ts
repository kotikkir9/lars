import { iLecturers } from "./lecturers";
import { iEducationSubjectObject } from "./subject";

export interface iCourses {
	id: number;
	// subject: iSubject;
	lecturer: iLecturers
}