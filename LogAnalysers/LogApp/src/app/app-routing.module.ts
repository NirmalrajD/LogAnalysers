import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LogDataTableComponent } from './log-data-table/log-data-table.component';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';

const routes: Routes = [
  {path:'',component:LayoutComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
