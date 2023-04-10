import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MegaMenuModule } from 'primeng/megamenu';
import { FieldsetModule } from 'primeng/fieldset';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddWorkingDaysComponent } from './pages/working/add-working-days/add-working-days.component';
import { HeaderMenuComponent } from './components/frame/header-menu/header-menu.component';
import { FooterComponent } from './components/frame/footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    AddWorkingDaysComponent,
    HeaderMenuComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NgbModule,
    AppRoutingModule,
    FieldsetModule,
    MegaMenuModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
