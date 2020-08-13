# Faults_Managment
Faults Managment App is a program for managing faults (and their implications) of components in a large and complicated system.
for example , in a model of celluar system, the components will be the sites (base stations) , thr core components : servers,routers,switches, and the end users components :mobile cellphone.

## Main objective

mapping all the components and their known faults/malfunctions in the system.
By that, the program can deduce:

1. for each fault of a component, which other components can affect it ( in a case of a malfunction in them).
2. It can also deduce in a case of a fault, who all the other components which affected by this fault.

![alt text](https://github.com/ofekMula/Faults_Managment/blob/master/images/implications_proj2.JPG)
## How the model is built?

The relations between the objects is defines the implications of each fault of a specific component on other components in the system.
this is why,the Database must be created by the engineer of the system or an expert operator of it.

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

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
