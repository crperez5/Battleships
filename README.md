# Battleships

A simple version of the game Battleships (see video below). The game allows a single human player to play a one-sided game of Battleships against ships placed by the computer.



The program creates a 10x10 grid, and place several ships on the grid at random with the following sizes:



1x Battleship (5 squares)



2x Destroyers (4 squares)



The player enters or selects coordinates of the form “A5”, where “A” is the column and “5” is the row, to specify a square to target. Shots result in hits, misses or sinks. The game ends when all ships are sunk.


## Solution

The solution is composed of two projects:

### DependencyResolver.UI
A graphical user interface implemented in Blazor.

### DependencyResolver.Application
Game logic.

## In Addition
Check out game rules:
Game Rules: https://www.hasbro.com/common/instruct/Battleship.PDF
Video describing game: https://www.youtube.com/watch?v=q0qpQ8doUp8

## Author

* **Cristian Perez Matturro** 

Check out my web site: https://crperez.dev
