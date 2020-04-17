import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { SupplierService } from 'src/app/Services/supplier.service';
import { filter } from 'rxjs/operators';
import { ReportsService } from 'src/app/Services/reports.service';

@Component({
  selector: 'app-add-report',
  templateUrl: './add-report.component.html',
  styleUrls: ['./add-report.component.css']
})
export class AddReportComponent implements OnInit {
  reportsForm: FormGroup;
  suppliersList: any[];
  report: any;
  constructor(private reportsService: ReportsService ,private supplierService: SupplierService ,private dialogRef: MatDialogRef<AddReportComponent>, @Inject(MAT_DIALOG_DATA) public data: any) { 
    this.report = data.report;
  }

  ngOnInit() {
    this.getSuppliers();
    this.clearForm();
    if(this.report != null){      
      this.reportsForm.patchValue(this.report);          
    }
  
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

 saveReport(){
  var report = this.reportsForm.value;    
  if(this.report != null){
    report.id = this.report.id;
    // report.isActive = true;
  }
   this.reportsService.upsertReport(report).subscribe((response: any) => {
this.closeReportForm();
   })
 }

 
 closeReportForm(){
  this.dialogRef.close();
}

  autoSelectLogNumber(){
    var supplierId = this.reportsForm.get('supplierId').value;
    var supplier = this.suppliersList.filter(supplier => (supplier.id == supplierId));
    this.reportsForm.controls['logNumber'].setValue(supplier[0].logNumber);
console.log(supplier);
  }

  calculatePrice(){
    var quantity = this.reportsForm.get('quantity').value;
    var percentage = this.reportsForm.get('percentage').value;

    var price = quantity * percentage * 50;
    this.reportsForm.controls['price'].setValue(price);
  }
  clearForm() {
    // this.isAnyOperationIsInprogress = false;
    this.reportsForm = new FormGroup({
        price: new FormControl(null,
            Validators.compose([
                Validators.required,
            ])
        ),
        percentage: new FormControl(null,
          Validators.compose([
              Validators.required,
          ])
      ),
                 
      quantity: new FormControl(null,
        Validators.compose([
            Validators.required,
        ]),
        
    ),
    logNumber: new FormControl(null,
      Validators.compose([
          Validators.required,
      ]),
      
  ),
  supplierId: new FormControl(null,
    Validators.compose([
        Validators.required,
    ]),
    
),
  
    })
  }
}
