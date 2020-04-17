import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../Services/reports.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AddReportComponent } from './add-report/add-report.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  reportsList: any[];
  displayedColumns: string[] = ['logNumber', 'quantity', 'percentage', 'price', 'action'];
  constructor(public reports : ReportsService, private dialog: MatDialog) { }

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

  
  openReportsDialog(report) {
    const dialogRef = this.dialog.open(AddReportComponent, {
      height: "70%",
      hasBackdrop: true,
      // panelClass: 'company-registration-container',
      direction: "ltr",
      data: {report},
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log("The dialog was closed");
      this.getReports();
    });
  }
}
