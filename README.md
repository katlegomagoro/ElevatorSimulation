# ElevatorSimulation

A real-time, modular C# console application that simulates elevator movement in a multi-floor building using clean architecture and SOLID principles.

---

## Project Overview

This application simulates the behavior of elevators in a multi-story building. It allows users to:
- Call elevators from any floor
- Specify how many people are waiting
- View elevator status as they move between floors
- Select destination floors for passengers
- Handle capacity constraints realistically

---

## Tech Stack

The project is built with modern .NET tools and follows a layered architecture:

- .NET 7 - application framework
- C# 10 - language features
- Visual Studio 2022 - development environment
- Git & GitHub - version control
- Clean Architecture - separation of concerns
- xUnit (planned) - unit testing support
- GitHub Actions (planned) - CI/CD for builds and tests

---

## Project Structure

The project is organised into logical layers to keep things maintainable and testable:

- `Models`  
  Defines the elevator entity and any other supporting data structures.

- `Services`  
  Contains core logic for elevator movement, dispatching, and passenger handling.

- `Helpers`  
  Utility classes like input validation.

- `UI`  
  Console interactions, status output, and user input prompts.

- `Program.cs`  
  The entry point. It wires everything together and runs the main loop.

---

## Pseudocode Reference

This project is based on structured, . Below is a simplified view of the logic that drives the application this is what i do for planning to build good logic for the Code.

### Step 1: Initialization
```plaintext
DECLARE TOTAL_FLOORS, TOTAL_ELEVATORS
DECLARE ELEVATORS AS LIST OF Elevator
DECLARE DISPATCHER_SERVICE AS DispatcherService
DECLARE CONSOLE_UI AS ConsoleUI
DECLARE SYSTEM_ACTIVE AS BOOLEAN = TRUE

FOR I FROM 1 TO TOTAL_ELEVATORS DO
    CREATE NEW Elevator WITH ID = I, Floor = 1
    ADD TO ELEVATORS
END FOR

DISPLAY "Elevator System Ready."
```

### STEP 2: Main User Loop
```plaintext
WHILE SYSTEM_ACTIVE = TRUE DO
    DISPLAY elevator status
    PROMPT "CALL or EXIT?"
    IF CALL THEN
        CALL ConsoleUI.HandleElevatorRequest(...)
    ELSE IF EXIT THEN
        SET SYSTEM_ACTIVE = FALSE
END WHILE

```

### STEP 3: Handle Elevator Request
```plaintext
PROMPT user for current floor
VALIDATE using InputValidator

PROMPT number of passengers
VALIDATE > 0

DISPATCH best elevator using DispatcherService
MOVE elevator to user floor
BOARD passengers

PROMPT destination floor
VALIDATE again

MOVE elevator to destination
UNLOAD passengers
```

---

## How to Build & Run

Make sure you have .NET 7 SDK installed.

```bash
git clone https://github.com/katlegomagoro/ElevatorSimulation.git
cd ElevatorSimulation
dotnet build
dotnet run
```

You can also open the ElevatorSimulation.sln file in Visual Studio and run the app with Ctrl + F5.

---

## Git Workflow & Commit History

This repo uses meaningful commit messages like:
Everything is versioned intentionally to show software engineering practice.

---

## Testing & CI/CD (In Progress)

- GitHub repo is structured for unit test support (`ElevatorSimulation.Tests`)
- CI pipeline using GitHub Actions will be added soon
- `.gitignore` excludes build artifacts, IDE clutter

---

##Author

Made by [@katlegomagoro](https://github.com/katlegomagoro) 

## Contact Information
For any questions or support, please contact:
Name: Katlego Magoro
Email: katlegomagoro98@gmail.com
LinkedIn: https://www.linkedin.com/in/katlego-magoro-288b08236/
Feel free to reach out with any inquiries.

---

