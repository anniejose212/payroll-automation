# Test Strategy

This test strategy outlines how the **Payroll Test Automation** framework is designed to validate financial and payroll service workflows using an API-first approach. The strategy supports scalability towards UI, reporting, and CI/CD integrations.

---

## 🎯 Objectives of the Test Strategy

| Goal | Description |
|------|-------------|
| Validate Core Workflows | Ensure payroll services (status, submissions, validations) behave correctly |
| Contract Awareness | Use schemas/OpenAPI to validate request and response structures |
| Separation of Layers | API tests first, then UI (Selenium) only where needed |
| Maintainability | Clean architecture that can grow without rewrite |

---

## 🧪 Test Levels

| Level | Purpose | Tools |
|-------|--------|--------|
| **Smoke Tests** | Service availability (`/status`) | RestSharp + WireMock |
| **Functional API Tests** | Endpoint behaviour, response codes | BDD (Reqnroll) |
| **Workflow Tests** | Multi-step payroll processes | Scenario-based BDD |
| **Schema / Contract Tests** | Validate fields & formats | JSON Schema / OpenAPI |
| **UI Smoke (Future)** | Portal flow validation | Selenium WebDriver |

---

## 🏗 Test Design Approach (BDD)

BDD feature files are organised around **business workflows**, not CRUD operations.

**Example Workflow**
```
Scenario: Payroll batch submission succeeds
  Given a valid payroll batch exists
  When I POST it to "/payruns"
  Then I receive a 202 Accepted
  And the batch status becomes "Processed"
  ```
🔌 Mocking & Simulation
Mock Type	Purpose
WireMock.Net	Simulates service endpoints
Stub Workflows	/status, /payruns, /employees
Failure Simulation (Planned)	400, 500, validation errors

Mocks allow safe development before any real service integration.

🗂 Test Data Strategy
Type	Source
Static JSON payloads	Stored under /Contracts or /Support/JsonSchemas
Inline examples	Used in BDD scenarios
Future dynamic sets	Stored in .json or .csv fixtures

📊 Reporting Strategy
Reports will be stored under /Reports.

Report Type	Purpose
NUnit Console	Basic success/fail
ExtentReports (Planned)	HTML dashboard
CI Integration (Optional)	Upload reports to pipeline artifacts

🔁 Execution Strategy
Trigger	Tests Executed
Local Run (dotnet test)	Smoke + Functional
Pre-Merge Check (Future)	Smoke only
Nightly Run (Future)	Full API suite

🌱 Future Extensions
Phase	Add-On
Phase 2	Real OpenAPI + Schema Enforcement
Phase 3	Business Workflows (rollovers, submissions)
Phase 4	UI Selenium Layer (portal flows)
Phase 5	CI/CD & Environment Profiles