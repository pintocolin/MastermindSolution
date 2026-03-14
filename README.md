# Mastermind Console Implementation

A robust, unit-tested C# implementation of the classic Mastermind game, built with a focus on Clean Architecture and SOLID principles.

## 🚀 Architectural Overview
For this exercise, I chose a **decoupled architecture** to ensure the core game logic is independent of the user interface.

- **Mastermind.Core**: A Class Library containing the "brain" of the game. It handles hint generation and input validation.
- **Mastermind.Console**: The UI layer that manages user interaction and the game loop.
- **Mastermind.Tests**: An xUnit suite that verifies the hint logic against various edge cases (duplicates, near-misses, etc.).

## 🧩 The Hint Algorithm
The core challenge of Mastermind is accurately calculating hints without "double-counting" duplicate digits. I implemented a **Two-Pass Algorithm**:
1. **Pass One:** Identifies exact matches (`+`) and marks those positions as "used."
2. **Pass Two:** Scans remaining digits for value matches in the wrong position (`-`) while respecting the "used" flags from the first pass.

## 🛠️ How to Run
1. Ensure you have the .NET 10 SDK installed.
2. Clone the repository.
3. From the root directory, run:
   ```bash
   dotnet run --project Mastermind.Console