# xpertEquine
https://www.xpertequine.com/

Component v2
This document contains the design and architecture as implemented for Version2 of page content components written in c# for asp.net. The following diagrams and descriptions will explain the page content components and architecture in detail.


 
Figure 1: Architecture diagram for the page content component
P -> C -> CDR(data) -> C -> P -> HTML -> P

The architecture of this program is laid out such that a user can interface solely with the page portion while utilizing each piece of the components effectively.  It has been architected such that the program should be able to run numerous html components, all abstracted from the user.

The Component block handles component creation and bookkeeping (TODOS: status, error handling), then the Component Data Request block simply fetches the requested data received from component providing the status of each request as well as the desired data that is retrieved by SQL Server procedures.  

Finally, once the request has been completed, the component then calls HTML component. An independent class that will allow any front-end developer easily to navigate and create their desire html. (When all initialized together, the component class can pass the data received into html component to have a fully dynamic snippet).


 

Figure 2: UML Diagram of classes in the page content component

Component(): 
	This class is designed to capture content information such as the current page and the content's location. In addition, the user will be able to establish a list of requested fields for which data from our database is needed. It was also be used to generate a componentDataRequest object and submit our desired fields to their methods, which will populated them with data.
-	sendData()
This method is responsible to send our data to our componentDataRequest object function “genericRequest” or “multipleRequest” to get our desire fields initialized with data. 

ComponentDataRequest():
	This class is intended to be used to fetch and receive data from our database executing store procedures that have been created in sql server. At this moment we are using Web5 server and XpertEquine database.  In addition, once the data has been fetched, we initialize it to our List<Dictionary> variable that will then be called in our component class whenever it is convenient to be used.
-	GenericRequest()
o	This function calls a data table ‘Access’ and runs store procedure that will initialize our OuterData variable and uses table Page_Content. 
-	InnerRequest ()
o	This function calls a data table ‘Access’ and runs store procedure that will initialize our InnerData variable and uses table Page_Inner_Content. 
HTMLComponent():
	This class Implements functions that returns a html snippet. Keeping it abstracted from the intended page.




 

Figure 3: Page implementation of class Component and html snippet 
