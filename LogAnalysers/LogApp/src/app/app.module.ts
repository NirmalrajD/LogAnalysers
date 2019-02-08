import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatNativeDateModule} from '@angular/material';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {LogMaterialModule} from './shared/material-module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LogDataTableComponent } from './log-data-table/log-data-table.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LayoutComponent } from './layout/layout.component';
import { ChartsComponent } from './charts/charts.component';
import { UploadlogsComponent } from './uploadlogs/uploadlogs.component';


@NgModule({
  declarations: [
    AppComponent,
    LogDataTableComponent,
    LayoutComponent,
    ChartsComponent,
    UploadlogsComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    LogMaterialModule,
    MatNativeDateModule,
    ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
