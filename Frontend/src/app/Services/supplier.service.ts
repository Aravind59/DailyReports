import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
var baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http : HttpClient) { 
    
  }

   
  getSuppliers(){
    console.log(baseUrl);
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.get(baseUrl + "SuppliersApi/GetSuppliers", httpOptions)
  }

  upsertSupplier(supplier: any){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post(baseUrl + "SuppliersApi/UpsertSupplier", supplier, httpOptions);
  }

  deleteSupplier(suplierId){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.delete(baseUrl + "SuppliersApi/DeleteSupplier?supplierId=" + suplierId, httpOptions);
  }
}
