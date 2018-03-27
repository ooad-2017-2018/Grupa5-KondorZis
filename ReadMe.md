**Sistem za elektronsko glasanje**

1. Kenan Karahodžic
2. Damad Butkovic

**Opis teme:**

S obzirom da je naš sistem za glasanje(korišten na dosadašnjim izborima) dosta zastario s obzirom na dostupnu tehnologiju, svrha našeg sistema je automatizacija korištenja i funkcionalnosti na lokalnim ili opštim izborima u našoj zemlji.

U ovom slucaju, korisnikom bi se trebala smatrati država, ali i glasac, tako da u suštini problem se može, i biti ce posmatran sa dvije strane. Problem koji država ima jeste velika mogucnost malverzacije tokom izdavanja, popunjavanja, predaje i brojanja glasackih listica, dok glasacu ovaj sistem nece postati ništa teži, iako koristi tehnologiju umjesto obicnog popunjavanja glasackog listica.

Razlozi su jasni. Upotrebom dobro razvijenog sistema za elektronsko glasanje, uveliko bi se ubrzao proces prikupljanja, brojanja i analize glasova, a uveliko umanjila mogucnost varanja. Takoder bi samo biracko mjesto bilo mnogo efikasnije zbog manjka potrebe za papirima, što podiže i ekološku osviještenost.

**Procesi:**

Slucaj 1:

Korisnik: Glasac

- Glasac dolazi na izborno mjesto, i prolazi verifikaciju identiteta, te dobija pristup glasackoj kabini u kojoj se nalazi racunar ili uredaj sa ekranom na kojem je generisan prazan glasacki listic na kojem glasac daje svoj glas te listic šalje na bazu koja pohranjuje glas(potpuno anonimno). Jedna od pogodnosti ovakvih sistema bi bila, s obzirom na postojanje mobilnih aplikacija, pracenje trenutne posjecenosti(zauzetosti) glasackog mjesta u kojem glasac treba da glasa.

Slucaj 2:

Korisnik: Država

- Država upošljava neutralne ljude koji ce imati pristup dijelu interfejsa namijenjenom za pracenje trenutnog stanja pristiglih glasova, što omogucava real-time pracenje rezultata, izlaznosti i trenutne posjecenosti svakog od izbornih mjesta.

Registracija potencijalnih politickih subjekata:

- CiK dostavlja spisak politickih subjekata i izbornih utrka te raspored politickih subjekata po izbornim utkama za izbore koje administrator, pod nadzorom nadležnih osoba iz CiK-a unosi u sistem(Da bi se sprijecilo potencijalno izostavljanje ili dodavanje nekih od politickih subjekata), nakon toga se generiše završni dll file koji ce se koristiti za vijeme izbora.

Registracija i verifikacija glasaca:

- Dolaskom na glasacko mjesto, glasac dobija pristup glasanju uz prilaganje važeceg licnog dokumenta. Nakon glasanja, glasac šalje svoj glas na bazu koja se ažurira svakih sat vremena ili nakon odredenog broja glasova(prikazuje nove rezultate), a do tad se broj glasova cuva keširan u memoriji, i tom dijelu, niko nema pristup.

**Funkcionalnosti:**

Prije izbora, pod nadzorom nadležnih:

- Unos podataka o politickim subjektima i izbornim utrkama
- Generisanje liste glasackog tijela

Za vrijeme izbora:

- Verifikacija identiteta glasaca
- Glasanje
- Uvid u trenutne rezultate
- Uvid trenutnu izlaznost(ukupnu i lokalnu)

 Nakon zatvaranja glasackih mjesta:

- Uvid u konacne rezultate
- Uvid u konacnu izlaznost
- Uvid u statistiku izbora

**Akteri:**

Glasac – clan glasackog tijela

Clanovi birackog odbora na glasackom mjestu – ovlaštena lica na glasackom mjestu

Predsjednik glasackog mjesta – supervizor ovlaštenih lica na glasackom mjestu

CiK – generalni supervizor izbora

Administrator sistema – osoba zadužena za stabilnost i ispravnost sistema za glasanje