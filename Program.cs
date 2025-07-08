using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe");
            var player1Name = GetPrompt("Enter Player 1 Name");
            var player1Character = GetPrompt("Enter Player 1 Character");
            var player2Name = GetPrompt("Enter Player 2 Name");
            var player2Character = GetPrompt("Enter Player 2 Character");
            if(player1Character==player2Character){
                Console.WriteLine("Player 1 and Player 2 cannot have same character");
                player2Character = GetPrompt("Enter Player 2 Character");
            }
            IHostBuilder hostBuilder=Host.CreateDefaultBuilder(args);
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<Board>();
        });
        
        IHost host=hostBuilder.Build();

        var board = host.Services.GetRequiredService<Board>();  
            var player1 = Player.CreateBuilderPlayer().SetName(player1Name).SetCharacter(player1Character).Build();
            var player2 = Player.CreateBuilderPlayer().SetName(player2Name).SetCharacter(player2Character).Build();
            var dashBoard= DashBoard.CreateBuilderDashBoard().SetBoard(board).Build();
            var checkWin = CheckWin.CreateBuilderCheckWin().SetBoard(board).Build();
            var game = Game.CreateBuilderGame().SetPlayer1(player1).SetPlayer2(player2).SetCheckWin(checkWin).SetDashBoard(dashBoard).Build();
                 game.Play();
        }

        public static string GetPrompt(string a)
        {
            Console.WriteLine(a);
            return Console.ReadLine();
        }
    }


