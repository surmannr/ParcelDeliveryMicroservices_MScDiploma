import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OAuthModule } from 'angular-oauth2-oidc';
import { HttpClientModule } from '@angular/common/http';

import { MenubarModule } from 'primeng/menubar';
import { FieldsetModule } from 'primeng/fieldset';
import { DragDropModule } from 'primeng/dragdrop';
import { ButtonModule } from 'primeng/button';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { ToastModule } from 'primeng/toast';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ImageModule } from 'primeng/image';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputMaskModule } from 'primeng/inputmask';
import { CalendarModule } from 'primeng/calendar';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { CardModule } from 'primeng/card';
import { DialogModule } from 'primeng/dialog';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddWorkingDaysComponent } from './pages/working/add-working-days/add-working-days.component';
import { HeaderMenuComponent } from './components/frame/header-menu/header-menu.component';
import { FooterComponent } from './components/frame/footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, MessageService } from 'primeng/api';
import { HomeComponent } from './pages/home/home.component';
import { TimesheetComponent } from './pages/working/timesheet/timesheet.component';
import { DaysFromIntArrayPipe } from './pipes/days-from-int-array.pipe';
import { AddNewVehicleComponent } from './pages/vehicle/add-new-vehicle/add-new-vehicle.component';
import { VehicleListComponent } from './pages/vehicle/vehicle-list/vehicle-list.component';
import { VehicleUsageListComponent } from './pages/vehicle/vehicle-usage-list/vehicle-usage-list.component';
import { ShippingRequestListComponent } from './pages/shipping-request/shipping-request-list/shipping-request-list.component';
import { AcceptedShippingRequestListComponent } from './pages/shipping-request/accepted-shipping-request-list/accepted-shipping-request-list.component';
import { PackagesComponent } from './components/dialog/packages/packages.component';

@NgModule({
  declarations: [
    AppComponent,
    AddWorkingDaysComponent,
    HeaderMenuComponent,
    FooterComponent,
    HomeComponent,
    TimesheetComponent,
    DaysFromIntArrayPipe,
    AddNewVehicleComponent,
    VehicleListComponent,
    VehicleUsageListComponent,
    ShippingRequestListComponent,
    AcceptedShippingRequestListComponent,
    PackagesComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    NgbModule,
    AppRoutingModule,
    FieldsetModule,
    MenubarModule,
    DragDropModule,
    ButtonModule,
    ConfirmPopupModule,
    ToastModule,
    InputTextareaModule,
    ImageModule,
    TableModule,
    InputTextModule,
    CheckboxModule,
    RadioButtonModule,
    InputMaskModule,
    CalendarModule,
    ToggleButtonModule,
    CardModule,
    DialogModule,
    OAuthModule.forRoot(),
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [ConfirmationService, MessageService],
  bootstrap: [AppComponent],
})
export class AppModule {}
