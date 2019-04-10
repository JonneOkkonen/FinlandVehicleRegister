# Ajoneuvorekisteri API
----
  Returns given query result in JSON format. 

* **URL**

  https://jonneokkonen.com/api/ajoneuvorekisteri.php?apiKey=9rP91EIhlOfiVVO5SZ1Bf2311U?query=SELECT * FROM Ajoneuvo;

* **Method:**

  `GET`
  
*  **URL Params**

   **Required:**
 
   `apiKey=9rP91EIhlOfiVVO5SZ1Bf2311U`,
   `query=SELECT * FROM Ajoneuvo`,

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** `{ id : 12 }`
 
* **Error Response:**

  <_Most endpoints will have many ways they can fail. From unauthorized access, to wrongful parameters etc. All of those should be liste d here. It might seem repetitive, but it helps prevent assumptions from being made where they should be._>

  * **Code:** 401 UNAUTHORIZED <br />
    **Content:** `{ error : "Log in" }`

  OR

  * **Code:** 422 UNPROCESSABLE ENTRY <br />
    **Content:** `{ error : "Email Invalid" }`

* **Notes:**

  <_This is where all uncertainties, commentary, discussion etc. can go. I recommend timestamping and identifying oneself when leaving comments here._> 