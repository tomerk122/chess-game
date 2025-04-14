# HalfChess Game

HalfChess is a modified chess game implemented with a client-server architecture. The project consists of a Windows Forms client application and an ASP.NET Core web server that maintains game history and provides AI gameplay capability.

## Project Overview

HalfChess is a chess variant played on a half-sized board, featuring modified rules while maintaining the essence of traditional chess. The game includes:

- Chess pieces including King, Rook, Bishop, Knight, and Pawn with standard movement patterns
- Player vs Computer gameplay
- Game history tracking and statistics
- Database integration for storing games and player information

## System Architecture

The project consists of two main components:

### HalfChessClient
- Windows Forms application (.NET Framework)
- Provides the user interface for the chess game
- Manages game state, piece movement, and rule enforcement
- Connects to the server for AI moves and game history

### HalfChessServer
- ASP.NET Core web application
- Provides REST API endpoints for the client
- Implements game AI for computer moves
- Stores game history and player information
- Provides a web interface to view statistics and game history

## Project Structure

```
chess-game/
├── .gitignore
├── README.md
├── 3.database/
│   └── HalfChessDB.dacpac           # Database schema package
├── 4.known issues/
│   └── Issues.txt                   # Known issues documentation
├── HalfChessClient/                 # Client application
│   ├── Board.cs                     # Chess board representation
│   ├── Cell.cs                      # Board cell implementation
│   ├── ChessCells.cs               
│   ├── DbHelper.cs                  # Database helper functions
│   ├── Form1.cs                     # Main form implementation
│   ├── Game.cs                      # Game logic
│   ├── GameEngine.cs                # Core game engine
│   ├── HttpClientHelper.cs          # API communication helper
│   ├── Images.cs                    # Chess piece image management
│   ├── LoadGameWindow.cs            # Game loading interface
│   ├── MainWindow.cs                # Main application window
│   ├── Piece.cs                     # Chess piece implementation
│   ├── PromoWindow.cs               # Pawn promotion window
│   ├── Rules.cs                     # Chess rules implementation
│   └── ...
└── HalfChessServer/                 # Server application
    ├── Api/                         # API controllers
    │   ├── Game/                    # Game logic implementation
    │   │   ├── Board.cs
    │   │   ├── Cell.cs
    │   │   ├── Game.cs
    │   │   ├── Piece.cs
    │   │   └── Rules.cs
    │   └── GamesController.cs       # Game API controller
    ├── Data/                        # Data access layer
    ├── Models/                      # Data models
    ├── Pages/                       # Razor pages for web interface
    │   ├── Histories/               # Game history pages
    │   ├── Players/                 # Player management pages
    │   └── Queries/                 # Statistical query pages
    └── ...
```

## Features

- **Chess Game Logic**: Implementation of chess rules including piece movement, captures, check, and checkmate
- **Special Moves**: Support for pawn promotion
- **AI Opponent**: Computer player with move generation based on game rules
- **Game History**: Recording and playback of previous games
- **Player Statistics**: Tracking of wins, losses, and other statistics
- **Web Interface**: Browser-based access to game history and statistics

## Technical Details

### Client Application (HalfChessClient)

- **Game Board**: Represented by an 8x8 grid of cells
- **Piece Movement**: Each piece type (King, Rook, Bishop, Knight, Pawn) has specific movement patterns
- **Rules Engine**: Validates moves according to chess rules, including preventing moves that would leave the king in check
- **Move Generation**: Creates a list of all legal moves for a piece
- **User Interface**: Visual representation of the board, pieces, and game state

### Server Application (HalfChessServer)

- **Game API**: REST endpoints for generating computer moves
- **Database**: Stores game history, moves, and player information
- **Web Interface**: Razor Pages for viewing game history and statistics
- **Server-Side Game Logic**: Duplicates the client rules for move validation and generation

## Getting Started

### Prerequisites

- Visual Studio 2019 or newer
- .NET Framework 4.7.2 or newer (for client)
- .NET Core 6.0 or newer (for server)
- SQL Server (for database)

### Setup

1. **Database Setup**:
   - Import the database schema from `3.database/HalfChessDB.dacpac`
   - Update connection strings in the client and server configuration files

2. **Server Setup**:
   - Open `HalfChessServer/HalfChessServer.sln` in Visual Studio
   - Restore NuGet packages
   - Build and run the server application

3. **Client Setup**:
   - Open `HalfChessClient/HalfChessClient.sln` in Visual Studio
   - Restore NuGet packages
   - Update the server URL in `HttpClientHelper.cs` if necessary
   - Build and run the client application

## How to Play

1. Launch the HalfChessClient application
2. Register as a new player or select an existing player
3. Start a new game - you will play as White, and the computer as Black
4. Click on a piece to see available moves (highlighted in green)
5. Click on a destination square to move the piece
6. The computer will automatically make its move after yours
7. The game continues until checkmate, stalemate, or only kings remain

## Game Rules

- Standard chess piece movement applies
- Pawn promotion occurs when a pawn reaches the opposite end of the board
- Check and checkmate work as in standard chess
- The game ends when a player is checkmated, stalemated, or only kings remain

## Additional Information

For known issues and limitations, see the `4.known issues/Issues.txt` file.
