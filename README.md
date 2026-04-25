# 🎟️ Ticket System AriMoraless

## 📌 Descripción

Support Ticket System es una aplicación web desarrollada en **Blazor Web App** que permite a los usuarios crear y gestionar tickets de soporte técnico.

El sistema simula un entorno organizacional donde:

* Los empleados reportan problemas
* Los administradores gestionan los tickets
* Los técnicos trabajan los tickets asignados

---

## 🚀 Tecnologías Utilizadas

* Visual Studio 2026
* .NET 10
* C# 14
* Blazor Web App (Interactive Server)
* ASP.NET Core Identity
* Entity Framework Core
* SQL Server (LocalDB)
* Bootstrap 5
* Git y GitHub

---

## 🔐 Autenticación

* Registro de usuarios
* Login
* Manejo de sesiones con ASP.NET Identity
* Control de acceso por roles

---

## 🎫 Sistema de Tickets

* Crear tickets
* Seleccionar categoría
* Guardado en base de datos
* Asignación de técnicos
* Cambio de estado del ticket

---

## 🗂 Categorías

* Hardware
* Software
* Network

---

## 👤 Roles del Sistema

* **Admin**
* **Technician**
* **Employee**

Los roles se gestionan mediante la tabla intermedia `AspNetUserRoles`.

---

## 🚀 Funcionalidades Módulo 6

### 👑 Panel Administrativo

* Visualización de todos los tickets en el sistema
* Acceso al **Admin Dashboard**
* Asignación de técnicos a los tickets

### 🧑‍🔧 Gestión de Tickets

* Página **Manage Ticket**
* Asignación de técnicos
* Cambio de estado del ticket:

  * Open
  * InProgress
  * Resolved

### 📋 My Tickets

* Página accesible para empleados y técnicos
* Los empleados ven los tickets que crearon
* Los técnicos ven los tickets asignados

### 🔒 Control de Acceso por Roles

* Uso de `AuthorizeView` para restringir funcionalidades
* Admin → acceso completo
* Technician → gestiona tickets asignados
* Employee → solo crea y visualiza sus tickets

---

## 📊 Funcionalidades Módulo 7

### 📈 Dashboard Administrativo

* Visualización de estadísticas en tiempo real:

  * Total de tickets
  * Tickets abiertos / en progreso
  * Tickets resueltos
* Cards visuales con Bootstrap 5
* Tabla con todos los tickets del sistema

### 👥 User Management

* Página para administrar usuarios
* Asignación dinámica de roles:

  * Admin
  * Technician
  * Employee
* Uso de `UserManager` para gestión de roles
* Actualización en tiempo real sin recargar la página

---

## 🏗️ Funcionalidades Módulo 8

### 🔧 Refactorización del Proyecto

Se reorganizó la estructura del sistema para mejorar la mantenibilidad y escalabilidad:

#### 📁 Nueva estructura:

* **Models**

  * Ticket
  * Category

* **Data**

  * ApplicationDbContext
  * ApplicationUser
  * Roles

* **Enums**

  * TicketStatus

* **Services**

  * TicketService

* **Components**

  * Layout
  * Pages (Admin, Tickets)

---

### 🧠 Mejoras Implementadas

* Separación de responsabilidades por carpetas
* Corrección de namespaces en todo el proyecto
* Centralización de directivas `@using` en `_Imports.razor`
* Código más limpio y organizado
* Validación completa del sistema tras refactorización

---

## 🔄 Flujo Completo del Sistema

1. El empleado crea un ticket
2. El administrador lo visualiza en el Dashboard
3. El administrador asigna un técnico
4. El técnico accede a "My Tickets"
5. El técnico trabaja el ticket
6. El técnico cambia el estado del ticket

---

## 🗄️ Base de Datos

Se utilizó SQL Server con Entity Framework Core.

### Tablas principales:

* `AspNetUsers`
* `AspNetRoles`
* `AspNetUserRoles`
* `Tickets`
* `Categories`

---

## 📸 Evidencia del Sistema

El sistema fue probado con:

* Login como Admin, Technician y Employee
* Creación de tickets
* Asignación de roles
* Cambio de estado de tickets
* Visualización en Dashboard
* Gestión de usuarios en User Management
* Validación de datos en SQL Server

---

## ▶️ Ejecución del Proyecto

### Requisitos

* Visual Studio 2026
* .NET 10 SDK
* SQL Server LocalDB

### Ejecutar en Visual Studio

1. Abrir el proyecto
2. Ejecutar migraciones si es necesario
3. Presionar `F5`

---

## 📂 Repositorio

GitHub:
👉 https://github.com/arijoel/TicketSystemAriMoraless

---

## 👨‍💻 Autor

**Ari Joel Morales Torres**
Universidad de Puerto Rico - Recinto de Ponce
Bachillerato en Ciencias en Computadoras

---

## 📅 Curso

Estructura de Datos / Sistemas de Información
Módulos 6, 7 y 8 - Sistema de Tickets Completo

