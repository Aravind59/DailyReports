import { HttpInterceptor, HttpRequest, HttpHandler, HttpUserEvent, HttpEvent, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators"
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       console.log(req.headers);
      if (req.headers.get("No-Auth") == "True")
            return next.handle(req.clone());

        if (localStorage.getItem('userToken') != null) {
            const clonedreq = req.clone({
                headers: req.headers.set("Authorization", "Bearer " + localStorage.getItem('userToken'))
            });
            // return next.handle(clonedreq)
            return next.handle(clonedreq).pipe(tap(
                (err: any) => {
                  if (err instanceof HttpErrorResponse) {
                    console.log(err);
                    console.log('req url :: ' + req.url);
                    if (err.status === 401) {
                      this.router.navigate(['login']);
                    }
                  }
                }
              ));
        }
        else {
            this.router.navigateByUrl('/login');
        }
    }
}