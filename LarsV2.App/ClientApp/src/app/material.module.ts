import { NgModule } from '@angular/core';

import {MatStepperModule} from '@angular/material/stepper';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatToolbarModule} from '@angular/material/toolbar';

@NgModule({
  imports: [
	MatStepperModule,
	MatFormFieldModule,
	MatButtonModule,
	MatInputModule,
	MatAutocompleteModule,
	MatToolbarModule
  ],
  exports: [
	MatStepperModule,
	MatFormFieldModule,
	MatButtonModule,
	MatInputModule,
	MatAutocompleteModule,
	MatToolbarModule
  ]
})
export class MaterialModule { }
