# Intranet-Based Online Appraisal System

## Deployment Architecture Explanation

------------------------------------------------------------------------

## 1. Overview

The Online Appraisal System is deployed as an **intranet application**
within the organization's internal network.\
It follows a **secure multi-tier deployment model** to ensure:

-   High security
-   Role-based access control
-   Performance
-   Scalability
-   Controlled internal access

The deployment is fully isolated within the corporate LAN environment.

------------------------------------------------------------------------

## 2. High-Level Deployment Flow

Users (HR / Manager / Employee) ↓ Internal Company LAN ↓ IIS / Web
Server ↓ Application Server (Business Logic Layer) ↓ Database Server
(SQL Database)

Security layers such as Firewall and Active Directory protect the
system.

------------------------------------------------------------------------

## 3. Component Explanation

### 3.1 Users (HR, Manager, Employee)

Users access the system from:

-   Office desktops
-   Corporate laptops
-   Devices connected to internal LAN

Access is restricted to internal company network only.

------------------------------------------------------------------------

### 3.2 Internal Company LAN

The Local Area Network (LAN):

-   Provides internal connectivity
-   Ensures traffic does not leave company boundary
-   Uses internal routing and DNS resolution

All requests originate inside this secure network.

------------------------------------------------------------------------

### 3.3 Internal DNS

Responsible for:

-   Resolving application URL (e.g., appraisal.nano.local)
-   Routing traffic to correct web server
-   Supporting internal service discovery

No public DNS exposure.

------------------------------------------------------------------------

### 3.4 Active Directory (AD)

Used for:

-   Centralized authentication
-   Role mapping (HR / Manager / Employee)
-   Account lock after 3 failed attempts
-   Password policy enforcement

Supports Single Sign-On (SSO) if required.

------------------------------------------------------------------------

### 3.5 Firewall

Security boundary that:

-   Blocks external internet traffic
-   Restricts port access
-   Protects database from direct access
-   Allows only required internal traffic

Creates a secure internal application zone.

------------------------------------------------------------------------

### 3.6 IIS / Web Server (Presentation Layer)

Hosts the:

-   Web Application (HR Portal, Manager Portal, Employee Portal)
-   UI Layer
-   Static content

Responsibilities:

-   HTTPS termination
-   Session handling
-   Forwarding API requests to Application Server

------------------------------------------------------------------------

### 3.7 Application Server (Business Logic Layer)

Contains:

-   Appraisal Workflow Engine
-   Authentication & Authorization logic
-   Notification services
-   Business rules validation
-   Appraisal status tracking

Ensures separation of concerns from UI.

------------------------------------------------------------------------

### 3.8 Database Server (SQL Database)

Stores:

-   Employee records
-   Appraisal records
-   Manager comments
-   Employee feedback
-   CTC details
-   Audit logs

Security Controls:

-   No direct access from users
-   Accessible only via Application Server
-   Encrypted data at rest
-   Regular backups

------------------------------------------------------------------------

## 4. Security Architecture

The system enforces multiple security layers:

1.  Network-level security (Firewall)
2.  Identity-based access control (Active Directory)
3.  Role-Based Access Control (RBAC)
4.  Account lock after 3 invalid login attempts
5.  Encrypted communication (HTTPS)
6.  Database access restriction
7.  Audit logging for traceability

This ensures confidential data like PAN, Salary, and CTC are protected.

------------------------------------------------------------------------

## 5. Scalability Considerations

The architecture supports scaling:

-   Web server can be load balanced
-   Application server can be horizontally scaled
-   Database can be configured for clustering or replication

Suitable for 1000+ employees across multiple regions.

------------------------------------------------------------------------

## 6. Deployment Strategy

The system can be deployed using:

-   Installation package (MSI)
-   Automated deployment scripts
-   CI/CD pipelines
-   IIS configuration automation
-   Database migration scripts

Minimal manual intervention required.

------------------------------------------------------------------------

## 7. Benefits of This Deployment Model

-   Fully secure intranet-only access
-   Clear separation of tiers
-   Easy maintenance
-   Centralized authentication
-   High performance within LAN
-   Easy future cloud migration path

------------------------------------------------------------------------

## 8. Future Enhancements

-   High availability with multiple web servers
-   Disaster recovery database
-   Monitoring & logging tools integration
-   Email notification server integration
-   Hybrid cloud readiness

------------------------------------------------------------------------

# Conclusion

The intranet-based deployment ensures that the Online Appraisal System
is secure, scalable, maintainable, and enterprise-ready.\
It follows industry best practices for layered architecture and
controlled internal network access.
