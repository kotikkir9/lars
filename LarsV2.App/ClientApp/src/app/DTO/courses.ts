import { iLecturer, NullLecturer } from "./lecturers";
import { iSubject, NullSubject } from "./subject";

interface iCoursesExtends {
	subject: iSubject;
	lecturer: iLecturer;
	description: string;
}

export interface iCoursesSend extends iCoursesExtends{
	courseDates: string[]
}

export interface iCourses extends iCoursesExtends {
	id: number;
	startDate: string;
	endDate: string;
	courseDates: iCourseDate[];
}

export interface iCourseDate {
	courseId: number;
	courseDateTime: string;
}

class Courses implements iCourses {
	id: number;
	subject: iSubject;
	lecturer: iLecturer;
	description: string;
	startDate: string;
	endDate: string;
	courseDates: iCourseDate[];

	constructor(id: number, subject: iSubject, lecturer: iLecturer, description: string, startDate: string, endDate: string, courseDates: iCourseDate[]){
		this.id = id;
		this.subject = subject;
		this.lecturer = lecturer;
		this.description = description;
		this.startDate = startDate;
		this.endDate = endDate;
		this.courseDates = courseDates;
	}
}

export class NullCourses extends Courses {
	constructor(){
		super(-1, new NullSubject, new NullLecturer, "", "", "", []);
	}
}