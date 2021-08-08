import { PaginationComponent } from './shared/pagination.component';
import { AppErrorHandler } from './app.error-handler';
import { VehicleService } from '../services/vehicle.service';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { AuthModule } from '@auth0/auth0-angular';
import { AuthbuttonComponent } from './authbutton/authbutton.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { TodoFormsComponent } from './todo-forms/todo-forms.component';
import { VoteComponent } from './vote/vote.component';
//import { ToastyModule } from 'ng2-toasty';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    VehicleFormComponent,
    VehicleListComponent,
    PaginationComponent,
    AuthbuttonComponent,
    UserprofileComponent,
    TodoFormsComponent,
    VoteComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    //ToastyModule.forRoot(),
    AuthModule.forRoot({
      domain: 'dagveg.us.auth0.com',
      clientId: 'sgLxUv12iHdCA8yAx1lCQCY0K8qNxniz'
    }),
    HttpClientModule,
    FormsModule,
    
    RouterModule.forRoot([
      { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
      { path: 'vehicles/new', component: VehicleFormComponent },
      { path: 'vehicles/:id', component: VehicleFormComponent },
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'vehicles', component: VehicleListComponent },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [
   { provide: ErrorHandler, useClass: AppErrorHandler },
    VehicleService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
 
 }
