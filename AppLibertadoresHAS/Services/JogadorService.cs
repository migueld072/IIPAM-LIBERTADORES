using AppLibertadoresHAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.Services
{
    public class JogadorService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://apilibertadores-luiz-hzhucrffc5b2hqa2.mexicocentral-01.azurewebsites.net/Jogadores";

        // Variável para armazenar o token do usuário autenticado
        private readonly string _token;

        // Construtor: inicializa o token recuperando da Preferences (mesma chave usada no login)
        public JogadorService()
        {
            _request = new Request();
            _token = Preferences.Get("UsuarioToken", string.Empty);
        }

        public async Task<ObservableCollection<Jogador>> GetJogadoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Jogador> lista =
                await _request.GetAsync<ObservableCollection<Jogador>>(_apiUrlBase + urlComplementar, _token);

            return lista;
        }

        public async Task<Jogador> GetJogadorAsync(int id)
        {
            string urlComplementar = $"/{id}";

            Jogador jogador = await _request.GetAsync<Jogador>(_apiUrlBase + urlComplementar, _token);

            return jogador;
        }

        public async Task<Jogador> PostJogadorAsync(Jogador j)
        {
            int id = await _request.PostReturnIntAsync<Jogador>(_apiUrlBase, j, _token);
            j.Id = id;
            return j;
        }



    }

}
