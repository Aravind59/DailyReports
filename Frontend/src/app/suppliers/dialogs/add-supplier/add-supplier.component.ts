import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { SupplierService } from 'src/app/Services/supplier.service';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.css']
})
export class AddSupplierComponent implements OnInit {
  supplierForm: FormGroup;
  supplier: any;
  constructor(public dialogRef: MatDialogRef<AddSupplierComponent>, private supplierService: SupplierService, @Inject(MAT_DIALOG_DATA) public data: any) { 
    console.log(data);
    this.supplier = data.supplier;
   
  }

  ngOnInit() {
    this.clearForm();
    if(this.supplier != null){      
      this.supplierForm.patchValue(this.supplier);          
    }
   
  }

  saveSupplier(){
    var supplier = this.supplierForm.value;
    supplier.stationId = 1;
    if(this.supplier != null){
      supplier.id = this.supplier.id;
      supplier.isActive = true;
    }
    
    this.supplierService.upsertSupplier(supplier).subscribe((response : any) => {
      console.log(response);
      if(response.success){
      //  this.suppliersList = response.data;
      this.closeSupplierForm();
      }else{
        var validationmessage = response.apiResponseMessages[0].message;
        // this.toastr.error(validationmessage);
      }
    })
  }

  
  closeSupplierForm(){
    this.dialogRef.close();
  }

  clearForm1() {
    // this.isAnyOperationIsInprogress = false;
    this.supplierForm = new FormGroup({
        firstName: new FormControl(this.supplier.firstName,
            Validators.compose([
                Validators.required,
            ])
        ),
        lastName: new FormControl(this.supplier.lastName,
          Validators.compose([
              Validators.required,
          ])
      ),
        address: new FormControl(this.supplier.address,
          Validators.compose([
              Validators.required,
          ])
      ),               
      mobileNumber: new FormControl(this.supplier.mobileNumber,
        Validators.compose([
            Validators.required,
        ]),
        
    ),
    logNumber: new FormControl(this.supplier.logNumber,
      Validators.compose([
          Validators.required,
      ]),
      
  )
    })
  }

  
  clearForm() {
    // this.isAnyOperationIsInprogress = false;
    this.supplierForm = new FormGroup({
        firstName: new FormControl(null,
            Validators.compose([
                Validators.required,
            ])
        ),
        lastName: new FormControl(null,
          Validators.compose([
              Validators.required,
          ])
      ),
        address: new FormControl(null,
          Validators.compose([
              Validators.required,
          ])
      ),               
      mobileNumber: new FormControl(null,
        Validators.compose([
            Validators.required,
        ]),
        
    ),
    logNumber: new FormControl(null,
      Validators.compose([
          Validators.required,
      ]),
      
  )
    })
  }
}
