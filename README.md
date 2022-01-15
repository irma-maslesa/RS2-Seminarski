# RS2 - Seminarski - PELIKULA

**Pelikula** je aplikacija koja služi za pregled najava filmova, pregled zakazanih projekcija, te rezervaciju i kupovinu karata za željene projekcije. Aplikacija je podijeljena u dva dijela:
-	desktop aplikacija namijenjena administratorima za upravljanje sadržajem, te radnicima za prodaju i
-	mobilna aplikacija namijenjena korisnicima za pregled i filtriranje sadržaja.

## Kredencijali za prijavu   

### Desktop aplikacija

- Administrator

    ```
    Korisnicko ime: administrator             Korisnicko ime: desktop
    Lozinka: test                             Lozinka: test           
    ```
    
- Moderator

    ```
    Korisnicko ime: moderator
    Lozinka: test          
    ```
    
- Radnik

    ```
    Korisnicko ime: radnik
    Lozinka: test           
    ```    

### Mobilna aplikacija

- Klijent

    ```
    Korisnicko ime: klijent             Korisnicko ime: mobile
    Lozinka: test                       Lozinka: test   
    ```
    

## Pokretanje aplikacija
1. Kloniranje repozitorija

    ```
    git clone https://github.com/irma-maslesa/RS2-Seminarski.git
    ```
2. Otvoriti klonirani repozitoriji u konzoli

3. Pokretanje dokerizovanog API-ja i DB-a

    >**Napomena**: za pokretanje DB-a treba više vremena zbog izvršavanja SQL skripte za import podataka  

    ```
    docker-compose build
    docker-compose up
    ```
    
4. Otovriti Pelikula.MOBILE folder

    ```
    cd Pelikula.MOBILE
    ```

5. Dohvatanje dependecy-a

    ```
    flutter pub get
    ```
    
6. Pokretanje mobilne aplikacije

    ```
    flutter run
    ```   
    
7. Pokretanje desktop aplikacije

    ```
    1. Otvoriti solution u Visual Studiu
    2. Desni klik na solution
    3. Set Startup Projects
    4. Multiple startup projects
    5. Pelikula.WINUI - Start
    6. OK
    7. CTRL + F5
    ```    
