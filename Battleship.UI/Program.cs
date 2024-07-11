using Battleship.UI.Actions;
using Battleship.UI.Interfaces;
using Battleship.UI.Workflows;

Console.WriteLine("Welcome to BATTLESHIP!");
IPlayer p1 = PlayerFactory.GetPlayerImplementation("Is Player 1 a (H)uman or a (C)omputer? ");
IPlayer p2 = PlayerFactory.GetPlayerImplementation("Is Player 2 a (H)uman or a (C)omputer? ");

App app = new App(p1, p2);

app.Run();