
# Online Appraisal System - Architecture Diagram Explanation

## 1. Overview

The Online Appraisal System for Nano Technologies is designed as an **intranet-based enterprise application**.  
The architecture follows a **three-tier design**, ensuring clear separation of concerns, scalability, maintainability, and security.

The three primary layers are:
1. **Presentation Layer (UI)** - Web interface for HR, Managers, and Employees
2. **Application / Business Layer** - Handles business logic, workflow, authentication, and authorization
3. **Data Layer** - Centralized relational database storing employees, appraisals, and CTC information

This architecture allows secure and efficient handling of appraisal workflows across multiple regions.

---

## 2. Architecture Components

### 2.1 Users

- HR, Managers, and Employees interact with the system via internal intranet access.
- The system is only accessible within the corporate LAN for security reasons.

### 2.2 Presentation Layer (Web UI)

- Displays role-specific dashboards for HR, Manager, and Employee.
- Provides navigation for:
  - Employee management
  - Appraisal initiation and tracking
  - Feedback submission
  - CTC updates
- Responsible for collecting input and sending requests to the application layer.

### 2.3 Application Layer (Business Logic)

- Manages **Appraisal Workflow Engine**:
  - Tracks appraisal status
  - Handles manager and employee comments
  - Finalizes appraisal and CTC adjustments
- **Authentication & Authorization**:
  - Role-based access control (RBAC)
  - Active Directory integration for SSO
- **Audit & Logging**:
  - Tracks all changes and interactions for compliance

### 2.4 Data Layer (Database)

- Relational Database (e.g., SQL Server or MySQL)
- Stores:
  - Employee personal information
  - Department details
  - Appraisal data
  - Manager and employee comments
  - CTC and promotion history
  - Audit logs
- Enforces referential integrity and secure access through the application layer

### 2.5 Security Components

- **Firewall**: Protects the internal network
- **Active Directory (AD)**: Centralized authentication, account lock after 3 failed login attempts
- **HTTPS**: Encrypts communication
- **Access Control**: Users cannot directly access the database; all access is routed through the application layer

---

## 3. Workflow (Simplified)

1. HR creates or updates employee records.
2. HR assigns employees to managers for appraisal.
3. Managers review personal info, enter comments, and update appraisal status.
4. Employees provide feedback on manager comments.
5. Managers finalize appraisal and update CTC if applicable.
6. Audit logs record all actions for traceability.

---

## 4. Benefits of This Architecture

- **Separation of Concerns**: Each layer handles specific responsibilities.
- **Security**: Sensitive data is protected by layered security measures.
- **Scalability**: Layers can be scaled independently (e.g., multiple web servers or application servers).
- **Maintainability**: Code and data are organized for easier updates.
- **Consistency**: Unified look-and-feel across all user roles.

---

## 5. Future Enhancements

- Load balancing for high availability
- Integration with email notification services
- Reporting dashboards for appraisal analytics
- Multi-level approval workflow
- Cloud migration readiness
