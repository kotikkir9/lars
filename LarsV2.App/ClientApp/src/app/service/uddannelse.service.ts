import { Injectable } from '@angular/core';
import { iUddannelse } from '../DTO/uddannelse';

@Injectable({
  providedIn: 'root'
})
export class UddannelseService {

  constructor() { }

  getData(): iUddannelse[] {
    return [
      {uddannelse: "Automation og drift", fag: "Udvikling af automatiske styringer"},
      {uddannelse: "Automation og drift", fag: "Styring og regulering"},
      {uddannelse: "Automation og drift", fag: "Maskinteknologi industri (industri)"},
      {uddannelse: "Automation og drift", fag: "SCADA, netværk og databaser"},
      {uddannelse: "Automation og drift", fag: "Robot  teknologi"},
      {uddannelse: "Automation og drift", fag: "Afgangsprojekt"},
      {uddannelse: "AU i innovation, produkt og produktion", fag: "Projektledelse"},
      {uddannelse: "AU i innovation, produkt og produktion", fag: "Værdikæden i praksis"},
      {uddannelse: "AU i innovation, produkt og produktion", fag: "Kvalitetsoptimering med Six Sigma"},
      {uddannelse: "AU i innovation, produkt og produktion", fag: "Produktionsiotimering"},
      {uddannelse: "AU i innovation, produkt og produktion", fag: "Innovation i praksis"},
      {uddannelse: "AU i innovation, produkt og produktion", fag: "Afgangsprojekt"},
      {uddannelse: "AU i Energiteknologi", fag: "Energikonsulent 1"},
      {uddannelse: "AU i Energiteknologi", fag: "Energikonsulent opfølgning (IDV)"},
      {uddannelse: "AU i Energiteknologi", fag: "Varmepumpe (VE)"},
      {uddannelse: "El-installation", fag: "OB1 Boliginstallationer og Teknisk beregning på kredsløb"},
      {uddannelse: "El-installation", fag: "Ob2: Bygningsinstallationer og Teknisk dokumentation"},
      {uddannelse: "El-installation", fag: "Ob3: Mindre industriinstallationer og Teknisk beregning på maskiner"},
      {uddannelse: "El-installation", fag: "Ob4: Større industriinstallationer og elforsyningsanlæg"},
      {uddannelse: "El-installation", fag: "Vf2: Bekendtgørelser og standarder"},
      {uddannelse: "El-installation", fag: "Vf1: Kvalitet, sikkerhed og miljø"},
      {uddannelse: "El-installation", fag: "Afgangsprojekt"}
    ]
  }
}
