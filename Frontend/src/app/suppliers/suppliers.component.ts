import { Component, OnInit } from '@angular/core';
import { SupplierService } from '../Services/supplier.service';
import { MatDialog } from '@angular/material';
import { AddSupplierComponent } from './dialogs/add-supplier/add-supplier.component';
import { ConfirmationDialogComponent } from '../Common-dialogs/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit {
  suppliersList: any[];
  displayedColumns: string[] = ['logNumber', 'firstName', 'lastName', 'address', 'mobileNumber', 'action'];
  constructor(private supplierService: SupplierService, private dialog: MatDialog) { }

  ngOnInit() {
    this.getSuppliers();
  }

  
  getSuppliers(){
        
    this.supplierService.getSuppliers().subscribe((response : any) => {
      console.log(response);
      if(response.success){
       this.suppliersList = response.data;
      }else{
        var validationmessage = response.apiResponseMessages[0].message;
        // this.toastr.error(validationmessage);
      }
    })
  }

  
  openSupplierDialog(supplier) {
    const dialogRef = this.dialog.open(AddSupplierComponent, {
      height: "70%",
      hasBackdrop: true,
      // panelClass: 'company-registration-container',
      direction: "ltr",
      data: {supplier},
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log("The dialog was closed");
      this.getSuppliers();
    });
  }
deleteSuplier(supplierId){
  this.supplierService.deleteSupplier(supplierId).subscribe(response => {
 this.getSuppliers();
  })
}
  deletePopup(supplierId){
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
    
    });
    dialogRef.afterClosed().subscribe(result => {    
     if(result){
      this.deleteSuplier(supplierId);
     }
    
    })
  }


}
