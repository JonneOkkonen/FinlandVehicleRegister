# Ajoneuvorekisteri API
----
  Returns given query result in JSON format. 

## URL

  `https://www.jonneokkonen.com/api/ajoneuvorekisteri.php?apiKey=9rP91EIhlOfiVVO5SZ1Bf2311U&query=SELECT * FROM Vehicle LIMIT 1;`

## Method

  `GET`

## URL Params

### Required
 
`apiKey=9rP91EIhlOfiVVO5SZ1Bf2311U`  
`query=SELECT * FROM Vehicle LIMIT 1`

## Success Response

  * **Code:** 200 <br />
    **Content:** 
    ```json
    [{
    	"ID": "5486",
    	"ajoneuvoluokka_koodi": "L3e",
    	"ajoneuvoluokka_lyhytselite": "MoottoripyÃ¶rÃ¤",
    	"ajoneuvoluokka_pitkaselite": "KaksipyÃ¶rÃ¤inen ajoneuvo, Vi > 50 cm3 ja\/tai v > 45 km\/h,",
    	"ensirekisterointipvm": "2007-03-16",
    	"ajoneuvoryhma": "2-pyÃ¶rÃ¤inen",
    	"ajoneuvonkaytto": "Yksityinen",
    	"variantti": "D4F",
    	"versio": "GHAAB0",
    	"kayttoonottopvm": "2007-03-16",
    	"vari": null,
    	"ovienLukumaara": null,
    	"korityyppi_koodi": null,
    	"korityyppi_pitkaselite": null,
    	"ohjaamotyyppi": "Avo-ohjaamo",
    	"istumapaikkojenLkm": "2",
    	"omamassa": "305",
    	"teknSuurSallKokmassa": "492",
    	"tieliikSuurSallKokmassa": "492",
    	"ajonKokPituus": "2360",
    	"ajonLeveys": "940",
    	"ajonKorkeus": null,
    	"kayttovoima": "Bensiini",
    	"iskutilavuus": "1584",
    	"suurinNettoteho": "56",
    	"sylintereidenLkm": "2",
    	"ahdin": null,
    	"sahkohybridi": null,
    	"sahkohybridinluokka": null,
    	"merkkiSelvakielinen": "Harley-Davidson",
    	"mallimerkinta": "FXDB-GX4\/1584",
    	"vaihteisto": null,
    	"vaihteidenLkm": "6",
    	"kaupallinenNimi": "FXDB DYNA STREET BOB",
    	"voimanvalJaTehostamistapa": "2",
    	"tyyppihyvaksyntanro": "e4*2002\/24*0414*02",
    	"yksittaisKayttovoima": "1",
    	"kunta": "Helsinki",
    	"Co2": null,
    	"matkamittarilukema": null,
    	"alue": "4",
    	"valmistenumero2": null
    }]
    ```
 
## Error Response

  * **Code:** 200 <br />
    **Content:** 
    ```json
    [{
        "error": "Incorrect API - key"
    }]
    ```

       OR

  * **Code:** 200 <br />
    **Content:** 
    ```json
    [{
        "error": "Query was empty"
    }]
    ```
    
       OR

  * **Code:** 200 <br />
    **Content:** 
    ```json
    [{
        "error": "0 results from query"
    }]
    ```
       OR
  
  * **Code:** 200 <br />
    **Content:**   
    ```json
    [{
        "error" : "You have an error in your SQL syntax; check the manual 
        that corresponds to your MySQL server version for the right syntax to 
        use near 'Ajoneuvo LIMIT 1' at line 1"
        
    }]
    ```
