import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OpretUdbudComponent } from './page/opret-udbud/opret-udbud.component';


const routes: Routes = [
  {path: "opret", component: OpretUdbudComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
