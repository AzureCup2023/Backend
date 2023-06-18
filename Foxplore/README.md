# Foxplore - backend

Foxplore backend is simple database API for Foxplore frontend.

## Purpose
For the purpose of PoC (Proof of Concept) we have created a simple API that will serve as a database for the frontend. For the purpose of PoC we have decided to use simple in-memory-database (IMDB) that can be easily replaced with more robust database in the future thanks to the EFCore.

Database contains tables with various points of interest (PoI) that are located in the city of Prague. Each PoI has a name, type, and a location. All this easily is extensible.

## Data
Points of interests are gathered from open data available online on [Prague Open Data](https://www.geoportalpraha.cz/en/data/opendata/list). Data is then processed and stored in the database.

Available PoIs:
 - Landmarks
 - Viewpoints
 - Parks
 - Monuments
 - Greenery

## Deployment
The API is deployed on Azure but can not be accessed due to security reasons. If you want to deploy it on your own, feel free to follow steps on [Microsoft Docs](https://learn.microsoft.com/en-us/azure/azure-app-configuration).