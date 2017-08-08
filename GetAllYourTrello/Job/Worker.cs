using System;
using System.Configuration;

namespace GetAllYourTrello.Job
{
    public class Worker : IWorker
    {
        public void Execute()
        {
            Console.WriteLine("Iniciando o Worker!");

            var TrelloKey = ConfigurationManager.AppSettings["TrelloKey"];
            var TrelloToken = ConfigurationManager.AppSettings["TrelloToken"];

            using (Trello trello = new Trello(TrelloKey, TrelloToken))
            {

                trello.getBoards().ForEach(board =>
                {
                    // 1 - Board possui os dados necessarios para salva-lo dentro do TimeTracker
                    Console.WriteLine("----> BOARD");
                    Console.WriteLine($"#{board.id} {board.name}");


                    Console.WriteLine("------------> MEMBERS");
                    // 2 - Verificando os integrantes do board.
                    trello.getBoardMembers(board.id).ForEach(member =>
                    {
                        Console.WriteLine($"#{member.id} - {member.fullName}");
                    });

                    // 3 - A lista seria (do, doing, done)
                    trello.getLists(board.id).ForEach(list =>
                    {
                        Console.WriteLine("------------------------> LIST");
                        Console.WriteLine($"#{list.id} - {list.name}");


                        Console.WriteLine("-------------------------------------> CARDS");

                        // 4 - Buscando as cards relacionado lista, que seria as Tasks do TimeTracker.
                        list.cards.ForEach(card =>
                        {
                            Console.WriteLine($"#{card.id} - {card.name}");
                        });

                    });

                    Console.WriteLine($"#{board.id} {board.name}");

                });

                Console.WriteLine("DONE");

            };

        }
    }
}
