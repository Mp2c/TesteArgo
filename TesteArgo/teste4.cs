using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteArgo.Models;
using System.Data.SqlClient;

namespace TesteArgo
{
    /// <summary>
    /// Nessa classe deve ser feito o acesso a banco de dados SQL SERVER
    /// Dados de conexao do banco de dados
    /// host: den1.mssql6.gear.host
    /// base: testecore
    /// user:testecore
    /// senha : Dz2iI~!U1Edq
    /// 
    /// Tabela Destino
    /// 
    /// Colunas:
    /// DestinoId inteiro 
    /// Nome texto nulavel
    /// Dia data nulavel
    /// 
    /// </summary>
    public class teste4
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<Destino> ListarDestino()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=den1.mssql6.gear.host;Database=testecore;User Id=testecore;Password=Dz2iI~!U1Edq";
            conn.Open();
            string sql = "select * from Destino";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Destino> resultado = new List<Destino>();
            while (reader.Read())
            {
                Destino item = new Destino();
                item.DestinoId = (int)reader["DestinoId"];
                item.Nome = reader["Nome"].ToString();
                if (reader["Dia"] != null)
                    item.Dia = Convert.ToDateTime(reader["Dia"]);
                resultado.Add(item);
            }
            return resultado;
        }

        public Destino buscarPorId(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=den1.mssql6.gear.host;Database=testecore;User Id=testecore;Password=Dz2iI~!U1Edq";
            conn.Open();
            string sql = string.Format("select * from Destino where DestinoId={0}", id);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Destino resultado = new Destino();
            if (reader.Read())
            {
                resultado.DestinoId = (int)reader["DestinoId"];
                resultado.Nome = reader["Nome"].ToString();
                if (reader["Dia"] != null)
                    resultado.Dia = Convert.ToDateTime(reader["Dia"]);                
            }
            return resultado;
        }
    }
}
