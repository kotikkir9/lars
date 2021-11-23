import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  transform(value: string, ...args: unknown[]): unknown {
    let rawNumber: string[] = value.split(' ');

    let countryCode: string = rawNumber[0];
    let phoneNumber: string = rawNumber[1];

    if(rawNumber.length == 1){
      phoneNumber = rawNumber[0];
      countryCode = "+45";
    }else{
      countryCode = rawNumber[0];
      phoneNumber = rawNumber[1];
    }

    phoneNumber = phoneNumber.replace(/(.{4})/g, '$1-').replace(/-$/g, '');

    return `(${countryCode}) ${phoneNumber}`;
  }

}
