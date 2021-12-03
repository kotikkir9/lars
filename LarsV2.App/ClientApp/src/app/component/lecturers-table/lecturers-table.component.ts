import { AfterViewChecked, AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { merge, of } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { iEducationSubject, NullEducationSubject } from 'src/app/DTO/educationSubject';
import { iLecturer } from 'src/app/DTO/lecturers';
import { iLecturersServiceData, LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-lecturers-table',
  templateUrl: './lecturers-table.component.html',
  styleUrls: ['./lecturers-table.component.scss']
})
export class LecturersTableComponent implements AfterViewInit, AfterViewChecked {
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

  isLoadingResults: boolean = false;

  displayedColumns: string[] = ['name', 'isExternal', 'email', 'phoneNumber'];
  dataSource = new MatTableDataSource<iLecturer>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private lecturersService: LecturersService, private changeRef: ChangeDetectorRef) { }

  ngAfterViewChecked(): void {
    this.changeRef.detectChanges();
  }

  ngAfterViewInit(): void {
    merge(this.paginator.page, this.filerOrSearchChanges)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;

          return this.lecturersService.getData(this.paginator.pageSize, this.paginator.pageIndex, this.filterData, this.searchData)
            .pipe(catchError(() => of(null)));

        }),
        map((data: iLecturersServiceData) => {
          this.isLoadingResults = false;

          this.paginator.length = data.metadata.totalCount;
          return data.records;
        }
        )
      )
      .subscribe(data => { this.dataSource.data = data });
  }

}

