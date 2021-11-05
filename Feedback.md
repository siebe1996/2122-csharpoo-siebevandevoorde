
## Feedback C# OO Programming


#### Kennismaking Visual Studio 2019


- [x] *Aanmaken solution binnen GIT-repository*
- [x] *Eenvoudige consoletoepassing (met invoer gebruiker)*
- [x] *Eenvoudige WinForm toepassing*
- [x] *Een klasse toevoegen*

#### Gebruik GIT

- [x] *Je gebruikt 'atomaire' commits*
- [x] *Je gebruikt zinvolle commit messages*

#### Debugging

- [x] *Code stap voor stap uitvoeren*
- [x] *Breakpoints*
- [x] *De waarde van variabelen bekijken tijdens de uitvoering van je programma*

#### Programmeerstijl

- [x] *Huisregels voor programmeerstijl volgen*

* Gebruik type inference ('var') volgens de conventie uit de stijlregels.
* Gebruik de 'this'-qualifier enkel waar nodig om verwarring te vermijden.
* Schrijf geen te lange methoden (richtlijn ~20 lijnen).
* Voor namen van publieke properties wordt PascalCasing gebruikt.
  
* Tip: hou rekening met de messages en warnings uit de 'Error List'.


#### Exceptions

- [x] *try..catch*
- [ ] *try..catch..finally*
- [x] *Je werpt bruikbare exceptions op wanneer je een foutsituatie detecteert die niet lokaal op een beter manier kan afgehandeld worden.*

#### Enumerations

--> Nog niet beoordeeld

- [ ] *Declaratie en gebruik van enum-type*
 
#### Properties

- [x] *Full property (with private backing field)*
- [x] *Extra code in getter of setter (bv. validatie)*
- [x] *Auto-implemented property*
- [x] *Access-modifiers voor Getters en Setters*

#### Interpolated strings

- [x] *Interpolated strings*

#### Generic collections

- [x] *List<T>*
- [x] *Dictionary<T,T>*
- [ ] *Overzicht andere generic collections*

#### Interfaces

- [x] *Interface declaratie*
- [x] *Interface implementatie*
- [x] *Interface gebruiken als type*

#### Architectuur van een toepassing - Meerlagenmodel

- [x] *Klasseblibliotheken*
- [x] *Meerlagenmodel - 3lagenmodel*
- [x] *'Loose coupling' - dependency injection*
- [x] *Interface gebruiken als scheiding tussen architectuurlagen*



#### Bestanden en 'streams'

- [x] *Statische klassen uit 'System.IO'*
- [x] *Streams*
- [x] *Serialisatie*

* Gebruik beter een 'using' constructie dan een 'try..catch..finally' waar dat mogelijk is.
* Gebruik geen paden naar een directory binnen je Visual Studio Project...


#### 'Value' en 'Reference' types, cloning van objecten

- [ ] *'value' en 'reference' types, 'deep' versus 'shallow' copy, object cloning*

* Je hebt al een copy-constructor voor 'Player' maar er is geen sprake van een 'deep' copy omdat die kalsse enkele (relevante) velden heeft van een value-type.

#### Klassen - klassehiërarchie

- [x] *Klasse declaratie*
- [x] *constructor overloading*
- [ ] *Klasse-hiërarchie - subklasse - base-constructor*
- [ ] *Klasse-hiërarchie - virtual methods - override*
- [ ] *Abstracte klasse + implementatie*

#### Structs

--> Nog niet beoordeeld

- [ ] *Structs*

##### Extension methods

- [x] *Extension method schrijven*
- [x] *Functioneel gebruik van extension methods*

#### Delegates

--> Nog niet beoordeeld

- [ ] *(Predefined) Delegates*

#### Lambda expressions

- [ ] *Lambda expressions*

* Je gebruikt enkele heel elementaire lambda-expressies.

#### Language Integrated Query (Linq)

- [ ] *Linq standard query operator syntax*
- [x] *Linq method syntax*
- [x] *Basismethodes voor Linq*

#### Events

--> Nog niet beoordeeld

- [ ] *Event 'Publisher'*
- [ ] *Event 'Consumer'*

#### Concurrent programmatie: Tasks

- [x] *Tasks*
- [ ] *Cross-thread' interactie vanuit een Task met de userinterface*
- [ ] *Exceptions in Tasks*
- [x] *Parallel loops*
 

* In `CheckWin()` stockeer je binnen de 'Parallel.For' (als er een speler is met de 'winningTile' ) een 'winningTile' in 'winningTileHolder'. Maar in principe zou het kunnen dat dit tegelijk gebeurt voor meerdere winning Tiles? In datgeval weet je toch niet welke 'winningTile' uiteindelijk in 'WinningTileHolder' terechtkomt?
* Je gebruikt geen Task cancellation.

#### Concurrent programming: Task synchronisation

--> Nog niet beoordeeld

- [ ] *Lock*
- [ ] *Concurrent/ thread safe collections*

#### Asynchronous programming: async .. await

--> Nog niet beoordeeld

- [ ] *async .. await*

#### (Recursie)

--> Nog niet beoordeeld

- [ ] *Recursie - concept*
- [ ] *Backtracking*

#### (Indexers & Iteratoren)
 
--> Nog niet beoordeeld

- [ ] *Indexers*
- [ ] *Enumeratoren*

#### (Statische klassen, methoden, velden)

- [ ] *Zinvol gebruik statische klassen, methoden, velden*

* Je gebruik van een statische klasse voor RouletteWheel is zeker geen 'Good Practice'.

#### Code Reviews

- [x] *Code reviews*

* Je eerste codereview is vrij oppervlakkig en algemeen. Probeer volgende keer voor wat meer diepgang te zorgen.
* Je tweede codereview is al wat beter (maar zeker nogniet perfect :)).
