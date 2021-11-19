import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    let rawNumber: string[] = value.split(' ');
    let countryCode = rawNumber[0];
    let phoneNumber = rawNumber[1];

    const divNumber = (3 % phoneNumber.length) == 0 ? 3 : 4;

    if(divNumber == 3){
      phoneNumber = phoneNumber.replace(/(.{3})/g, '$1-').replace(/-$/g, '');
    }else{
      phoneNumber = phoneNumber.replace(/(.{4})/g, '$1-').replace(/-$/g, '');
    }

    return `(${countryCode}) ${phoneNumber}`;
  }

}
