import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { PersonService } from './services/person.service';
import { TableComponent } from './table/table.component';
import { FullListComponent } from './full-list/full-list.component';
import { EditComponent } from './edit/edit.component';
import { AddressComponent } from './address/address.component';
import { UploadService } from './services/upload.service';
import { AddressService } from './services/address.service';


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    TableComponent,
    FullListComponent,
    EditComponent,
    AddressComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    PersonService,
    UploadService,
    AddressService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
