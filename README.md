# 🎟️ Ticket System AriMoraless

## 📌 Descripción

Ticket System AriMoraless es una aplicación web desarrollada en **Blazor Web App** para la administración de tickets de soporte técnico dentro de un entorno organizacional.

El sistema permite que los empleados reporten incidencias técnicas, mientras que los administradores asignan técnicos y supervisan el flujo completo de soporte. Los técnicos pueden trabajar los tickets asignados, actualizar estados y mantener comunicación directa con los usuarios mediante un sistema integrado de comentarios.

---

# 🚀 Tecnologías Utilizadas

* Visual Studio 2026
* .NET 10
* C# 14
* Blazor Web App (Interactive Server)
* ASP.NET Core Identity
* Entity Framework Core
* SQL Server (LocalDB)
* Bootstrap 5
* ClosedXML
* JavaScript Interop
* Git y GitHub

---

# 🔐 Sistema de Autenticación

* Registro de usuarios
* Inicio de sesión
* Manejo de sesiones
* ASP.NET Core Identity
* Control de acceso basado en roles (RBAC)

---

# 👤 Roles del Sistema

## 🔴 Admin

* Acceso completo al sistema
* Gestión de usuarios
* Dashboard administrativo
* Asignación de técnicos
* Exportación de reportes Excel

## 🔵 Technician

* Visualización de tickets asignados
* Manejo de estados
* Comunicación con empleados

## 🟢 Employee

* Creación de tickets
* Seguimiento de solicitudes
* Comunicación mediante comentarios

---

# 🎫 Sistema de Tickets

* Creación de tickets
* Categorías dinámicas
* Prioridades
* Asignación de técnicos
* Estados del ticket:

  * Open
  * InProgress
  * Resolved
* Manejo de comentarios
* Bitácora automática del sistema

---

# 💬 Sistema de Comunicación

El sistema implementa un canal de comunicación interno dentro de cada ticket.

## Funcionalidades:

* Comentarios entre empleados y técnicos
* Etiquetas visuales por rol
* Historial cronológico
* Mensajes automáticos del sistema
* Registro de eventos importantes

Ejemplos:

* Técnico asignado
* Cambio de estado
* Ticket resuelto

---

# 📊 Dashboard Administrativo

El Dashboard permite:

* Visualizar todos los tickets
* Ver estadísticas en tiempo real
* Monitorear tickets abiertos y resueltos
* Acceder a la gestión administrativa
* Exportar reportes SLA en Excel

---

# 📈 Sistema de Reportes

Se implementó generación dinámica de reportes usando **ClosedXML**.

## Reportes:

* Exportación a Excel (.xlsx)
* Tiempo de resolución de tickets
* Tickets abiertos y resueltos
* Técnicos asignados
* Métricas SLA

---

# 🏗️ Arquitectura del Proyecto

El proyecto sigue principios de separación de responsabilidades (SoC).

## 📁 Estructura

### /Data

Contiene:

* ApplicationDbContext
* ApplicationUser
* Roles
* Migraciones

### /Models

Contiene:

* Ticket
* Category
* TicketComment

### /Services

Implementa:

* TicketService
* Lógica de negocio
* Estadísticas
* Reportes
* Comunicación

### /Components

Contiene:

* Layout
* Navegación
* Páginas Razor

### /Components/Pages/Admin

* Dashboard
* UserManagement

### /Components/Pages/Tickets

* CreateTicket
* MyTickets
* ManageTicket

### /Enums

* TicketStatus
* TicketPriority

### /wwwroot

Archivos estáticos:

* CSS
* JavaScript
* downloadHelper.js

---

# 🔄 Flujo del Sistema

1. El empleado crea un ticket
2. El administrador visualiza el ticket
3. El administrador asigna un técnico
4. El técnico recibe el ticket
5. Se inicia comunicación interna
6. El técnico cambia estados
7. El ticket se resuelve
8. El sistema registra eventos automáticos

---

# 🗄️ Base de Datos

El sistema utiliza SQL Server con Entity Framework Core.

## Tablas principales:

* AspNetUsers
* AspNetRoles
* AspNetUserRoles
* Tickets
* Categories
* TicketComments

---

# 📸 Validaciones y Evidencias

El sistema fue probado mediante:

* Login con múltiples roles
* Creación masiva de tickets
* Comunicación entre usuarios
* Dashboard administrativo
* Gestión de roles
* Exportación de Excel
* Persistencia de datos
* Validación en SQL Server
* Seguridad basada en roles

---

# ▶️ Ejecución del Proyecto

## Requisitos

* Visual Studio 2026
* .NET 10 SDK
* SQL Server LocalDB

## Pasos

1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Restaurar paquetes NuGet
4. Ejecutar migraciones
5. Presionar F5

---

# 📂 Repositorio

GitHub:
https://github.com/arijoell/TicketSystemAriMoraless

---

# 👨‍💻 Autor

Ari Joel Morales Torres

Universidad de Puerto Rico - Recinto de Ponce

Bachillerato en Ciencias en Computadoras

---

# 📅 Curso

Estructura de Datos / Sistemas de Información

Proyecto Final — Sistema Completo de Gestión de Tickets
