using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using TesteArgo.Models;

namespace TesteArgo
{
    public class teste3
    {
        ///www.omdbapi.com/
        const string ApiKey = "18693fd6";

        /// <summary>
        /// By Search
        /// www.omdbapi.com/?s=titulo&apikey=18693fd6
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Filme> ListarFilmes(string filtro)
        {
            var w = new WebClient();
            var json = w.DownloadString("http://www.omdbapi.com/?s=titulo&apikey=18693fd6");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var objeto = jss.Deserialize<ObjetoJson>(json).Search.Where(x => x.Title.Contains(filtro)) ;

            List<Filme> resultado = new List<Filme>();
            foreach (Search search in objeto)
            {
                Filme item = new Filme
                {
                    ID = search.imdbID,
                    Ano = search.Year,
                    Imagem = search.Poster,
                    Titulo = search.Title
                };
                resultado.Add(item);
            }

            return resultado;
        }

        /// <summary>
        /// By ID or Title
        /// www.omdbapi.com/?i=tt0372784&apikey=18693fd6
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Filme ListarPorId(string id)
        {
            var w = new WebClient();
            var json = w.DownloadString("http://www.omdbapi.com/?s=titulo&apikey=18693fd6");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var objeto = jss.Deserialize<ObjetoJson>(json).Search.FirstOrDefault(x => x.imdbID.Equals(id));

            if (objeto != null)
            {
                Filme resultado = new Filme
                {
                    ID = objeto.imdbID,
                    Ano = objeto.Year,
                    Imagem = objeto.Poster,
                    Titulo = objeto.Title
                };
                return resultado;
            }
            return null;
 
        }
    }
    public class ObjetoJson {
        public List<Search> Search { get; set; }
        public int totalResults { get; set; }
        public bool Response { get; set; }
    }
    public class Search {
        public string Title { get; set; }
        public int Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

    }
}
