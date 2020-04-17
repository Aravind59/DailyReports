import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
var baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root'
})
export class StationService {

  constructor(public http: HttpClient) { }

   
  getStations(){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.get(baseUrl + "StationsApi/GetStationsList", httpOptions)
  }
}
