import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { WrapperComponent } from './components/wrapper/wrapper.component';
import { AuthenticationGuard } from './guards/authentication.guard';
import { HomePageComponent } from './components/home-page/home-page.component';

const routes: Routes = [
  {
    path: '',
    component: WrapperComponent,
    children: [
      { 
        path: 'home', 
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
        component: HomePageComponent,
        canActivate: [AuthenticationGuard]
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}