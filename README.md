# Setup
Man kan sætte det her prokjet op på to måder. Den ene er at bygge det som det er eller bruge docker til at bygge det.

## Bygge det som det er
Få at man kan bygge det her prokjet skal man have installer `node.js` med version `14.1.0` (Det var den version prokjet blive udviklet i) eller højer. Der er ikke undersøgt om man kan bygge prokjet med en laver version.

Når man har installer `node.js` så kan man kører det eller bygge det.

### Bruge af kommando
Hvis man vil bruge kommando til kører det eller bygge det.

Den her kommando er til at kører det.
```bash
dotnet run --project "LarsV2.App/LarsV2.csproj"
```

Den her kommando er til at bygge det som et færdig prokjet.
```bash
dotnet publish "LarsV2.App/LarsV2.csproj" -c Release -o ./app/publish
```

## Bygge det i docker
Der er tilføjer en docker-compose til prokjet så det er nemmer så man ikke skal indtaste så meget ind i console for at kunne kører det.

For at få det op og kører skal man bruge den her kommando
```bash
docker-compose up -d
```

For at tag den ned skal man bruge den her kommando
```bash
docker-compose down
```

Men den sletter ikke det images der bilver bygget, men den her kommando tager det ned og sletter images bage efter.
```bash
docker-compose down -rmi local
```