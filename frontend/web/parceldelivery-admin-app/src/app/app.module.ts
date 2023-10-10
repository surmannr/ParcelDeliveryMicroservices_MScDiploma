import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatProgressBarModule } from '@angular/material/progress-bar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './frame/header/header.component';
import { FooterComponent } from './frame/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { AcceptedShippingRequestListComponent } from './pages/shipping-requests/accepted-shipping-request-list/accepted-shipping-request-list.component';
import { ShippingRequestListComponent } from './pages/shipping-requests/shipping-request-list/shipping-request-list.component';
import { AddNewVehicleComponent } from './pages/vehicles/add-new-vehicle/add-new-vehicle.component';
import { VehiclesListComponent } from './pages/vehicles/vehicles-list/vehicles-list.component';
import { VehicleUsagesListComponent } from './pages/vehicles/vehicle-usages-list/vehicle-usages-list.component';
import { AddNewWorkingDaysComponent } from './pages/workings/add-new-working-days/add-new-working-days.component';
import { TimesheetComponent } from './pages/workings/timesheet/timesheet.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShippingPacksComponent } from './dialogs/shipping-packs/shipping-packs.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OAuthModule } from 'angular-oauth2-oidc';
import { HttpClientModule } from '@angular/common/http';
import { DaysFromIntArrayPipePipe } from './pipes/days-from-int-array.pipe.pipe';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    AcceptedShippingRequestListComponent,
    ShippingRequestListComponent,
    AddNewVehicleComponent,
    VehiclesListComponent,
    VehicleUsagesListComponent,
    AddNewWorkingDaysComponent,
    TimesheetComponent,
    ShippingPacksComponent,
    DaysFromIntArrayPipePipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    OAuthModule.forRoot(),
    HttpClientModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatListModule,
    MatPaginatorModule,
    MatTableModule,
    MatProgressBarModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
