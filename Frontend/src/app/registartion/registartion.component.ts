import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material'
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService } from '../Services/login.service';

@Component({
  selector: 'app-registartion',
  templateUrl: './registartion.component.html',
  styleUrls: ['./registartion.component.css']
})
export class RegistartionComponent implements OnInit {
  registrationForm: FormGroup;
  validationmessage: string;
  constructor(public dialogRef: MatDialogRef<RegistartionComponent>, private loginService: LoginService) { }

  ngOnInit() {
    this.clearForm();
  }

  registerUser(){
 var user = this.registrationForm.value;
 user.isAdmin = true;
  this.loginService.registerUser(user).subscribe((response: any) => {
    if(response.success){
      this.closeRegistrationFormPopup();
    }else{
      var validationmessage = response.apiResponseMessages[0].message;
      // this.toastr.error(validationmessage);
    }
  })
  }

  closeRegistrationFormPopup() {
    this.dialogRef.close();
}

  clearForm() {
    // this.isAnyOperationIsInprogress = false;
    this.registrationForm = new FormGroup({
        stationName: new FormControl(null,
            Validators.compose([
                Validators.required,
            ])
        ),
        address: new FormControl(null,
          Validators.compose([
              Validators.required,
          ])
      ),
        email: new FormControl(null,
            Validators.compose([
                Validators.required,
                Validators.email,
                Validators.pattern('^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$')
            ])
        ),
        password: new FormControl(null,
            Validators.compose([
                Validators.required,
            ])
        ),
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
        userName: new FormControl(null,
          Validators.compose([
              Validators.required,
          ]),
          
      ),
      mobileNumber: new FormControl(null,
        Validators.compose([
            Validators.required,
        ]),
        
    ),
    stationCode: new FormControl(null,
      Validators.compose([
          Validators.required,
      ]),
      
  )
    })
  }
}
