import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators'
import { iUddannelse, UddannelseService } from 'src/app/service/uddannelse.service';

enum eFilterBy {
  uddannelse,
  fag
}

@Component({
  selector: 'app-uddannelse-input',
  templateUrl: './uddannelse-input.component.html',
  styleUrls: ['./uddannelse-input.component.scss']
})
export class UddannelseInputComponent implements OnInit {

  uddannelseFormGroup: FormGroup;
  uddannelseData: iUddannelse[];
  filteredUddannelse: Observable<iUddannelse[]>;
  
  constructor(private _formBuilder: FormBuilder, private us: UddannelseService) {
    this.filteredUddannelse = this.uddannelseFormGroup.controls["uddannelse"].valueChanges.pipe(
      startWith(''),
      map(uddannelse => (uddannelse ? this._filteredUddannelse(uddannelse, eFilterBy.uddannelse) : this.uddannelseData.slice()))
    );
  }

  private _filteredUddannelse(value: string, filterBy: eFilterBy): iUddannelse[] {
    const filterValue = value.toLowerCase();

    switch(filterBy) {
      case eFilterBy.uddannelse:
        return this.uddannelseData.filter(uddannelse => uddannelse.uddannelse.toLowerCase().includes(filterValue));
      case eFilterBy.fag:
        return this.uddannelseData.filter(uddannelse => uddannelse.uddannelse.toLowerCase().includes(filterValue));
    }
  }

  ngOnInit(): void {
    this.uddannelseFormGroup = this._formBuilder.group({
      uddannelse: [''],
      fag: [''],
    });

    this.uddannelseData = this.us.getData();
  }

}
