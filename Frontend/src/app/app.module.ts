import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider'
import { MatDialogModule } from '@angular/material'
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatTabsModule} from '@angular/material/tabs';
import {MatButtonModule} from '@angular/material/button';
import { AppMenuComponent } from './app-menu/app-menu.component';
import {MatTableModule} from '@angular/material/table';
import { StationsComponent } from './stations/stations.component';
import { ReportsComponent } from './reports/reports.component';
import { LoginComponent } from './login/login.component';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth/authinterceptor';
import { LogoutComponent } from './logout/logout.component';
import { RegistartionComponent } from './registartion/registartion.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { AddSupplierComponent } from './suppliers/dialogs/add-supplier/add-supplier.component';
import { ConfirmationDialogComponent } from './Common-dialogs/confirmation-dialog/confirmation-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    AppMenuComponent,
    StationsComponent,
    ReportsComponent,
    LoginComponent,
    LogoutComponent,
    RegistartionComponent,
    SuppliersComponent,
    AddSupplierComponent,
    ConfirmationDialogComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatTabsModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule,
    FormsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    HttpClientModule,
    MatDialogModule
    
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  entryComponents: [RegistartionComponent, AddSupplierComponent, ConfirmationDialogComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }

