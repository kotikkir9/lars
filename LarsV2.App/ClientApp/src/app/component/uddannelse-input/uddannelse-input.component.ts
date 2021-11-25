import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { MatOptionSelectionChange } from '@angular/material/core';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators'
import { EducationSubject, iEducationSubject } from 'src/app/DTO/educationSubject';
import { iEducationServiceData, EducationService } from 'src/app/service/education.service';

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

  @Output() addEducationSubjectEvent = new EventEmitter<iEducationSubject>();

  uddannelseFormGroup: FormGroup;
  data: iEducationServiceData;
  filteredUddannelse: Observable<string[]>;
  filteredFag: Observable<iEducationSubject[]>;
  
  constructor(private _formBuilder: FormBuilder, private us: EducationService) {}

  async ngOnInit(): Promise<void> {
    
    this.uddannelseFormGroup = this._formBuilder.group({
      uddannelse: [''],
      fag: [''],
    });

    this.data = await this.us.getData().toPromise();
    
    this.filteredUddannelse = this.uddannelseFormGroup.controls["uddannelse"].valueChanges.pipe(
      startWith(''),
      map(uddannelse => {
        this.toucheInput(this.uddannelseFormGroup.controls["fag"]);
        return uddannelse ? this._filteredUddannelse(uddannelse) : this.data.Education.slice()
      })
    );

    this.filteredFag = this.uddannelseFormGroup.controls["fag"].valueChanges.pipe(
      startWith(''),
      map(fag => (fag ? this._filteredFag(fag) : this._getFilteredUddannelse().slice()))
    );
  }

  selectionChangeFag(data: iEducationSubject, event: MatOptionSelectionChange) {
    if(!event.isUserInput)
      return;

    this.uddannelseFormGroup.controls["uddannelse"].setValue(data.education);
    this.uddannelseFormGroup.controls["fag"].setValue(data.subject.subject);
  }

  reset(){
    this.uddannelseFormGroup.controls["fag"].setValue("");
    this.uddannelseFormGroup.controls["uddannelse"].setValue("");
  }

  getDataFormInput(reset: boolean = true, checkAllSet: boolean = true):void {
    let fag:string = this.uddannelseFormGroup.controls["fag"].value;
    let uddannelse:string = this.uddannelseFormGroup.controls["uddannelse"].value;

    let data:iEducationSubject = new EducationSubject(uddannelse, fag);

    if(checkAllSet && (fag === "" || uddannelse === ""))
      return;
      
    let formList = this.data.EducationSubject.find(item => {
      return data.education === item.education && data.subject.subject === item.subject.subject;
    })

    if(formList)
      data = formList;

    this.addEducationSubjectEvent.emit(data);
    if(reset)
      this.reset();
  }

  private _filteredFag(value: string): iEducationSubject[] {
    const filterValue = value.toLowerCase();

    let data: iEducationSubject[] = this.data.EducationSubject.filter(uddannelse => uddannelse.subject.subject.toLowerCase().includes(filterValue));
    let ugValue: string = this.uddannelseFormGroup.controls["uddannelse"].value.toLowerCase();

    if(ugValue !== "")
      data = data.filter(uddannelse => uddannelse.education.toLowerCase().includes(ugValue));

    return data;
  }

  private _filteredUddannelse(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.data.Education.filter(uddannelse => uddannelse.toLowerCase().includes(filterValue));
  }

  private _getFilteredUddannelse(): iEducationSubject[] {
    let data: iEducationSubject[] = this.data.EducationSubject;
    let ugValue: string = this.uddannelseFormGroup.controls["uddannelse"].value.toLowerCase();

    if(ugValue !== "")
      data = data.filter(uddannelse => uddannelse.education.toLowerCase().includes(ugValue));

    return data;
  }

  private toucheInput(ctl: AbstractControl){
    ctl.setValue(ctl.value);
  }

}
