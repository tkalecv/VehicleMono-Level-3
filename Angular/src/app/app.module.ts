import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { VehicleMakesComponent } from './vehicle-makes/vehicle-makes.component';
import { VehicleMakeComponent } from './vehicle-makes/vehicle-make/vehicle-make.component';
import { VehicleMakeListComponent } from './vehicle-makes/vehicle-make-list/vehicle-make-list.component';
import {ToastrModule} from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    VehicleMakesComponent,
    VehicleMakeComponent,
    VehicleMakeListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
