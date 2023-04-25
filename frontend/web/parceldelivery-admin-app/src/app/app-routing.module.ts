import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddWorkingDaysComponent } from './pages/working/add-working-days/add-working-days.component';
import { HomeComponent } from './pages/home/home.component';
import { TimesheetComponent } from './pages/working/timesheet/timesheet.component';
import { VehicleListComponent } from './pages/vehicle/vehicle-list/vehicle-list.component';
import { AddNewVehicleComponent } from './pages/vehicle/add-new-vehicle/add-new-vehicle.component';
import { VehicleUsageListComponent } from './pages/vehicle/vehicle-usage-list/vehicle-usage-list.component';
import { ShippingRequestListComponent } from './pages/shipping-request/shipping-request-list/shipping-request-list.component';
import { AcceptedShippingRequestListComponent } from './pages/shipping-request/accepted-shipping-request-list/accepted-shipping-request-list.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'add-working-days',
    component: AddWorkingDaysComponent,
    canActivate: [AuthGuard],
  },
  { path: 'timesheet', component: TimesheetComponent },
  { path: 'vehicles', component: VehicleListComponent },
  { path: 'add-new-vehicle', component: AddNewVehicleComponent },
  { path: 'vehicleUsages', component: VehicleUsageListComponent },
  { path: 'shipping-requests', component: ShippingRequestListComponent },
  {
    path: 'accepted-shipping-requests',
    component: AcceptedShippingRequestListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
