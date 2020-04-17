import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms'
import { LoginService } from '../Services/login.service'
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';
import { RegistartionComponent } from '../registartion/registartion.component';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  validationMessage: string;
  form: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });
  constructor(public loginService: LoginService,public dialog: MatDialog, public router : Router) { }

  ngOnInit() {
  }

  login(){
    this.validationMessage = null;
    if (this.form.valid){
      this.loginService.login(this.form.get("username").value, this.form.get("password").value).subscribe((response: any) => {
        console.log(response);
        if(response.access_token != null){
         
          this.router.navigate(['suppliers']);
        }else{
this.validationMessage = "The given uername or password are wrong!"
        }
       
      },
      (errpr: HttpErrorResponse ) =>{
   console.log(errpr);
      })
    }

  }


  registrationForm() {
    const dialogRef = this.dialog.open(RegistartionComponent, {
      height: "70%",
      hasBackdrop: true,
      // panelClass: 'company-registration-container',
      direction: "ltr",
      data: {},
      disableClose: true,
    });
    dialogRef.afterClosed().subscribe(() => {
      console.log("The dialog was closed");
    });
  }

  
}
