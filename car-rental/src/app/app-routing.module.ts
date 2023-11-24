import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AuthenticationGuard } from './guards/authentication.guard';
import { HomePageComponent } from './components/home-page/home-page.component';
import { ViewCarsComponent } from './components/view-cars/view-cars.component';

const routes: Routes = [
      { 
        path: '', 
        component: HomePageComponent 
      },
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'edit-car/:id',
        component: HomePageComponent,
        canActivate: [AuthenticationGuard],
      },
      {
        path: 'view-cars',
        component: ViewCarsComponent,
        canActivate: [AuthenticationGuard]
      },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}