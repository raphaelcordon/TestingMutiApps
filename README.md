# TestingMultiApps

## Table of Contents

- [Introduction](#introduction)
- [Application](#application)
- [Instructions](#instructions)

---

## **INTRODUCTION**

- .Net studying project to practice: Integration between different projects within the same solution.
  - Web API
  - .Net MVC

---

## **APPLICATION**

#### WebApi: 
 - CRUD of USER
 - Persistency in MySQL
 - Swagger is activated
    

#### WebMVC:
- Web interface to CRUD USERs

---

## **INSTRUCTIONS**

- This is a study project to be run locally only.
- **Web API** must have the following steps to work properly:
  - Connection string within secrets:
      {
        "ConnectionString": 
        {
          "UsersDbConn": "Your DB's connection string"
        }
      }
  - Set the DB structure. Via CLI, execute:
    -   dotnet ef database update
    
---
