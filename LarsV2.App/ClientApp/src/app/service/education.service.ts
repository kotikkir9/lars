import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { iEducation, iEducationSubject } from '../DTO/education';

const Education: iEducation[] = [
  {
      education: "AU i Energiteknologi",
      subjects: [
          {
              id: 13,
              subject: "Energikonsulent 1"
          },
          {
              id: 14,
              subject: "Energikonsulent opfølgning (IDV)"
          },
          {
              id: 15,
              subject: "Varmepumpe (VE)"
          }
      ]
  },
  {
      education: "AU i innovation, produkt og produktion",
      subjects: [
          {
              id: 12,
              subject: "Innovation i praksis"
          },
          {
              id: 10,
              subject: "Kvalitetsoptimering med Six Sigma"
          },
          {
              id: 11,
              subject: "Produktionsiotimering"
          },
          {
              id: 8,
              subject: "Projektledelse"
          },
          {
              id: 7,
              subject: "Styring og regulering"
          },
          {
              id: 9,
              subject: "Værdikæden i praksis"
          }
      ]
  },
  {
      education: "Automation og drift",
      subjects: [
          {
              id: 6,
              subject: "Afgangsprojekt"
          },
          {
              id: 3,
              subject: "Maskinteknologi industri (industri)"
          },
          {
              id: 5,
              subject: "Robot teknologi"
          },
          {
              id: 4,
              subject: "SCADA, netværk og databaser"
          },
          {
              id: 2,
              subject: "Styring og regulering"
          },
          {
              id: 1,
              subject: "Udvikling af automatiske styringer"
          }
      ]
  },
  {
      education: "El-installation",
      subjects: [
          {
              id: 22,
              subject: "Afgangsprojekt"
          },
          {
              id: 16,
              subject: "OB1 Boliginstallationer og Teknisk beregning på kredsløb"
          },
          {
              id: 17,
              subject: "Ob2: Bygningsinstallationer og Teknisk dokumentation"
          },
          {
              id: 18,
              subject: "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner"
          },
          {
              id: 19,
              subject: "Ob4: Større industriinstallationer og elforsyningsanlæg"
          },
          {
              id: 21,
              subject: "Vf1: Kvalitet, sikkerhed og miljø"
          },
          {
              id: 20,
              subject: "Vf2: Bekendtgørelser og standarder"
          }
      ]
  }
];

export interface iEducationServiceData {
  EducationSubject: iEducationSubject[];
  Education: string[];
}

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  constructor() { }

  getData(): Observable<iEducationServiceData> {
    let data: iEducationServiceData = {
      EducationSubject: [],
      Education: []
    }

    Education.forEach(item => {
      data.EducationSubject.push.apply(data.EducationSubject, this.convetEducationData(item))
      data.Education.push(item.education);
    });

    return new Observable(subscriber => {
      subscriber.next(data)
    })
  }

  private convetEducationData(data: iEducation): iEducationSubject[] {
    let newData: iEducationSubject[] = [];

    data.subjects.forEach(subject => {
      newData.push({education: data.education, subject: subject});
    })

    return newData;
  }
}
