Feature: Payroll API smoke
  Simple availability check

  @smoke
  Scenario: Service is up
    Given the payroll API is available
    When I GET "/status"
    Then the response code is 200
