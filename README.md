# Implications or not to be ("משמעויות או לא להיות")

It's an app which developed in order to manage faults (and their implications) of components in a large and complicated system.
In my implementation, it manages components of a celluar system.
The components are be the sites (base stations) ,servers,routers,switches and more.

## Main objective

mapping all the components and their known faults/malfunctions in the system.
By that, the program can deduce:

1. for each fault of a component, which other components can affect it ( in a case of a malfunction in them).
2. It can also deduce in a case of a fault, who all the other components which affected by this fault.

![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/implications_proj2.JPG)

## How the model is built?

The relations between the objects is defines the implications of each fault of a specific component on other components in the system.
this is why,the Database must be created by the engineer of the system or an expert operator of it.

## Menu options:

![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/proj5.jpg)

## Other features:

1. report a fault through sending mail with gmail.
![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/proj4.jpg)
2. some statistics: number of compnents, number of faults , and faults per components in the system and more.
![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/proj3.jpg)
3. user manging : admin( can edit and update the database) and normal user (cant change the database).


## Installation (runs in Windows only):

download the FaultManagmentApp folder in the repository.
then run the AlertProject.exe file.
important: do not tuch the files in the folder.
the app run is based on these files.


