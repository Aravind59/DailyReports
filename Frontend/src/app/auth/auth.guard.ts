import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../Services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  // isLoggedIn$: Observable<boolean>;   
  constructor(private router: Router, private loginService: LoginService){
    // this.isLoggedIn$ = this.loginService.isLoggedIn;
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if(localStorage.getItem("userToken") != null){     
      this.loginService.updateLogin(true);
return true;
    }else{
      this.router.navigate(["/login"]);
      return false;
    }
return true;
  }
  
}
