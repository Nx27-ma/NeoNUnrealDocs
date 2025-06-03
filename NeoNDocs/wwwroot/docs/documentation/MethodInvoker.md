# MethodInvoker Systeem

Het MethodInvoker-systeem in ons project verbetert de workflow voor het testen en debuggen van componenten binnen de Unity Editor. Dit systeem combineert de `InvokerService` structuur met het `MethodInvokeInspector` script, waardoor ontwikkelaars methoden van componenten rechtstreeks vanuit de Unity Inspector kunnen aanroepen, inclusief private methoden. Dit maakt een efficiënte en flexibele testomgeving mogelijk.
Dit systeem is altijd zichtbaar bovenaan in de inspector. Je kunt er een component inslepen waarna je de methods (inclusief eventuele parameters) kunt aanroepen.

## Overzicht

Het systeem maakt het mogelijk om:

- Gemakkelijk toegang te krijgen tot alle methoden van een component, zowel publiek als privé.
- Dynamisch parameters in te voeren en te wijzigen voor methoden die worden aangeroepen.
- Methoden te testen zonder de noodzaak voor het schrijven van extra testscripts of het wijzigen van de componentcode.

## InvokerService Structuur

De `InvokerService` structuur fungeert als de kern van dit systeem. Het biedt de functionaliteit om methoden op te halen op basis van verschillende criteria en deze methoden aan te roepen met de opgegeven parameters.

### Kernfuncties:

- **Methoden Ophalen:** Kan methoden ophalen op basis van naam, parameter types, of beide.
- **Methoden Aanroepen:** Voert een methode uit op de geselecteerde component met dynamisch opgegeven parameters.
- **Parameter Waarden Beheren:** Slaat ingevoerde waarden op voor verschillende datatypes (strings, integers, floats, booleans, en objecten) en maakt het mogelijk deze te bewerken via de Inspector.

## MethodInvokeInspector Script

Het `MethodInvokeInspector` script integreert met Unity's Inspector en biedt een gebruiksvriendelijke interface voor het MethodInvoker-systeem.

### Functionaliteiten:

- **Component Selectie:** Stelt gebruikers in staat om een component te selecteren waarop methoden zullen worden aangeroepen.
- **Methoden Weergave:** Toont alle beschikbare methoden van de geselecteerde component in een overzichtelijke lijst.
- **Parameter Invoer:** Biedt dynamische invoervelden voor de parameters van elke methode, aangepast aan het datatype van de parameter.
- **Methoden Aanroepen:** Bevat een "Invoke" knop voor elke methode, waarmee de methode direct vanuit de Inspector kan worden aangeroepen met de ingevoerde parameters.
