# Architecture Overview

This documentation explains the internal structure and technical architecture of the **Payroll Test Automation** framework.  
The project is designed with clarity, maintainability, and real-world scalability in mind while remaining beginner-friendly.

---

## 🏗 Core Design Principles

| Principle | Application in Framework |
|----------|--------------------------|
| **API-First Testing** | Focus on service workflows before UI automation |
| **Separation of Concerns** | Contracts, Test Logic, Support code all isolated |
| **Beginner-Friendly Code** | Minimal abstractions, readable step definitions |
| **Scalable Design** | Future support for UI Selenium and CI/CD |

---

## 🧱 Solution Structure

payroll-automation/
│
├── Contracts/ # OpenAPI YAML, JSON Schemas (domain contracts)
│
├── Tests.Api/ # API test project
│ ├── Features/ # Reqnroll Gherkin tests (.feature)
│ ├── Steps/ # C# step definitions
│ ├── Support/ # Helpers, API server mocks, utilities
│ └── appsettings.json # Config for Base URLs, environments
│
├── Reports/ # Automated test reports (HTML/XML)
│
└── docs/ # Internal documentation


---

## 🔁 Test Execution Lifecycle

1️ **WireMock Server Starts**  
   - Bootstrapped via `[SetUpFixture]`  
   - Mocks real backend services (e.g., `/status`, later payroll endpoints)

2️ **BDD Feature Triggered**  
   - Reqnroll reads `.feature` file  
   - Maps each step to code in `Steps/`

3️ **API Requests via RestSharp**  
   - Requests sent to mock or live server  
   - Responses captured and validated via NUnit assertions

4️ **Test Cleanup**  
   - Mock server stopped and disposed  
   - Reports saved under `/Reports`

---

## 👨‍💻 Technology Roles

| Component | Responsibility |
|----------|-----------------|
| **Reqnroll (BDD)** | Reads `.feature` files and maps steps |
| **NUnit** | Test runner and assertion engine |
| **RestSharp** | Sends HTTP API requests |
| **WireMock.Net** | Simulates backend API responses |
| **appsettings.json** | Centralized configuration |

---

## 🔌 Mocking via WireMock

WireMock creates a **fake API server** simulating realistic behaviour such as:
- Status endpoints (`/status`)
- Future payroll workflow stubs (`/payrun`, `/employee`, `/batch`)
- Error simulation (`400`, `422`, `500`)

This allows full testing without external dependencies or live credentials.

```
_server.Given(Request.Create().WithPath("/status").UsingGet())
       .RespondWith(Response.Create()
           .WithStatusCode(200)
           .WithHeader("Content-Type", "application/json")
           .WithBody("{\"ok\":true}"));
```
🧱 Future Layer: UI (Selenium)
The architecture reserves space for a UI layer:


/Tests.Ui/
  ├── Pages/
  ├── Features/
  ├── Steps/
This UI layer will:

Reuse the same BDD conventions

Automate web portal flows (login, batch submission, status view)

Stay thin after API logic

📦 Why Contracts Folder Exists
The Contracts/ folder is reserved for:

OpenAPI (.yaml) specs (e.g., payroll services, HR APIs)

JSON Schemas for request/response validation

Future contract testing (e.g., Pact)

This makes the framework schema-driven, not hardcoded.

🎯 Summary
Layer	Responsibility
Contracts	Defines the domain model & API schemas
Tests.Api	Executes API workflows & assertions
Reports	Stores run outputs
docs	Framework documentation & strategy