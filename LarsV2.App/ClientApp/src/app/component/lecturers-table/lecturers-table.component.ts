import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { merge, of as observableOf } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { iLecturers } from 'src/app/DTO/lecturers';
import { iLecturersServiceData, LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-lecturers-table',
  templateUrl: './lecturers-table.component.html',
  styleUrls: ['./lecturers-table.component.scss']
})
export class LecturersTableComponent implements AfterViewInit {

  isLoadingResults: boolean = false;

  displayedColumns: string[] = ['firstName', 'lastName', 'isExternal', 'email', 'phoneNumber'];
  dataSource = new MatTableDataSource<iLecturers>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private lecturersService: LecturersService) { }

  ngAfterViewInit(): void {
    merge(this.paginator.page)
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;

          return this.lecturersService.getData(this.paginator.pageSize, this.paginator.pageIndex)
            .pipe(catchError(() => observableOf(null)));
        }),
        map((data: iLecturersServiceData) => {
            this.isLoadingResults = false;

            this.paginator.length = data.metadata.totalCount;

            return data.records;
          }
        )
      )
      .subscribe(data => {this.dataSource.data = data});
  }

}

