# Vaatimusmäärittely doc

## Sisällysluettelo

1. [Tekijät](#tekijät)
2. [Yleiskuvaus](#yleiskuvaus)
3. [Kohderyhmä](#kohderyhmä)
4. [Kayttöympäristö](#käyttöympäristö)
5. [Käyttöympäristö](#kayttöympäristö)
6. [Kayttäjäroolit](#kayttäjäroolit)
7. [Toiminnot](#toiminnot)
8. [Käyttötapaukset](#kayttötapaukset)
9. [Työnjako](#työnjako)
10. [Työaikasuunnitelma](#työaikasuunnitelma)

## Tekijät

Jonne Okkonen, TTV18S3 (M2235)
Joonas Niinimäki, TTV18S3 (M3268)

## Yleiskuvaus

Projekti on Suomen ajoneuvojen rekisteri. Data haetaan [Avoidata.fi](https://www.avoindata.fi/data/fi/dataset/ajoneuvojen-avoin-data/resource/70ecbacc-1878-4641-9b80-7f639c414a42)-sivulta ja sovellukseen data tuodaan itsetoteutetun API rajapinnan kautta.
Sen jälkeen Visual Studiota käyttäen on luotu toiminnallisuus ja käyttöliittymä käyttäen C# ja XAML kieliä ja UWP-appia.

## Kohderyhmä

Kohderyhmänä on palvelua hyödyntävä kuluttaja, joka haluaa etsiä autonsa tietoja suomen autorekisteritietokannasta. Yritykset, jotka käyttävät palvelua tiedonhakuun. Instituutit, jotka hakevat tietoa palvelusta.

## Kayttöympäristö

Windows 10 Devices:
- Newtonsoft (JSON)
- C#
- VisualStudio
- UWP
- XAML

## Käyttäjäroolit

Kuluttaja.
Palvelua hyödyntävät yritykset.
Valtion virastot.
Korkeakoulut.

## Toiminnot

Suomen ajoneuvojen tietokannasta voidaan hakea:
- Määrä
- Merkki
- Malli
- Vuosiluvut
- Juttuja (to be continued)
- Visualisoidaan graafisesti charteilla.

## Käyttötapaukset

Use cases.
- Matti meikäläinen hakee palvelusta tietoa omasta autostaan, hän on menossa merkkiliikekorjaukseen ja hänen on hyvä tietää tarkkaa tietoa omasta autostaan.
- Liisa Lukkarinen on ostamassa uutta autoa, mutta hän ei ole varma valinnastaan. Hän hakee palvelusta tietoa vaihtoehdoista ja valitsee tämän perusteella parhaan vaihtoehdon itselleen.
- Pertti Paviljonki on katsastuksessa töissä ja hän haluaa tietää katsastukseen tuodusta autosta enemmän. Käyttäen palvelua hän saa tarvitsemansa tiedon auton tiedoista.
- Vilma Vilkas on töissä autovuokraamossa, ja hänen täytyy tietää autojen tiedot tarkalleen jäljittääkseen vuokrattuja autoja, niiden kuntoa ja muuta tarpeellista tietoa liikeen autoista.

## Työnjako

- Joonas tekee vaatimusmäärittelydokumentin
- Jonne tekee loppuraportin
- Kummatkin ohjelmoi toiminnallisuutta
- Kummatkin sunnittelee käyttöliittymää

## Työaikasuunnitelma

- Työ aloitettiin 3.4.2019
- Speksaus tehtiin 9.4.2019
- Tytunteja suunniteltu ~86h