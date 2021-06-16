# Music Center
Shop API for music instruments and accessories. (school project)

# Specification
API supports manipulation over these entites:
* Category
* Brand
* Order
* OrderProduct
* Product
* ProductCategory
* UseCaseLog
* User
* UserCartProduct
* UserUseCase

![Database Diagram](/docs/images/db-diagram.png)

## Authorization
API endpoints `POST`, `PUT`, `DELETE` require authorization token. You can acquire token by loging in on Login endpoint.

Endpoints `GET` as well as Register and Login endpoints **do not** require authorization.

## Email
Upon registering, an email is sent to registered email with a confirmation message. Registering does not require confirming email.

# Notes
To insert initial data to database, call endpoint **Seed**, which will insert around 50 products, 10 users, 10 brands, 10 categories, 15 orders, and other related data.