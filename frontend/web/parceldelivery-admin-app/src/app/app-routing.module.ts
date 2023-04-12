import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddWorkingDaysComponent } from './pages/working/add-working-days/add-working-days.component';
import { HomeComponent } from './pages/home/home.component';
import { TimesheetComponent } from './pages/working/timesheet/timesheet.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add-working-days', component: AddWorkingDaysComponent },
  { path: 'timesheet', component: TimesheetComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
