using GetAllYourTrello.DataTransferObjects.Board;
using GetAllYourTrello.DataTransferObjects.Lists;
using GetAllYourTrello.DataTransferObjects.Member;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAllYourTrello
{
    // Implementa uma GC para liberar recursos nao utilizados. Seria um padrao de descarte determina um tempo de vida.
    public class Trello : IDisposable
    {
        const string HOST = "https://api.trello.com/";

        private string Key;
        private string Token;

        private bool _disposed;

        private Member _member;
        public Member Member
        {
            get
            {
                if (_member != null) return _member;

                _member = getMember();
                return _member;
            }
        }

        public Trello(string key, string token)
        {
            Key = key;
            Token = token;
        }

        public Member getMember()
        {
            var client = new RestClient(HOST);
            var request = new RestRequest($"/1/tokens/{Token}", Method.GET);

            request.AddParameter("key", Key);

            IRestResponse<Member> response = client.Execute<Member>(request);

            return response.Data;
        }

        public List<Board> getBoards()
        {
            var client = new RestClient(HOST);
            var request = new RestRequest($"/1/members/{Member.idMember}/boards/", Method.GET);

            request.AddParameter("key", Key);
            request.AddParameter("token", Token);
            request.AddParameter("lists", "open");

            IRestResponse<List<Board>> response = client.Execute<List<Board>>(request);

            return response.Data;
        }

        public List<Lists> getLists(string board)
        {
            var client = new RestClient(HOST);
            var request = new RestRequest($"/1/boards/{board}/lists/", Method.GET);

            request.AddParameter("key", Key);
            request.AddParameter("token", Token);
            request.AddParameter("cards", "open");
            request.AddParameter("card_fields", "name");

            IRestResponse<List<Lists>> response = client.Execute<List<Lists>>(request);

            return response.Data;
        }

        public List<BoardMember> getBoardMembers(string board)
        {
            var client = new RestClient(HOST);
            var request = new RestRequest($"/1/boards/{board}/members", Method.GET);

            request.AddParameter("key", Key);
            request.AddParameter("token", Token);

            IRestResponse<List<BoardMember>> response = client.Execute<List<BoardMember>>(request);

            return response.Data;
        }

        public void Dispose()
        {
            Dispose(true); // Limpando as variaveis utilizadas dentro da classe
            GC.SuppressFinalize(this); // Limpando a memoria da propria classe que está sendo utilizada
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                Key = null;
                Token = null;
            }
            _disposed = true;
        }

        ~Trello()
        {
            Dispose(false);
        }


    }
}
