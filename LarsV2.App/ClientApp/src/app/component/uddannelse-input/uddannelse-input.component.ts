import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
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

  @Output() changesEvent = new EventEmitter<iUddannelse>();

  tempData: iUddannelse;

  uddannelseFormGroup: FormGroup;
  uddannelseAndFagData: iUddannelse[];
  uddannelseData: string[] = [];
  filteredUddannelse: Observable<string[]>;
  filteredFag: Observable<iUddannelse[]>;
  
  constructor(private _formBuilder: FormBuilder, private us: UddannelseService) {}

  ngOnInit(): void {
    this.uddannelseFormGroup = this._formBuilder.group({
      uddannelse: [''],
      fag: [''],
    });

    this.filteredUddannelse = this.uddannelseFormGroup.controls["uddannelse"].valueChanges.pipe(
      startWith(''),
      map(uddannelse => (uddannelse ? this._filteredUddannelse(uddannelse) : this.uddannelseData.slice()))
    );

    this.filteredFag = this.uddannelseFormGroup.controls["fag"].valueChanges.pipe(
      startWith(''),
      map(fag => (fag ? this._filteredFag(fag) : this._getFilteredUddannelse().slice()))
    );

    this.loadData();
  }

  private dataIsChanges():void {
    let fag:string = this.uddannelseFormGroup.controls["fag"].value;
    let uddannelse:string = this.uddannelseFormGroup.controls["uddannelse"].value;

    let data:iUddannelse = {fag: fag, uddannelse: uddannelse}

    if(fag === "" || uddannelse === "" || this.tempData != undefined && (data.fag === this.tempData.fag && data.uddannelse === this.tempData.uddannelse))
      return;
      
    this.tempData = data;

    this.changesEvent.emit(data);
  }

  private loadData():void {
    this.uddannelseAndFagData = this.us.getData();

    this.uddannelseAndFagData.forEach(item => {
      this.uddannelseData.push(item.uddannelse);
    });

    this.uddannelseData = this.uddannelseData.filter((item, pos, self) => {
      return self.indexOf(item) == pos;
    });
  }

  private _filteredFag(value: string): iUddannelse[] {
    const filterValue = value.toLowerCase();

    let data: iUddannelse[] = this.uddannelseAndFagData.filter(uddannelse => uddannelse.fag.toLowerCase().includes(filterValue));
    let ugValue: string = this.uddannelseFormGroup.controls["uddannelse"].value.toLowerCase();

    if(ugValue !== "")
      data = data.filter(uddannelse => uddannelse.uddannelse.toLowerCase().includes(ugValue));

    if(ugValue === "" && data.length == 1 && data[0].fag.toLowerCase() == filterValue)
      this.uddannelseFormGroup.controls["uddannelse"].setValue(data[0].uddannelse);

    this.dataIsChanges();

    return data;
  }

  private _filteredUddannelse(value: string): string[] {
    const filterValue = value.toLowerCase();

    this.toucheInput(this.uddannelseFormGroup.controls["fag"]);

    return this.uddannelseData.filter(uddannelse => uddannelse.toLowerCase().includes(filterValue));
  }

  private _getFilteredUddannelse(): iUddannelse[] {
    let data: iUddannelse[] = this.uddannelseAndFagData;
    let ugValue: string = this.uddannelseFormGroup.controls["uddannelse"].value.toLowerCase();

    if(ugValue !== "")
      data = data.filter(uddannelse => uddannelse.uddannelse.toLowerCase().includes(ugValue));

    return data;
  }

  private toucheInput(ctl: AbstractControl){
    ctl.setValue(ctl.value);
  }

}
