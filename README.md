
<p align="center">
  <img width="360" height="240" src="https://upload.wikimedia.org/wikipedia/commons/7/7d/Microsoft_.NET_logo.svg">
</p>

<h2>Home Appliance API</h2>

Simple RESTful API application developed with `.NET 6` to collect data from `Raspberry PI` . 

Collected data is stored to `MS SQL Database`.

Data can be fetched to be display on dashboard.

<h2>Routes</h2>

| Route |	METHOD |	BODY |	Response |
| ------------- | ------------- |------------- | ------------- |
| `/Measurements?offsetDays=`  | `GET`  | -  | `List<Measurement>`  |
| `/Measurements`  | `POST`  | `{"temperature": double,  "humidity": double,  "measuredOnUnixTime": long}`  | -  |
| `/Measurements/last`  | `GET`  | -  | `Measurement`  |

<h2>Tests</h2>
Tested controllers, services and repositories with `xUnit`.

![image](https://github.com/kestv/home-appliance-api/assets/23400391/0b6cd436-b762-4d26-a4b2-e6002c234796)
