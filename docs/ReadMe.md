## 1. Asennus
        -

## 2. Tietoa Ohjelmasta
        - Ohjelmisto on Suomen ajoneuvojen rekisteri. Tieto on saatu Trafin rekisteristä avoin data sivulta. Sen avulla voidaan hakea yksittäisiä ajoneuvoja, useampia tai vaikka tarkastella suomen ajoneuvojen kokonaisrekisteritietoja.
        
## 3. Kuvaruutukaappaukset tärkeimmistä käyttöliittymistä + lyhyet käyttöohjeet jollei "ilmiselvää"
        - Käyttöohjeet löytyvät ohjelman Help Page - näkymästä.
        -
        
## 4. Ohjelman tarvitsemat/mukana tulevat tiedostot/tietokannat
        -
        -

## 5. Tiedossa olevat ongelmat ja bugit sekä jatkokehitysideat.
        - Tieto tulee NoSQL muodossa, jolloin osa hakuvaihtoehdoista tulee omilla nimikkeillä, vaikka ne olisivat esimerkiksi samalta valmistajalta.
        - UTF-8 ei ole ohjelmassa, joten hakuvaihtoehdoissa skandinaaviset merkit näkyvät rikkinäisiltä merkeiltä. 
        
## 6. Mitä opittu, mitkä olivat suurimmat haasteet, mitä kannattaisi tutkia/opiskella lisää jne.
        - Uudenlaista koodia ja ajattelutapaa.
        - Resurssien hyödyntämistä uudella tavalla.
        - Nähdä miten koodi ja graaffinen käyttöliittymä voidaan rakentaa yhdeksi kokonaisuudeksi.
        - Yksi suuri haaste oli saada hakukenttä ottamaan oikeat arvot rikkoutumatta matkan varrella.
        
## 7. Tekijät, vastuiden ja työmäärän jakautuminen.
        - Jonne Okkonen, TTV18S3. Vastasi Coresta (bisnes logiikka) ja unit testing osiosta. Oli osallisena dokumentaatiossa. Toteutti Views Charts sivun.
        - Joonas Niinimäki, TTV18S3. Vastasi käyttöliittymän View osiosta ja Help Page laatimisesta. Oli osallisena dokumentaatiossa. Arvioitu aika ~74h
        
## 8. Tekijöiden arvosanojen ehdotus.

        - Jonne Okkonen:
        
        - Joonas Niinimäki: Arvioin arvosanakseni 5. Vaikka minulla on vielä paljon opittavaa ohjelmoinnissa sillä onhan uranikin nyt lukuvuoden vanha, olen silti tyytyväinen siihen tulokseen mitä saimme aikaan ryhmätasolla ja yksilötasolla.
                            Käyttöliittymä on selkeä ja intuitiivinen, joksei ihan täydellinen, mutta kurssin vaatimuksiin nähden mielestäni ihan sopivan haastava ja laaja työ.
                            Kokonaisuus on mielestäni parhain, siinnä näkee kuinka eri osat ja palaset loksahtelevat kohdalleen vaatimusmäärittelyn tarpeiden mukaan.
                            
                            Toki on myös monta asiaa mitä haluaisin tuoda jatkossa lisää. Puhuin seminaaria edellisenä päivänä, että olisi hyvä jos Search kentissä väärässä syötteessä se ei pyyhkisi kaikkia kenttiä,
                            vaan vain sen väärän syötteen omaavan ja siihen kenttään ylle tulisi virheviesti ilmoitus.
                            Tälläinen käytäntö on teollisuudessa normalisoitu ja hyväksi todettu, ja enemmällä ajalla tai jatkokehityksenä sellainen siihen tulisi.
                            Myös haku kestää hieman turhan kauan, mutta teollisessa työssä serverit ovatkin talon sisäisiä tai vuokrattua tilaa palvelutarjoajalta, eikä yksittäisen ihmisen pyörittämää.
                            Loppujen lopuksi kurssi on ollut mukava ja opettavainen. Kyllä näillä eväillä on hyvä lähteä ensivuoteen opiskelemaan lisää ohjelmointia.