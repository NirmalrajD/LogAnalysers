import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LogDataTableComponent } from './log-data-table/log-data-table.component';
import { AppComponent } from './app.component';
import {UploadlogsComponent} from './uploadlogs/uploadlogs.component'

const routes: Routes = [
  {path:'',component: AppComponent},
{
    path:'viewDetails',component: LogDataTableComponent
   },
   {
     path:'uploadLogs',component: UploadlogsComponent
   }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
