# Car Dealership Web App

Welcome to the Car Dealership App!

This app is made to resemble a car dealership management system. It includes a database for managing cars in the dealership.

The user can edit, delete, and insert cars, as well as view details about existing ones.

Additionally, the user can filter cars by searching for their manufacturer (by make).

## Inserting Initial Database
> Note: Data insertion is entirely optional. If you prefer to use your own dataset, feel free to skip this step and proceed with your own data.

To insert data into the app, follow these steps:

1. Open the Package Manager Console and enter the following commands:

    ```
    enable-migrations
    add-migration "initialsetup"
    update-database
    ```

2. Find the migrated database in SQL Server Object Explorer.

3. Insert the query from `DataBaseQuery.txt` into the project database.

## Admin Access

After acquiring provided database you can access the registrated user features using the following credentials:

- **Email:** admin@gmail.com
- **Password:** Car123456789*



