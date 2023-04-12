import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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

@NgModule({
  declarations: [
    AppComponent,
    AddWorkingDaysComponent,
    HeaderMenuComponent,
    FooterComponent,
    HomeComponent,
    TimesheetComponent,
    DaysFromIntArrayPipe,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
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
  ],
  providers: [ConfirmationService, MessageService],
  bootstrap: [AppComponent],
})
export class AppModule {}
