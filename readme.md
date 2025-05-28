# Jummah Management System

A Windows Forms application to manage the organization, scheduling, and reporting of Jummah events, branches, and associated personnel (Dhae). This system is built to streamline the administration of multiple branches, maintain detailed records, and facilitate efficient scheduling and reporting.

---

## Features

### 1. **Branch Management**
- **Add New Branches:** Input all necessary details such as branch name, contact person, address, city, and district.
- **Edit/Update Branch Details:** Modify branch information as needed.
- **Branch Detail Display:** View all registered branches and their respective details in a structured data grid view.
- **Branch Statistics:** Instantly display the total number of branches.

### 2. **Dhae (Speaker/Imam) Management**
- **Add New Dhae:** Capture and store Dhae details including name, contact number, address, city, and district.
- **Edit/Update Dhae Data:** Update existing Dhae information.
- **Dhae List Display:** View all Dhaes in a data grid view for quick reference and management.
- **Dhae Statistics:** Instantly display the total number of Dhaes.

### 3. **City Management**
- **Add and Edit Cities:** Manage the list of available cities for both branches and Dhae entries.
- **City Filtering:** Filter data by city for targeted management and reporting.

### 4. **Jummah Scheduling**
- **Create Schedules:** Assign branches and Dhaes to Jummah events for specific dates.
- **Temporary Scheduling:** Use temporary tables to draft and review schedules before finalizing.
- **Pending Branches Tracking:** Identify branches that have not yet been scheduled for upcoming Jummah events.
- **Schedule List:** Generate, display, and manage the full schedule of Jummah events.

### 5. **Reporting**
- **Attendance and Schedule Reports:** Generate reports on Jummah schedules for any selected date.
- **Dhae Reports:** View and export reports of Dhae assignments and attendance.
- **Branch Reports:** View and export reports on branch participation and details.
- **Filter Reports:** Reports can be filtered by Dhae name, branch name, city, or Jummah incharge person.
- **Export to Excel:** Copy data grid views (including Dhae and incharge reports) directly to Excel for further analysis.

### 6. **Data Integrity and Utilities**
- **Error Handling:** User-friendly error messages for all operations.
- **Form Reset:** Quick reset buttons for clearing form fields when adding or updating data.
- **Clipboard Copy:** Copy entire data grids (Dhae reports, incharge reports) to clipboard for external use.
- **PDF Export (Header Template):** Built-in functionality to create custom headers for PDF exports using Spire.PDF.

### 7. **User Interface**
- **Modern Windows Forms UI:** Intuitive, tab-based navigation for all major functions.
- **Splash Screen:** Optional splash screen display on application launch.
- **Dynamic Panels:** Expand/collapse features for better workspace organization.

---

## Getting Started

1. **Clone the Repository**
   ```sh
   git clone https://github.com/nirzaf/jummahmanagement.git
   ```
2. **Open in Visual Studio**
   - Open the `.sln` file in Visual Studio 2019 or later.
   - Restore NuGet packages (ensure Spire.PDF is installed for PDF functionality).

3. **Configure Database**
   - Set up the required database (schema and connection string details should be configured as per your environment).
   - Ensure tables for branches, Dhae, schedules, and cities are present.

4. **Run the Application**
   - Press `F5` or click **Start** in Visual Studio.

---

## Project Structure

- `JIMMain.cs` / `JummahManagement/JIMMain.cs` — Main form logic, event handlers, and core functionality.
- `BranchBAL`, `DhaeBAL`, `ReportsBAL`, and related classes — Business logic and data access.
- `DhaeData`, `JummahReports` — Data model and reporting helpers.

---
