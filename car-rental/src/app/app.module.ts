import { WrapperComponent } from './components/wrapper/wrapper.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { CardTripComponent } from './components/card-trip/card-trip.component';
import { CommonModule, DatePipe } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material.module';
import { NgModule } from '@angular/core';
import { HomePageComponent } from './components/home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    WrapperComponent,
    CardTripComponent,
    HomePageComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
  ],
  providers: [
    { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
    { provide: DatePipe }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
