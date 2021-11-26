import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateTeacherPageComponent } from './page/create-teacher-page/create-teacher-page.component';
import { FindLecturersPageComponent } from './page/find-lecturers-page/find-lecturers-page.component';
import { HomePageComponent } from './page/home-page/home-page.component';
import { PageNotFoundComponent } from './page/page-not-found/page-not-found.component';
import { ProfilePageComponent } from './page/profile-page/profile-page.component';
import { TestPageComponent } from './page/test-page/test-page.component';


const routes: Routes = [
  {path: "", component: HomePageComponent},
  {path: "opret", component: CreateTeacherPageComponent},
  {path: "profile/:id", component: ProfilePageComponent},
  {path: "find", component: FindLecturersPageComponent},
  {path: "test", component: TestPageComponent},
  {path: "**", component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
