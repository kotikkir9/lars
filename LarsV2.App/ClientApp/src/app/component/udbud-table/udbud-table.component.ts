import { AfterViewChecked, AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { merge, of } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { iCourses } from 'src/app/DTO/courses';
import { iCoursesSearchParmas } from 'src/app/DTO/coursesSearchParmas';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';
import { CoursesService, iCoursesServiceData } from 'src/app/service/courses.service';

export interface iUdbudTableInput {
  filterData: iEducationSubject;
  searchData: string;
  fromDate: string;
  toDate: string;
}

export class NullUdbudTableInput implements iUdbudTableInput {
  filterData: iEducationSubject;
  searchData: string;
  fromDate: string;
  toDate: string;

  constructor() {
    this.filterData = new NullEducationSubject;
    this.fromDate = "";
    this.toDate = "";
    this.searchData = "";
  }
}

@Component({
  selector: 'app-udbud-table',
  templateUrl: './udbud-table.component.html',
  styleUrls: ['./udbud-table.component.scss']
})
export class UdbudTableComponent implements AfterViewInit, AfterViewChecked {

  udbudTableInput: iUdbudTableInput = new NullUdbudTableInput;

  inputDataChanges = new EventEmitter<void>();

  @Input() set _udbudTableInputData(data: iUdbudTableInput) {
    this.udbudTableInput = data;
    this.inputDataChanges.emit();
  };

  displayedColumns: string[] = ['fag', 'uddannelse', 'underviser', 'status', 'startdato', 'slutdato'];
  dataSource = new MatTableDataSource<iCourses>();

  isLoadingResults: boolean = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private coursesService: CoursesService, private changeRef: ChangeDetectorRef) { }

  ngAfterViewChecked(): void {
    this.changeRef.detectChanges();
  }

  ngAfterViewInit(): void {
    merge(this.paginator.page, this.inputDataChanges)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;

          let parmeter: iCoursesSearchParmas = {
            pageSize: this.paginator.pageSize,
            pageIndex: this.paginator.pageIndex,
            filter: this.udbudTableInput.filterData,
            search: this.udbudTableInput.searchData,
            fromDate: this.udbudTableInput.fromDate,
            toDate: this.udbudTableInput.toDate
          }

          return this.coursesService.getData(parmeter)
            .pipe(catchError(() => of(null)));

        }),
        map((data: iCoursesServiceData) => {
          this.isLoadingResults = false;

          this.paginator.length = data.metadata.totalCount;
          return data.records;
        }
        )
      )
      .subscribe(data => { this.dataSource.data = data });
  }

}
