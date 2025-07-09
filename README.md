# TicTacToe

This is a command-line based **Tic Tac Toe** game built in **C#**.  
It allows **two players** to register with their names and choose their own custom symbol (like `X`, `O`, `@`, etc.). The game is played on a **3x3 board**, and each move is tracked by typing the **box address**.

## 🎮 How the Game Works

1. When the application starts, it asks for:
   - **Player 1 Name**
   - **Player 1 Symbol**
   - **Player 2 Name**
   - **Player 2 Symbol**
   - *(Symbols must be unique and non-empty)*

2. The game then displays a 3x3 board with numbered positions 00","01","02","10","11","12","20","21","22" like below:


3. Players take turns entering the **box address (1-9)** where they want to place their symbol.

4. After each move, the board updates, and the system automatically checks:
- All **rows**
- All **columns**
- Both **diagonals**

to determine if a player has won.

5. If one of the players manages to align 3 of their symbols horizontally, vertically, or diagonally, that player is declared the **winner**.

6. If all 9 boxes are filled and there's no winner, the game ends in a **draw**.

## 🧠 Game Rules

- Players cannot choose a box that is already filled.
- Symbols must be **different** for both players.
- Input validation is done to ensure players don't enter invalid box addresses or duplicate symbols.

## ✅ Features

- Two-player registration
- Custom symbols
- Input validation
- Real-time win condition check (row, column, diagonal)
- Clean, user-friendly matrix-style board UI
- Game ends with either a win or draw

## 🛠️ Requirements

- .NET 9.0 SDK or above
- Any C#-compatible IDE (Visual Studio, VS Code) or command line

## ▶️ How to Run

1. Clone or download the repository.
2. Open the project in your IDE or navigate to the folder via terminal.
3. Run the application:

```bash
dotnet run
