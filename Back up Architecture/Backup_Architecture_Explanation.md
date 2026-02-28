
# Backup Architecture Explanation – Intranet Appraisal System

## 1. Overview

This diagram represents the Backup and Disaster Recovery (DR) architecture for the Intranet-based Online Appraisal System.

The design follows a layered enterprise backup approach:

- On-Premises Backup (Primary Protection)
- Offsite Backup & Disaster Recovery (Secondary Protection)
- Security & Compliance Controls

The architecture ensures high availability, minimal data loss, and enterprise-grade protection for sensitive HR data.

---

## 2. On-Premises Backup Layer

### 2.1 Web Server (UI Layer)
- Hosts the front-end application.
- Weekly VM snapshot recommended.
- IIS configuration export maintained separately.
- Source code stored in version control (Git).

### 2.2 Application Server (Business Logic Layer)
- Handles workflow, appraisal logic, authentication integration.
- Weekly VM snapshot.
- Configuration backup maintained separately.
- Redeployable using installation package.

### 2.3 Database Server (SQL) – Most Critical Component

The database stores:
- Employee personal data
- PAN & Passport details
- Salary (CTC) details
- Appraisal history
- Audit logs

Recommended Backup Strategy:

- Full Backup – Weekly
- Differential Backup – Daily
- Transaction Log Backup – Every 15 minutes

This enables Point-in-Time Recovery.

---

## 3. Local Backup Storage

- Stored in NAS/SAN storage.
- Used for fast restore scenarios.
- First layer of recovery in case of minor failures.

Backup Flow:

SQL Database  
→ Local Backup Disk  
→ NAS/SAN Storage  

---

## 4. Offsite Backup & Disaster Recovery

To protect against:

- Datacenter failure
- Ransomware attacks
- Natural disasters
- Hardware corruption

Encrypted backups are replicated to:

- Cloud Backup Vault
- Disaster Recovery (DR) Datacenter

Encrypted Replication ensures secure transfer.

---

## 5. RPO & RTO Strategy

### RPO (Recovery Point Objective)
15 Minutes  
Maximum acceptable data loss = 15 minutes.

### RTO (Recovery Time Objective)
Less than 2 Hours  
System must be restored within 2 hours.

---

## 6. Security Controls

Because the system contains sensitive HR data, the following protections are implemented:

- AES-256 Backup Encryption
- Restricted Access to Backup Storage
- Immutable Backups (Ransomware Protection)
- Quarterly Restore Testing
- Role-based Access Control (RBAC)

---

## 7. Recovery Scenarios

### Minor Failure (Database Corruption)
Restore from:
Local Backup Storage

### Server Failure
Restore VM Snapshot

### Datacenter Failure
Activate:
Disaster Recovery Site

---

## 8. Architectural Benefits

- Layered protection (Local + Offsite)
- Enterprise-grade security
- Minimal data loss
- Business continuity readiness
- Compliance-friendly design
- Scalable architecture

---

# Conclusion

This backup architecture ensures the Online Appraisal System remains:

- Secure
- Highly available
- Disaster resilient
- Enterprise compliant

It follows best practices for protecting critical HR and salary data in an intranet environment.
