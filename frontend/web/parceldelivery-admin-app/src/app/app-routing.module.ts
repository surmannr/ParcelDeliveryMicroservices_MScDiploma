import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AcceptedShippingRequestListComponent } from './pages/shipping-requests/accepted-shipping-request-list/accepted-shipping-request-list.component';
import { ShippingRequestListComponent } from './pages/shipping-requests/shipping-request-list/shipping-request-list.component';
import { AddNewVehicleComponent } from './pages/vehicles/add-new-vehicle/add-new-vehicle.component';
import { TimesheetComponent } from './pages/workings/timesheet/timesheet.component';
import { VehiclesListComponent } from './pages/vehicles/vehicles-list/vehicles-list.component';
import { VehicleUsagesListComponent } from './pages/vehicles/vehicle-usages-list/vehicle-usages-list.component';
import { AddNewWorkingDaysComponent } from './pages/workings/add-new-working-days/add-new-working-days.component';
import { authGuard } from './auth/auth.guard';
import { AddNewVehicleusageComponent } from './pages/vehicles/add-new-vehicleusage/add-new-vehicleusage.component';
import { CurrencyComponent } from './pages/others/currency/currency.component';
import { PaymentMethodComponent } from './pages/others/payment-method/payment-method.component';
import { ShippingMethodComponent } from './pages/others/shipping-method/shipping-method.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'add-working-days',
    component: AddNewWorkingDaysComponent,
    canActivate: [authGuard],
  },
  {
    path: 'timesheet',
    component: TimesheetComponent,
    canActivate: [authGuard],
  },
  {
    path: 'vehicles',
    component: VehiclesListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'add-new-vehicle',
    component: AddNewVehicleComponent,
    canActivate: [authGuard],
  },
  {
    path: 'vehicleUsages',
    component: VehicleUsagesListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'add-new-vehicleUsages',
    component: AddNewVehicleusageComponent,
    canActivate: [authGuard],
  },
  {
    path: 'shipping-requests',
    component: ShippingRequestListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'accepted-shipping-requests',
    component: AcceptedShippingRequestListComponent,
    canActivate: [authGuard],
  },
  {
    path: 'others/currency',
    component: CurrencyComponent,
    canActivate: [authGuard],
  },
  {
    path: 'others/payment-option',
    component: PaymentMethodComponent,
    canActivate: [authGuard],
  },
  {
    path: 'others/shipping-option',
    component: ShippingMethodComponent,
    canActivate: [authGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
