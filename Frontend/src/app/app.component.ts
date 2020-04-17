import { Component } from '@angular/core';
import { LoginService } from './Services/login.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'daily-reports';
  isLoggedIn$: Observable<boolean>;   
  constructor(private loginService: LoginService){

  }
  ngOnInit() {
    this.isLoggedIn$ = this.loginService.isLoggedIn;
  }

}
