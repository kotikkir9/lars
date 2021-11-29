29-11-2021
Tilføjet status property til udbud objekter man får af API'en. Der er 3 typer af status: 
  - DONE: udbuddet er gennemført og er færdigt (slutdato < dagens dato).
  - IN PROGRESS: udbuddet er i gang (startdato <= dagens dato && slutdato >= dagens dato).
  - READY: udbuddet er klar, men er ikke startet (startdato > dagens dato).