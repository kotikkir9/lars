import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateTeacherPageComponent } from './page/create-teacher-page/create-teacher-page.component';
import { HomePageComponent } from './page/home-page/home-page.component';
import { TestPageComponent } from './page/test-page/test-page.component';


const routes: Routes = [
  {path: "", component: HomePageComponent},
  {path: "opret", component: CreateTeacherPageComponent},
  {path: "test", component: TestPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
