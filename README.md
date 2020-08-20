# ATF

Automated Testing Framework is built using WinAppDriver

-  [About WinAppDriver](https://github.com/microsoft/WinAppDriver)

# Inspecting UI Elements

For Inspecting UI Elements below listed tools can be downloaded and used. Learn more:

-   [Accessibility Insights](https://accessibilityinsights.io/)
-   [Inspect](https://docs.microsoft.com/en-us/windows/win32/winauto/inspect-objects)


# System Requirements

-   PC Running on Windows 10(Developer Mode should be enabled)
-   Windows Application Driver should be installed.Latest version can be downloaded:
    [WinAppDriver](https://github.com/Microsoft/WinAppDriver/releases)


## Running tests Locally

### Preparations
-   Clone the repository to your PC
-   Build the Solution 'ATF.sln". It will build all required dependencies.

### Running tests using Resharper and Visual Studio.
-   Open the file in Visual Studio for which you want to run the tests.
-   Click on the round icon which you could see on the left hand side of the class name which is having [TestFixture] attribute. Select 'Run All'. It will run all tests under that class.
-   To run specific test under class click on the round icon which would be present against the test method decorated with [Test] attribute. Select 'Run' to run specific test.

### Running tests using nunit3-console Runner.
-   Open the command line and navigate to "packages\NUnit.ConsoleRunner.3.{x}.0\tools". x refers to the version number
-   To Run all tests for your project, run : `nunit3-console.exe {testbinaryfullpath} --result={resultxml}`
-   To Run Specific Test in Question run : `nunit3-console.exe {testbinaryfullpath} --test={testname} --result={resultxml}`
    where {testbinaryfullpath} would be something like : C:\Test\ATF.Window.Tests.dll, {resultxml} ="c:\Test\Result.xml", {testname}= ATF.Window.Tests.CalculatorTest. testname is combination of {namespace}.{classname}
