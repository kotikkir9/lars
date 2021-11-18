import { NgModule } from '@angular/core';

import {MatStepperModule} from '@angular/material/stepper';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';

@NgModule({
  imports: [
	MatStepperModule,
	MatFormFieldModule,
	MatButtonModule,
	MatInputModule,
	MatAutocompleteModule
  ],
  exports: [
	MatStepperModule,
	MatFormFieldModule,
	MatButtonModule,
	MatInputModule,
	MatAutocompleteModule
  ]
})
export class MaterialModule { }
