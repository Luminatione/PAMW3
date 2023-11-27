# Dokumentacja
## Testy ui
testy wykonywane są z projektu UITests i wymagają wcześniejszego uruchomienia aplikacji z projektu MVCBlazorClient i serwera P05Shop.API. Po uruchomieniu testy wykona się automatycznie otwierając przy tym instance google chrome. Testy sprawdzają operacje CRUD
## Pipeliny
przy każdym PR do mwo-proj uruchamiany jest pipeline który:
1. zrobi checkout
2. ustawi DB
3. ustawi .Net Core			
4. pobierze zależności
5. zbuduje projekt
6. stworzy i zaaplikuje migracje
7. wykona publish
8. uruchomi aplikacje do testów i przeprowadzi testy
9. jeżeli poprzedni krok się nie powiedzie, to stworzy ticket w Azure Devops
10. wykona deploy

Krok 8 jest specjalnie spreparowany za pomocą polecenia 'exit 1' tak, żeby się nie powieść i pokazać tworzenie ticketu.
## Aplikacja
Aplikacja to prosty CRUD umożliwiający operacje na obiektach typu CarBrnad