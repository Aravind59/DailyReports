import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
const baseUrl = environment.baseUrl;
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  constructor(public http: HttpClient, private router: Router) { }

  login(username, password){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', "No-Auth": "True" })
    };
    
    return this.http.get(baseUrl + "api/LoginApi/Authenticate?userName=" + username + "&password=" + password, httpOptions)
    .pipe(
      map((response : any) => {
        localStorage.setItem("userToken", response.access_token);
        localStorage.setItem("isUerLoggedIn", "true");
        if(response.access_token != null){
          this.loggedIn.next(true);
        }
        
        return response;
      })
    );
  }
      
registerUser(user : any) {
  
  var data = user;
  const httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json", "No-Auth": "True"})      
  };
  return this.http.post(baseUrl + "LoginApi/RegisterUser", data, httpOptions);
}

logout(){
  localStorage.removeItem("userToken");
    
    this.loggedIn.next(false);
    this.router.navigate(["/login"]);
}

get isLoggedIn() {
  return this.loggedIn.asObservable(); // {2}
}

updateLogin(value){
  this.loggedIn.next(value);
}

}
