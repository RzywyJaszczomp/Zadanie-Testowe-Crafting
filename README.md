# Zadanie Testowe Crafting

Zadanie wykonano na systemie Windows 10 w wersji edytora 22.3.7f1. Kod napisano z użyciem narzędzia Visual Studio Code.

## Sterowanie

WSAD - poruszanie
Mysz - ruch kamerą i obsługa menu craftingu i ekwipunku
E - interakcja
I - otwarcie/zamknęcie ekwipunku


## Architektura rozwiązania

Komunikacja pomiędzy logiką a UI odbywa się przez customowe eventy oparte na Scriptable Objects. Ich przewagą nad zwykłymi Unity Events jest to, że event może zostać wywołany z wielu źródeł oraz że słuchaczy dodaje się nie w miejscu wywołania eventu, a na samym słuchaczu. Zwłaszcza ta druga cecha pozwala uniezależnić odpowiedź na event od tego kto event wywołuje. Dzięki temu obiekty UI i logiki nie muszą mieć na siebie referencji i mogłyby znajdować się nawet na osobnych, załadowanych na raz scenach. W tym konkretnym rozwiazaniu UI zapisuje referencję na klasę z logiką, kiedy ta zostaje stworzona, by uniknąć zbędnych wywołań GetComponent, ale łatwo można zmodyfikować rozwiązanie by operowało tylko na Eventach.

Zarządzanie sterowaniem również działa w oparciu o te Eventy.

Typy przedmiotów zostały zrealizowane przez ScriptableObjects. Ma tą przewagę nad Enum, taką, że przy dodaniu nowego przedmiotu, nie musimy rekompilować kodu.

System interakcji Został stworzony tak, by każdy obiekt zdolny do interakcji korzystał z tego samego kodu wchodzenia w jego zasięg. To co dzieje sie konkretnie przy użyciu obiektu, zależy od jego konkretnej klasy (w tym rozwiązaniu Pickable lub Clickable). Poprzez modyfikację w edytorze listy dozwolonych typów interakcji możemy włączać i wyłączać z co gracz potrafi. Detekcję wykonują obiekty-dzici, które znajdują się na specjalnie do tego przeznaczonej warstwie, która wychwytuje kolizje tylko ze sobą.

