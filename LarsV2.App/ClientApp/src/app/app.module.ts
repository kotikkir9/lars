import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './page/home-page/home-page.component';
import { CreateTeacherPageComponent } from './page/create-teacher-page/create-teacher-page.component';
import { CreateTeacherComponent } from './component/create-teacher/create-teacher.component';
import { EducationService } from './service/education.service';
import { TestPageComponent } from './page/test-page/test-page.component';
import { UddannelseInputComponent } from './component/uddannelse-input/uddannelse-input.component';
import { LecturersService } from './service/lecturers.service';
import { LecturersTableComponent } from './component/lecturers-table/lecturers-table.component';
import { PhonePipe } from './pipe/phone.pipe';
import { ProfilePageComponent } from './page/profile-page/profile-page.component';
import { FindLecturersPageComponent } from './page/find-lecturers-page/find-lecturers-page.component';
import { PageNotFoundComponent } from './page/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    CreateTeacherPageComponent,
    CreateTeacherComponent,
    TestPageComponent,
    UddannelseInputComponent,
    LecturersTableComponent,
    PhonePipe,
    ProfilePageComponent,
    FindLecturersPageComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [EducationService, LecturersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
