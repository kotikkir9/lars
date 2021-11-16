import { NgModule } from '@angular/core';

import {MatStepperModule} from '@angular/material/stepper';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';

@NgModule({
  imports: [
	MatStepperModule,
	MatFormFieldModule,
	MatButtonModule,
	MatInputModule
  ],
  exports: [
	MatStepperModule,
	MatFormFieldModule,
	MatButtonModule,
	MatInputModule
  ]
})
export class MaterialModule { }
