import { AfterViewChecked, AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { merge, of } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { iCourses } from 'src/app/DTO/courses';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';
import { CoursesService, iCoursesServiceData } from 'src/app/service/courses.service';

@Component({
  selector: 'app-udbud-table',
  templateUrl: './udbud-table.component.html',
  styleUrls: ['./udbud-table.component.scss']
})
export class UdbudTableComponent implements AfterViewInit, AfterViewChecked {

  filterData: iEducationSubject = new NullEducationSubject;
  searchData: string = "";
  filerOrSearchChanges = new EventEmitter<void>();

  @Input() set _filterData(data: iEducationSubject) {
    this.filterData = data;
    this.filerOrSearchChanges.emit();
  };

  @Input() set _searchData(data: string) {
    this.searchData = data;
    this.filerOrSearchChanges.emit();
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
    merge(this.paginator.page, this.filerOrSearchChanges)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;

          return this.coursesService.getData(this.paginator.pageSize, this.paginator.pageIndex, this.filterData, this.searchData)
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
