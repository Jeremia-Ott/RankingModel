// See https://aka.ms/new-console-template for more information
using RankingModel;

Console.WriteLine("Hello, World!");

var player = new Player(1300, 0);

for (int i = 0; i < 1000; i++)
{
    player.PlayGame();
}

Console.WriteLine(player);
