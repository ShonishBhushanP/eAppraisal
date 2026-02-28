
# Online Appraisal System - Use Case Diagram Explanation

## 1. Overview

The **Use Case Diagram** depicts the interactions between users (actors) and the Online Appraisal System.  
It highlights the functionality available to different roles: **HR, Manager (Appraiser), and Employee (Appraisee)**.  
The diagram provides a clear understanding of the system’s capabilities and the responsibilities of each actor.

---

## 2. Actors

| Actor | Description |
|-------|-------------|
| HR | Human Resource personnel who manage employee data and assign appraisals |
| Manager | Manager or Appraiser responsible for reviewing and finalizing appraisals of subordinates |
| Employee | Appraisee who provides feedback and updates personal information |
| System | Handles authentication, workflow management, and data integrity |

---

## 3. Use Cases by Actor

### 3.1 HR (Human Resources)

- **Create Employee**: Enter personal and professional details for new employees.
- **View Upcoming Appraisals**: List employees whose appraisal is due.
- **Assign Appraisal**: Allocate employees to respective managers for appraisal processing.

### 3.2 Manager (Appraiser)

- **View Assigned Appraisals**: Access a list of employees under their supervision with upcoming appraisals.
- **Enter Manager Comments**: Provide feedback on achievements, gaps, and suggestions for the employee.
- **Finalize Appraisal**: Approve and complete appraisal workflow, including CTC adjustments.

### 3.3 Employee (Appraisee)

- **Edit Personal Information**: Update personal details such as address, phone, or email.
- **View Manager Comments**: Read manager’s appraisal comments (read-only).
- **Submit Feedback**: Provide feedback and comments on the appraisal process.

### 3.4 System

- **Authenticate User**: Validate login credentials for all actors.
- **Lock Account**: Lock user account after three consecutive failed login attempts.
- **Track Appraisal Status**: Maintain workflow and ensure proper state transitions.

---

## 4. Workflow Summary

1. HR creates employee records and assigns appraisals to managers.
2. Managers review personal information and enter their comments.
3. Employees provide feedback on manager comments.
4. Managers finalize appraisal, including CTC and promotion decisions.
5. System logs all actions and ensures role-based access control.

---

## 5. Benefits of the Use Case Diagram

- **Clarifies System Functionality**: Shows what each role can do.
- **Visualizes Workflow**: Illustrates the appraisal process sequence.
- **Supports Requirement Analysis**: Helps developers and trainees understand system requirements.
- **Ensures Role Separation**: Highlights responsibilities of HR, Managers, and Employees.
- **Facilitates Testing**: Provides a basis for functional testing of each user story.

---

# Conclusion

The Use Case Diagram is essential for understanding the **functional scope** of the Online Appraisal System and ensures a **clear mapping between actors and system features**.
