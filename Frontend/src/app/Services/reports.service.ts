import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
var baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root'
})
export class ReportsService {

  constructor(public http : HttpClient) { }

  
  getReports(){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.get(baseUrl + "DailyReportsApi/GetDailyReports", httpOptions)
  }
  
}
