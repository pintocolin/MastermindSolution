# Technical Design Document

## Design Patterns & Principles
- **Separation of Concerns:** By isolating logic in the `.Core` project, the game engine could be reused in a Web API or MAUI app without changes.
- **Single Responsibility (SRP):** The `GameEngine` is only responsible for game rules, while `Program.cs` is only responsible for I/O.
- **Defensive Programming:** The application validates all user input for length, type, and range to prevent runtime exceptions.

## Highlevel Task
1. **Game Initialization**
	Generate a random 4-digit number each digit ranges from 1 to 6.
2. **User Input Handling**
	Prompt the user for a 4-digit guess and validate the input.
3. **Feedback Calculation**
	Compare the user's guess with the correct answer and generate feedback.
4. **Game Loop Control**
	Repeat the game loop until the user guesses correctly or chooses to exit, capped at 10 attempts.


## Algorithmic Approach
The core algorithm for calculating the feedback (the `+` and `-` symbols) is based on comparing the user's guess with the correct answer. 
It first counts the exact matches (`+`) and then counts the partial matches (`-`) without double-counting any digits.
- This is achieved via a two-pass linear scan to ensure O(n) time complexity while maintaining exact match priority.

## Edge Case Handling
The implementation specifically addresses the "duplicate digit" problem. 
*Example: Answer [1,2,1,1] vs Guess [1,1,2,2].*
The algorithm correctly returns `+--` rather than over-counting the secondary matches.