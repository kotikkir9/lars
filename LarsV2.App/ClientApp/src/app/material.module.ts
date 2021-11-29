import { NgModule } from '@angular/core';

import { MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatExpansionModule} from '@angular/material/expansion';

@NgModule({
	imports: [
		MatStepperModule,
		MatFormFieldModule,
		MatButtonModule,
		MatInputModule,
		MatAutocompleteModule,
		MatToolbarModule,
		MatPaginatorModule,
		MatTableModule,
		MatIconModule,
		MatTooltipModule,
		MatProgressSpinnerModule,
		MatCardModule,
		MatDatepickerModule,
		MatNativeDateModule,
		MatExpansionModule
	],
	exports: [
		MatStepperModule,
		MatFormFieldModule,
		MatButtonModule,
		MatInputModule,
		MatAutocompleteModule,
		MatToolbarModule,
		MatPaginatorModule,
		MatTableModule,
		MatIconModule,
		MatTooltipModule,
		MatProgressSpinnerModule,
		MatCardModule,
		MatDatepickerModule,
		MatNativeDateModule,
		MatExpansionModule
	]
})
export class MaterialModule { }
