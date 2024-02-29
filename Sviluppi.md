### Sviluppi richiesti

Nel sistema FlightSimulator si vogliono implementare due nuove funzionalità:
1. La possibilità di gestire dei voli, consentendo l'aggiunta di nuovi voli e la ricerca di questi ultimi.
2. La possibilità di acquistare dei biglietti e ricercarli. Questi dovranno essere associati ad uno specifico volo.

Un volo sarà costituito da:
* un identificatore
* un aereo
* un numero di posti residui (dato dal numero di posti disponibili sull'aereo - i posti già prenotati)
* il costo di un singolo posto per quel determinato volo
* una partenza 
* una destinazione
* un orario di partenza
* un orario di arrivo previsto

Un biglietto sarà invece composto da:
* un identificatore
* un volo al quale il biglietto sarà associato
* un numero di posti richiesti
* l'importo totale corrispondente (calcolato come numero di posti richiesti * importo di un singolo posto dell'aereo)
* la data di acquisto del biglietto

Dovranno essere realizzati:
* la classe di DB Volo
* la classe di DB Biglietto
* migration
* le rispettive classi API
* un controller che consenta di gestire i voli 
    - aggiunta di un volo
    - ricerca di un volo tramite id
    - ricerca dei voli con posti ancora disponibili
    - cancellazione di un volo
    - modifica di un volo (es.: modifica dell'orario di partenza)
* un controller che permetta di gestire i biglietti
    - ricerca di tutti i biglietti dato l'id di un volo
    - ricerca dei biglietti per id
    - aggiunta di un biglietto (N.B. dovrà essere possibile ultimare l'acquisto del biglietto solo se il numero di posti richiesti è minore o uguale al numero di posti ancora disponibili per quel volo)
    - cancellazione di un biglietto (es.: disdetta)
    - per semplicità non sarà possibile modificare il biglietto una volta effettuato l'acquisto
* implementazione delle query tramite EF core relative alle operazioni richieste
* test