# Lärpäke
Electronical Luuppi Lärpäke. Track who attends the most events in their freshman year!

## About

<img src="https://github.com/user-attachments/assets/02668fb1-df04-47ac-91d2-2f3162df7630" width="320" align="right" alt="Image of Lärpäke" />

This repository contains implementation for the new generation of freshman event attendance cards (aka Lärpäke). 

Luuppi is student organization for computer science, mathematics and statistical data analysis students in Tampere University Finland. 

Fuksilärpäke is traditional part of freshman year for students in Luuppi. Fresmen compete on who gathers the most points during their freshman year. You can get points by fro example attending different events organized by Luuppi and other university organizations. Those with the most points are awarded with different prizes at the Luuppi Christmas party.  

## Technologies

### Web API

<img src="https://github.com/user-attachments/assets/e20ade74-437f-49c9-aa22-6472866b1986" width="60" align="right" alt="c sharp logo" />

`ASP.NET Core` `.NET9` `C#` `C# 13` `Web API` `Controllers` `REST` `JWT` `OpenApi Scalar` `Dependency Injection`

In the heart of the Lärpäke is the REST api implemented using ASP.NET Core Web API with controllers. Api is implemented using RESTful architechture and fro easier use, OpenApi Scalar is used to visualize api endpoints and their request data. Authentication and authorization are implemented using json web tokens (JWT). As usual, services are managed by dependency injection (DI). 


#### Database
`SQLite` `Dapper`

The web API uses SQLite database to store all the data created by user clients. Dapper ORM is used in the C# code to map sql queries into.
For those interested, database graphs can be found `Wiki` -pages under `Database Graphs` ([here](https://github.com/henrivain/Larpake/wiki/Diagrams)).

#### Api Events

`SSE`

Web api serves Server Sent Events (SSE) for subscribed clients when user's event attendance is marked as completed hereby causing UI update. 

### Front End

Front end technologies are in the works. It will probably be web UI and not a mobile application at first.
For UI design drawings see `Wiki` -> `Design` ([here](https://github.com/henrivain/Larpake/wiki/Design)).

## Project Timeline

This project is meant to be production ready for Freshmen starting their studies in fall 2025. Front end development will start soon.  



### Client
TODO: Choose which one of the millions of js frameworks to use

## Contributors
@henrivain

## Support & Features

For support and feature requests open issue in Github (see `Issues` -page)
You can also email at
matikkaeditorinkaantaja(at)gmail.com (don't ask why this is one of my email addresses)

<details>

<summary>Aika on rahaa?</summary>

### Tähän projektiin kulutettu aika

#### @henrivain
[![wakatime](https://wakatime.com/badge/user/33becafa-9125-4b20-b55e-a824ccc490f1/project/ad9cdb99-5373-46b4-8af9-a789d14f6abc.svg)](https://wakatime.com/badge/user/33becafa-9125-4b20-b55e-a824ccc490f1/project/ad9cdb99-5373-46b4-8af9-a789d14f6abc)

</details>
