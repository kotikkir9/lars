import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { iLecturers, NullLecturers } from 'src/app/DTO/lecturers';
import { iLecturersServiceData, LecturersService } from 'src/app/service/lecturers.service';

@Component({
  selector: 'app-lecturers-table',
  templateUrl: './lecturers-table.component.html',
  styleUrls: ['./lecturers-table.component.scss']
})
export class LecturersTableComponent implements AfterViewInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'isExternal', 'email', 'phoneNumber'];
  dataSource = new MatTableDataSource<iLecturers>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private lecturersService: LecturersService) { }

  ngAfterViewInit(): void {
    this.loadData();
  }

  loadData() {
    let data: iLecturersServiceData = this.lecturersService.getData(this.paginator.pageSize,this.paginator.pageIndex);
    this.dataSource.data = data.records;
    this.paginator.length = data.metadata.totalCount;
  }

}
