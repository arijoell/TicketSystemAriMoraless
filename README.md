# Ticket System AriMoraless

## Descripción

Support Ticket System es una aplicación web desarrollada en Blazor que permite a los usuarios crear y gestionar tickets de soporte técnico. El sistema simula un entorno organizacional donde empleados pueden reportar problemas y el equipo técnico puede gestionarlos.

---

## Tecnologías Utilizadas

- Visual Studio 2026  
- .NET 10  
- C# 14  
- Blazor Web App (Interactive Server)  
- ASP.NET Core Identity  
- Entity Framework Core  
- SQL Server (LocalDB)  
- Git y GitHub  

---

## Funcionalidades Implementadas

### 🔐 Autenticación
- Registro de usuarios
- Login
- Manejo de sesiones con ASP.NET Identity

### 🎫 Sistema de Tickets
- Crear tickets
- Seleccionar categoría
- Asignar prioridad
- Guardado en base de datos

### 🗂 Categorías
- Hardware
- Software
- Network

### 👤 Roles del Sistema
- Admin
- Technician
- Employee

Se implementó control de acceso utilizando roles en la interfaz.

---

## Base de Datos

Se utilizó SQL Server con Entity Framework Core.

### Tablas principales:
- AspNetUsers
- AspNetRoles
- AspNetUserRoles
- Tickets
- Categories

---

## Evidencia del Sistema

A continuación se muestran capturas del sistema en funcionamiento:

1. Pantalla de inicio (Home)
2. Registro de usuario
3. Login
4. Usuario autenticado
5. Creación de Ticket
6. Vista de base de datos (SQL Server)
7. Tabla de usuarios (AspNetUsers)

---

## Ejecución del Proyecto

### Requisitos
- Visual Studio 2026  
- .NET 10 SDK  
- SQL Server LocalDB  

### Ejecutar en Visual Studio
Presionar:

