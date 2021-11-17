import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoursesService } from './service/courses.service';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './page/home-page/home-page.component';
import { CreateTeacherPageComponent } from './page/create-teacher-page/create-teacher-page.component';
import { CreateTeacherComponent } from './component/create-teacher/create-teacher.component';
import { UddannelseService } from './service/uddannelse.service';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    CreateTeacherPageComponent,
    CreateTeacherComponent
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
  providers: [CoursesService, UddannelseService],
  bootstrap: [AppComponent]
})
export class AppModule { }
