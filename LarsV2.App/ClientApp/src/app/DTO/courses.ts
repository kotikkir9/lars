import { iLecturers } from "./lecturers";
import { iSubject } from "./subject";
export interface iCourses {
	id: number;
	subject: iSubject;
	lecturer: iLecturers;
	description: string;
	startDate: string;
	endDate: string;
	courseDates: iCourseDate[];
}

export interface iCourseDate {
	courseId: number;
	courseDateTime: string;
}