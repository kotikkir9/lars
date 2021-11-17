import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { OpretUdbudComponent } from './page/opret-udbud/opret-udbud.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CoursesService } from './service/courses.service';
import { HttpClientModule } from '@angular/common/http';
import { OpretUdbudStepComponent } from './component/opret-udbud-step/opret-udbud-step.component';

@NgModule({
  declarations: [
    AppComponent,
    OpretUdbudComponent,
    OpretUdbudStepComponent
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
  providers: [CoursesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
