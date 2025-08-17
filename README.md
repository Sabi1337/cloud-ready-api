# Cloud Ready API

Eine einfache REST API in **.NET 7**, um Tasks zu verwalten.  
Ich habe das Projekt gebaut, um zu zeigen, wie man eine API mit **ASP.NET Core** erstellt, mit **Docker** containerisiert und anschließend auf **Render** deployt.

## Live-Demo
[https://cloud-ready-api.onrender.com/api/tasks](https://cloud-ready-api.onrender.com/api/tasks)

## Features
- REST API mit ASP.NET Core
- Läuft in einem Docker-Container
- Deployment auf Render
- Liefert JSON-Responses
- Minimaler Code – schnell und übersichtlich

## Endpoints

### GET `/api/tasks`
Gibt alle Tasks zurück.
```bash
curl https://cloud-ready-api.onrender.com/api/tasks
```

### Beispiel-Response:
```bash
["Erster Task"]
```
### POST /api/tasks
```bash
curl -Method POST https://cloud-ready-api.onrender.com/api/tasks `
     -Headers @{ "Content-Type" = "application/json" } `
     -Body '"Mein erster Task"'
```
### DELETE
```bash
Invoke-RestMethod -Uri "https://cloud-ready-api.onrender.com/api/tasks" -Method DELETE
```
## Lokal starten
```bash
# Repo klonen
git clone https://github.com/Sabi1337/cloud-ready-api.git
cd cloud-ready-api

dotnet restore

dotnet run
```
## Mit Docker starten
```bash
docker build -t cloudreadyapi .
docker run -p 8080:80 cloudreadyapi
```
### Beispiel-Dockerfile
```bash
# Basis-Image mit .NET SDK zum Bauen
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Projektdateien kopieren und Abhängigkeiten wiederherstellen
COPY *.csproj ./
RUN dotnet restore

# Restliche Dateien kopieren und App bauen
COPY . ./
RUN dotnet publish -c Release -o /app

# Laufzeit-Image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "CloudReadyApi.dll"]
```
## Deployment
Das Deployment läuft automatisch über Render.
Sobald ich auf den main-Branch pushe, wird die App neu gebaut und deployed.

# So habe ich das Projekt gemacht

## 1. API-Grundgerüst erstellt
- Mit `dotnet new webapi` eine minimalistische ASP.NET Core API erstellt.
- Beispielcode (`WeatherForecast`) entfernt und eigenen `TasksController` erstellt.

## 2. REST Endpoints implementiert
- **GET** `/api/tasks`  
  → Gibt eine Liste von Strings zurück.
- **POST** `/api/tasks`  
  → Fügt neue Tasks hinzu.

## 3. Lokal getestet
- API über `dotnet run` gestartet.
- Mit `curl` sowie im Browser getestet.

## 4. Docker-Container gebaut
- Eigenes `Dockerfile` erstellt.
- Image lokal gebaut (`docker build`) und getestet (`docker run`).

## 5. Deployment auf Render
- GitHub-Repo erstellt und Code gepusht.
- In Render das Repo verbunden.
- Auto-Deploy bei Änderungen aktiviert.

## 6. Dokumentation
- Diese `README.md` geschrieben mit allen Infos, damit das Projekt leicht nachvollziehbar ist.

---

### 🎯 Ziel des Projekts
Dieses Projekt zeigt, dass ich in der Lage bin:
- Eine API **von Grund auf zu erstellen**
- Sie **zu containerisieren**
- Sie **produktiv in die Cloud zu bringen**
- Eine **Dokumentation** und **automatisiertes Deployment** bereitzustellen



## Lizenz
MIT – frei verwendbar




