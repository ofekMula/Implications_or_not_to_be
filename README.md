# Implications or not to be ("משמעויות או לא להיות")

"משמעויות או לא להיות" it's a program for managing faults (and their implications) of components in a large and complicated system.
In my implementation, it manages components of a celluar system.
The components can be the sites (base stations), servers, routers, switches,etc.

## Main objective

Mapping all the components and their known faults/malfunctions in the system.
By that, the program can deduce:

1. For each component, which other components can affect it ( in a case of a malfunction in them).
2. It can also deduce in a case of a fault, who all the other components which affected by this fault.

The bottom line - the user can have a better understanding of the cellular system in the systemic level, deals better with faults, and also introvent much better the System architecture.


![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/implications_proj2.JPG)

## How the model is built?

The relations between the objects define the implications of each fault of a specific component on other components in the system.
this is why,the Database must be built by the engineer of the system or an expert operator of it.

## Menu options:

![alt text](https://github.com/ofekMula/Implications_or_not_to_be/blob/master/images/implications_proj5.JPG)

## Other features:

1. report a fault through sending mail with gmail.
![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/proj4.jpg)
2. some statistics: number of compnents, number of faults , and faults per components in the system and more.
![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/proj3.jpg)
3. user manging : admin( can edit and update the database) and normal user (cant change the database).


## Installation (runs in Windows only):

Download the FaultManagmentApp folder in the repository.
run the AlertProject.exe file.
important: do not tuch the files in the folder.
the app run is based on these files.

## What I learned
* C# programming language
* Winforms GUI Library
* Use Serialization in reading/writing objects from/to files.
