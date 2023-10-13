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
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatChipsModule } from '@angular/material/chips';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';

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
import { DateFilterComponent } from './components/filter/date-filter/date-filter.component';
import { StringFilterComponent } from './components/filter/string-filter/string-filter.component';
import { SaveDialogSheetComponent } from './dialogs/save-dialog-sheet/save-dialog-sheet.component';
import { DeleteDialogSheetComponent } from './dialogs/delete-dialog-sheet/delete-dialog-sheet.component';
import { AddNewVehicleusageComponent } from './pages/vehicles/add-new-vehicleusage/add-new-vehicleusage.component';
import { NumberFilterComponent } from './components/filter/number-filter/number-filter.component';
import {
  NgxMaskDirective,
  NgxMaskPipe,
  provideEnvironmentNgxMask,
} from 'ngx-mask';
import { AddressPipe } from './pipes/address.pipe';
import { AddressFilterComponent } from './components/filter/address-filter/address-filter.component';
import { StatusPipe } from './pipes/status.pipe';
import { StatusEditComponent } from './components/edit/status-edit/status-edit.component';
import { BillingsComponent } from './dialogs/billings/billings.component';
import { ShippingsComponent } from './dialogs/shippings/shippings.component';
import { CurrencyComponent } from './pages/others/currency/currency.component';
import { PaymentMethodComponent } from './pages/others/payment-method/payment-method.component';
import { ShippingMethodComponent } from './pages/others/shipping-method/shipping-method.component';
import { CurrencyEditComponent } from './components/edit/currency-edit/currency-edit.component';
import { PaymentMethodEditComponent } from './components/edit/payment-method-edit/payment-method-edit.component';
import { ShippingMethodEditComponent } from './components/edit/shipping-method-edit/shipping-method-edit.component';
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
    DateFilterComponent,
    StringFilterComponent,
    SaveDialogSheetComponent,
    DeleteDialogSheetComponent,
    AddNewVehicleusageComponent,
    NumberFilterComponent,
    AddressPipe,
    AddressFilterComponent,
    StatusPipe,
    StatusEditComponent,
    BillingsComponent,
    ShippingsComponent,
    CurrencyComponent,
    PaymentMethodComponent,
    ShippingMethodComponent,
    CurrencyEditComponent,
    PaymentMethodEditComponent,
    ShippingMethodEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    OAuthModule.forRoot(),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    NgxMaskDirective,
    NgxMaskPipe,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatListModule,
    MatPaginatorModule,
    MatTableModule,
    MatProgressBarModule,
    MatSortModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatInputModule,
    MatChipsModule,
    MatBottomSheetModule,
    MatSnackBarModule,
    MatCardModule,
    MatCheckboxModule,
    MatSelectModule,
    MatDialogModule,
  ],
  providers: [provideEnvironmentNgxMask()],
  bootstrap: [AppComponent],
})
export class AppModule {}
