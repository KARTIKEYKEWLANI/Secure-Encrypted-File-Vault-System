# 🔐 Password Vault – Secure Credentials Manager

## Overview

Password Vault is a secure credential management application developed using C# and .NET 7. The project enables users to store, retrieve, and manage website credentials securely through password encryption. It is designed to demonstrate secure data handling, encryption techniques, and database integration using Entity Framework Core and MySQL.

## Features

* Master Password Authentication
* Secure Storage of Credentials
* AES-Based Password Encryption
* Credential Retrieval and Decryption
* Delete Stored Credentials
* MySQL Database Integration
* Entity Framework Core ORM Support
* Console-Based User Interface

## Technology Stack

* C#
* .NET 7
* Entity Framework Core
* MySQL
* AES Encryption
* Visual Studio / Visual Studio for Mac

## Project Structure

```text
PASSWORDVAULT/
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Credential.cs
│
├── Services/
│   └── PasswordServices.cs
│
├── Migrations/
│
├── Program.cs
│
└── PASSWORDVAULT.csproj
```

## Security Features

### Master Password Protection

Users must enter the correct master password before accessing the vault.

### AES Encryption

All stored passwords are encrypted before being saved to the database, ensuring sensitive information is protected from unauthorized access.

### Credential Management

Users can:

* Add Credentials
* View Stored Credentials
* Delete Credentials

## Database Configuration

The application uses MySQL with Entity Framework Core for persistent credential storage.

Example database:

```sql
Database Name: vault_db
```

## Installation

### Clone Repository

```bash
git clone https://github.com/KARTIKEYKEWLANI/Secure-Encrypted-File-Vault-System.git
```

### Navigate to Project

```bash
cd Secure-Encrypted-File-Vault-System
```

### Restore Dependencies

```bash
dotnet restore
```

### Run the Application

```bash
dotnet run
```

## Sample Workflow

1. Launch application.
2. Enter master password.
3. Select an option:

   * Add Credential
   * View Credentials
   * Delete Credential
   * Exit
4. Credentials are encrypted before storage.
5. Stored credentials can be securely retrieved when required.

## Learning Outcomes

This project demonstrates:

* Secure Password Storage
* Cryptography Fundamentals
* Database Management with EF Core
* Object-Oriented Programming in C#
* CRUD Operations
* Secure Software Development Practices

## Future Enhancements

* Password Strength Checker
* Random Password Generator
* Web-Based User Interface
* Biometric Authentication (WebAuthn / Touch ID)
* Cloud Backup Support
* Multi-User Authentication
* Audit Logging

## Author

**Kartikey Kewlani**

Cybersecurity and Software Development Enthusiast

GitHub: https://github.com/KARTIKEYKEWLANI
