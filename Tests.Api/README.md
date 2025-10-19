# Payroll Test Automation

This is a personal learning and showcase project focused on building a robust **Payroll API Test Automation Framework** using C# and .NET 8.  
It demonstrates an **API-first approach**, followed by mock service testing, BDD design, and extensibility for UI and reporting.

---

## 🎯 Objectives
- Learn and apply real-world test automation practices.
- Showcase clean, maintainable test architecture.
- Build a reusable foundation for any API-driven financial or payroll domain.

---

## 🧱 Tech Stack

| Area        | Tools & Frameworks        |
|-------------|---------------------------|
| Language    | C# (.NET 8)               |
| Test        | NUnit + Reqnroll (BDD)    |
| API Client  | RestSharp                 |
| Mock Server | WireMock.Net              |
| Config      | appsettings.json          |
| Reporting   | Extent / NUnit HTML (planned) |
| CI/CD       | GitHub Actions (future)   |

---

## 🧩 Project Structure
```
payroll-automation/
├── Contracts/ # OpenAPI, JSON Schemas, domain contracts
├── Tests.Api/ # API layer tests
│ ├── Features/ # Gherkin (.feature) files
│ ├── Steps/ # Step definitions
│ ├── Support/ # Helpers, mocks, config
│ └── appsettings.json
├── Reports/ # Test output
└── docs/ # Architecture & Test Strategy
```

---

## 🚀 Getting Started

### 1. Prerequisites
- Install [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
- Install Visual Studio 2022 or JetBrains Rider

### 2. Clone & Build
```
git clone https://github.com/<yourusername>/payroll-automation.git
cd payroll-automation
dotnet build
```
3. Run Tests

```
dotnet test
```

✅ This will:

Start a local WireMock server (http://localhost:9091)

Execute a smoke test (/status endpoint)

Display results in console

🧪 Example Feature
File: Tests.Api/Features/PayrollSmoke.feature

```
Feature: Payroll API smoke
  @smoke
  Scenario: Service is up
    Given the payroll API is available
    When I GET "/status"
    Then the response code is 200
```

📊 Reporting
Reports will be stored in:

```
/Reports/
  └── sample-run/
       └── index.html
```       
Planned:

ExtentReports or NUnit HTML

Allure for CI integration

🧭 Roadmap
Phase	Goal
Step 1	✅ Framework bootstrap
Step 2	OpenAPI Contract + Real Endpoints
Step 3	Workflow & Error Tests
Step 4	UI Integration (Selenium)
Step 5	CI/CD + Reporting

🧘 Author
Annie Jose
QA Automation Enthusiast
LinkedIn
