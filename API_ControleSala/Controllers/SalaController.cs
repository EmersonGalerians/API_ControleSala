using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_ControleSala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        [HttpGet]
        public string Cont_Sala(string o_Sala)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoProjetoER; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetSala = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from Sala where ID like '%{o_Sala}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(DataSetSala);

            string json = JsonConvert.SerializeObject(DataSetSala, Formatting.Indented);

            return json;
        }
        [HttpPost]
        public string Cont_Sala2(string o_Sala)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoProjetoER; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetSala = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from Sala where ID like '%{o_Sala}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(DataSetSala);

            string json = JsonConvert.SerializeObject(DataSetSala, Formatting.Indented);

            return json;
        }
    }
}
