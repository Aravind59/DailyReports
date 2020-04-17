import { Component, OnInit } from '@angular/core';
import { StationService } from '../Services/station.service';
import { Station } from '../Models/Station';
// import { ToastrService } from "ngx-toastr";

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrls: ['./stations.component.css']
})
export class StationsComponent implements OnInit {  
  stationsList : Station[];
  constructor(private stationsService: StationService) { }
  displayedColumns: string[] = ['name', 'address', 'mobileNumber', 'stationCode'];
  ngOnInit() {
    console.log("Emtered into stations component");
    this.getStationsList();
  }
  
  getStationsList(){
    this.stationsService.getStations().subscribe((response : any) => {
      console.log(response);
      if(response.success){
       this.stationsList = response.data;
      }else{
        var validationmessage = response.apiResponseMessages[0].message;
        // this.toastr.error(validationmessage);
      }
    })
  }

}

