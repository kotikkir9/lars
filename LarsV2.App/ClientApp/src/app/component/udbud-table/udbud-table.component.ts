import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-udbud-table',
  templateUrl: './udbud-table.component.html',
  styleUrls: ['./udbud-table.component.scss']
})
export class UdbudTableComponent implements OnInit {

  displayedColumns: string[] = ['name', 'isExternal', 'email', 'phoneNumber'];
  dataSource = new MatTableDataSource<iLecturers>();

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor() { }

  ngOnInit(): void {
  }

}
