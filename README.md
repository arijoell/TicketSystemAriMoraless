# Ticket System AriMorales

El sistema se desarrolla en **Visual Studio 2026**, utilizando **.NET 10 y C# 14**, incorporando autenticación con **Individual Accounts** y persistencia de datos mediante **SQL Server con Entity Framework Core**.

---

#  Project Overview

Support Ticket System es una plataforma Web interna para la gestión de tickets de soporte técnico, orientada a entornos organizacionales donde múltiples departamentos requieren reportar incidencias tecnológicas y recibir atención estructurada por parte del equipo de soporte.

---

# Technology Stack

* Visual Studio 2026
* .NET 10
* C# 14
* Blazor Web App (Unified Template)
* Interactive Server Render Mode
* ASP.NET Core Identity (Individual Accounts)
* Entity Framework Core
* SQL Server
* Git
* GitHub

---

#  Project Architecture

Este proyecto utiliza la estructura de la plantilla unificada **Blazor Web App (Interactive Server)**.

Características principales del proyecto:

* Single project structure
* Server-side execution
* Built-in Identity system
* Integración con Entity Framework Core

---

#  Authentication & Authorization

La autenticación está configurada utilizando:

* Individual Accounts
* ASP.NET Core Identity
* SQL Server database
* Restricciones de interfaz basadas en roles

---

# 🗄 Database

## Provider

SQL Server (LocalDB para desarrollo)

## Current Tables

Tablas de usuarios generadas por **ASP.NET Identity**:

* AspNetUsers
* AspNetRoles
* AspNetUserRoles
* AspNetUserClaims
* AspNetUserLogins
* AspNetUserTokens

---

#  Roles del sistema (Planeados)

Los roles del sistema serán:

* Admin
* Technician
* Employee

Estos roles serán implementados en módulos posteriores.

---

# 🗺 Hoja de Ruta del desarrollo (Development Roadmap)

| Módulo   | Descripción                                 | Estado       |
| -------- | ------------------------------------------- | ------------ |
| Módulo 1 | Creación del Proyecto SystemLastName        | ✅ Completado |
| Módulo 2 | Fundamentos de EF Core en Blazor Web App    | ✅ Completado |
| Módulo 3 | Modelado del Dominio del Sistema de Tickets | ⏳ Pending    |
| Módulo 4 | CRUD Básico de Tickets                      | ⏳ Pending    |
| Módulo 5 | Sistema de Roles y Seguridad                | ⏳ Pending    |
| Módulo 6 | Deployment                                  | ⏳ Pending    |

---

# 🚀 Características Implementadas

## Módulo 1: Creación del Proyecto SystemLastName

* Blazor Web App proyecto creado
* Interactive Server enabled
* Identity configurado
* Registro de usuarios funcionando

### Checkpoint

* ✔ Proyecto Blazor Web App creado con .NET 10 y C# 14
* ✔ Uso de **App.razor**, **MainLayout.razor** y **Home.razor**
* ✔ Personalización básica de la UI

---

## Módulo 2: Fundamentos de EF Core en Blazor Web App

* Base de datos configurada correctamente
* Migraciones iniciales creadas
* Conexión entre Blazor y EF Core funcionando

## Checkpoint

* ✔ Conexión establecida con SQL Server local
* ✔ Uso de Primary Constructors en DbContext
* ✔ Base de datos creada mediante migraciones

---

#  Historia de Migraciones

* InitialIdentityMigration
* AddTicketEntity

---

#  Getting Started

## Requirements

Para ejecutar el proyecto se necesita:

* Visual Studio 2026
* .NET 10 SDK
* SQL Server LocalDB

---

## Run the Project

El proyecto se puede ejecutar de dos maneras.

### Desde Visual Studio

Presionar:

Ctrl + F5

### Desde terminal

```bash
dotnet run
```

#  Licencia

Proyecto educativo desarrollado para el curso de FullStack.
