import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import {RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { VehicleMakesComponent } from './vehicle-makes/vehicle-makes.component';
import { VehicleMakeComponent } from './vehicle-makes/vehicle-make/vehicle-make.component';
import { VehicleMakeListComponent } from './vehicle-makes/vehicle-make-list/vehicle-make-list.component';
import {HomeComponent} from './home/home.component';
import {PageNotFoundComponent} from './Others/pageNotFound.component';
import {ToastrModule} from 'ngx-toastr';
import { VehicleModelsComponent } from './vehicle-models/vehicle-models.component';
import { VehicleModelComponent } from './vehicle-models/vehicle-model/vehicle-model.component';
import {VehicleModelListComponent} from './vehicle-models/vehicle-model-list/vehicle-model-list.component';

const appRoutes: Routes = [
{path: 'home', component: HomeComponent},
{path: 'vehiclemakes', component: VehicleMakesComponent},
{path: 'vehiclemodels', component: VehicleModelsComponent},
{path: '', redirectTo:'/home', pathMatch: 'full'},
{path: '**', component: PageNotFoundComponent},
];

@NgModule({
  declarations: [
    AppComponent,
    VehicleMakesComponent,
    VehicleMakeComponent,
    VehicleMakeListComponent,
    HomeComponent,
    PageNotFoundComponent,
    VehicleModelsComponent,
    VehicleModelComponent,
    VehicleModelListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
