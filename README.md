# Simple Library Management System

This project is a simple yet effective **Library Management System** developed using **C#**, **Entity Framework Core**, and **SQL Server**. It was created as part of an EF Core course to practice and apply fundamental concepts in software development and database management.

## Features

### 1. User Authentication
- **Secure Login:** Users and admins can log in using their email and password.
- **Role-Based Access:** The system distinguishes between regular users and admins, providing different functionalities based on their roles.

### 2. Admin Dashboard
- **Add New Books:** Admins can add new books to the library database.
- **Delete Books:** Admins can delete books by their ID.

### 3. User Capabilities
- **Browse Books:** Users can browse all available books in the library.
- **View Reviews:** Users can view reviews for specific books.
- **Submit Reviews:** Users can submit their own reviews for the books they have read.

## Technology Stack
- **C#:** The primary programming language used to build the application.
- **Entity Framework Core:** Used as the ORM (Object-Relational Mapping) tool for database interactions.
- **SQL Server:** The database management system used to store and manage data.
- **Console Application:** The project is implemented as a simple console application, providing an easy-to-navigate text-based interface.

## Database Structure

The system uses three main tables:

1. **Users:** Stores user information, including username, email, password hash, and role (User or Admin).
2. **Books:** Contains details about the books in the library, such as title, author, price, and published year.
3. **Reviews:** Stores user reviews for books, including rating, review text, and the date of the review.

## Future Enhancements

Some potential improvements that could be added to the system include:
- **User Management:** Allow admins to edit or delete user accounts.
- **Book Updates:** Provide functionality for admins to update book details.
- **Advanced Search:** Implement a search feature for books based on different criteria (e.g., author, title, published year).
