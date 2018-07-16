# Path of Lowest Cost

The objective is to find the optimum path while moving across a grid from left to right. 

The mobile-app is built in Xamarin.Forms (which implements a custom renderer for `MatrixCell` which is basically an extended `Entry` control).

For async operations, we are using `TPL` for building/calculating paths in a background thread; and `async`-`await` for context switching.

### Solution structure:

Section | Projects | Description
--- | --- | ---
Contracts | `XCC.Contracts` | Specifies contract to be adhered to while implementing components.
Utilities | `XCC.Utilities` | Contains implementation for various components such as input-parser(s), and path-builder(s).
Data | `XCC.Data` | Acts as source for sets of data representing sample input and expected output. Mostly used for unit-tests, and loading data in demo app.
Console runner | `ConsoleSandbox` | Terminal based sandbox app for taking in input and displaying output.
Automated tests | `XCC.Utilities.Tests` | Unit tests for components such as input-parser(s), and path-builder(s). 
Mobile App | `XCC.DemoApp`, `XCC.DemoApp.Android`, `XCC.DemoApp.iOS`  | Mobile app as GUI for path-builder.

### Instructions:

* **Use automated unit tests**

  `NUnit` console/IDE runners can be used to test the components. All of the unit tests are available in `XCC.Utilities.Tests` project.
    
* **Use console application**

  Set `ConsoleSandbox` as startup project, and run. 
  
  ![console-runner-gif](https://github.com/shads-labs/XamarinCodeChallenge/blob/master/images/console-runner.gif "")

* **Use mobile app**
  
  Set `XCC.DemoApp.Android` or `XCC.DemoApp.iOS` as startup project, and run. You can either use an hardcoded sample, or manually input values (upto 10x10 grid).
  
  ![sample-runner-gif](https://github.com/shads-labs/XamarinCodeChallenge/blob/master/images/sample-runner.gif "")
  
  ![manual-input-gif](https://github.com/shads-labs/XamarinCodeChallenge/blob/master/images/manual-input.gif "")

  
  
  
  

