# IoTBay Site

This project uses dotnet and is run through docker.

## Prerequisites

Follow the instructions here: https://docs.docker.com/get-docker/

## Running

Run the command

`docker compose build`

Then run

`docker compose up`

## Running the database only

To start the database

`docker compose up -d iotbay-db`

To stop the database

`docker compose down`
