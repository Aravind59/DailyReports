import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../Services/reports.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  reportsList: any[];
  displayedColumns: string[] = ['logNumber', 'quantity', 'percentage', 'price'];
  constructor(public reports : ReportsService) { }

  ngOnInit() {
    this.getReports();
  }

  getReports(){
this.reports.getReports().subscribe((response : any) => {
  console.log(response);
  this.reportsList = response.data;
},
(errpr: HttpErrorResponse ) =>{
console.log(errpr);
})
  }
}
