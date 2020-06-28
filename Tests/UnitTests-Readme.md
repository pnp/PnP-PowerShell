# Unit tests

Unit tests for PnP Powershell are undergoing a revamp, this area may grow or change, and maybe subject to test breakages in the short term.

## Tips for Writing Tests

### Organising tests

* The tests are organised in a subfolder and namespace that matches the cmdlets in the main project for easy findability and association of tests.
* Each cmdlet should have its own test class.
* A test placeholder has been pre-generated for 

### Performance

* Aim for quickest possible test, if a test requires a component to be setup that is time consuming or has a long running operation, this 
should be added to the test suite setup as a one time setup.
* [TestInitialize] and [TestCleanup] runs on EACH test, if you have setup requirements for a suite of tests use [ClassInitialize] and [ClassCleanup]

### Sites

When writing your tests ensure that you utilise the existing sites set out by the requirements for running the suite of tests.
Site creation for certiain template types can take a long time to execute and risk timing out the test run.


# Notes

## Useful attributes on a test

* [Priority] - assigns priority in tests
* [Ignore]  - disables the test