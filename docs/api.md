# Ajoneuvorekisteri API
----
  Returns given query result in JSON format. 

## URL

  `https://www.jonneokkonen.com/api/ajoneuvorekisteri.php?apiKey=9rP91EIhlOfiVVO5SZ1Bf2311U?query=SELECT * FROM Ajoneuvo LIMIT 1;`

## Method

  `GET`

## URL Params

### Required
 
`apiKey=9rP91EIhlOfiVVO5SZ1Bf2311U`  
`query=SELECT * FROM Ajoneuvo LIMIT 1`

## Success Response

  * **Code:** 200 <br />
    **Content:** 
    ```json
    [{
    	"ID": "1",
    	"ajoneuvoluokka": "MUU",
    	"ensirekisterointipvm": null,
    	"ajoneuvoryhma": "21",
    	"ajoneuvonkaytto": "1",
    	"variantti": null,
    	"versio": null,
    	"kayttoonottopvm": "1967-01-01",
    	"vari": null,
    	"ovienLukumaara": null,
    	"korityyppi": null,
    	"ohjaamotyyppi": null,
    	"istumapaikkojenLkm": "1",
    	"omamassa": "210",
    	"teknSuurSallKokmassa": null,
    	"tieliikSuurSallKokmassa": null,
    	"ajonKokPituus": null,
    	"ajonLeveys": null,
    	"ajonKorkeus": null,
    	"kayttovoima": "1",
    	"iskutilavuus": "590",
    	"suurinNettoteho": null,
    	"sylintereidenLkm": null,
    	"ahdin": null,
    	"sahkohybridi": null,
    	"sahkohybridinluokka": null,
    	"merkkiSelvakielinen": "BMW",
    	"mallimerkinta": "R60\/590",
    	"vaihteisto": null,
    	"vaihteidenLkm": null,
    	"kaupallinenNimi": null,
    	"voimanvalJaTehostamistapa": null,
    	"tyyppihyvaksyntanro": null,
    	"yksittaisKayttovoima": "1",
    	"kunta": "49",
    	"Co2": null,
    	"matkamittarilukema": null,
    	"alue": "27",
    	"valmistenumero2": null,
    	"jarnro": "1"
    }]
    ```
 
## Error Response

  * **Code:** 200 <br />
    **Content:** ```json[{"error": "Incorrect API - key"}]```

       OR

  * **Code:** 200 <br />
    **Content:** ```json[{"error": "Query was empty"}]```

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
