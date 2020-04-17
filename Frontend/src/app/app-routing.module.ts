import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StationsComponent } from './stations/stations.component';
import { ReportsComponent } from './reports/reports.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { LogoutComponent } from './logout/logout.component';
import { SuppliersComponent } from './suppliers/suppliers.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'stations', component: StationsComponent, canActivate: [AuthGuard]  },
  { path: 'reports', component: ReportsComponent, canActivate: [AuthGuard] },
  { path: 'logout', component: LogoutComponent, canActivate: [AuthGuard]  },
  { path: 'suppliers', component: SuppliersComponent, canActivate: [AuthGuard]  },
  { path: "**", component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
