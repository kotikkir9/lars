import { iEducationSubject } from "./educationSubject";

export interface iCoursesSearchParmas {
	pageSize: number;
	pageIndex: number;
	filter: iEducationSubject;
	search: string;
	fromDate: string;
	toDate: string;
}

// export class CoursesSearchParmas implements iCoursesSearchParmas {
// 	pageSize: number;
// 	pageIndex: number;
// 	filter: iEducationSubject;
// 	search: string;
// 	fromDate: string;
// 	toDate: string;

// 	constructor(pageSize: number, pageIndex: number, fromDate: string, toDate: string, filter:iEducationSubject, search: string){
// 		this.pageSize = pageSize;
// 		this.pageIndex = pageIndex;
// 		this.fromDate = fromDate;
// 		this.toDate = toDate;
// 		this.filter = filter;
// 		this.search = search;
// 	}
// }

// export class CoursesSearchParmasSimple extends CoursesSearchParmas {
// 	constructor(pageSize: number, pageIndex: number, filter:iEducationSubject = new NullEducationSubject, search: string = ""){
// 		super()
// 	}
// }