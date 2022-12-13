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
    public class AgendaController : ControllerBase
    {

        [HttpGet]
        public string Cont_Agenda(string o_Agenda)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoDadosTeste1; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetAgenda = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from Agenda where ID like '{o_Agenda}'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(DataSetAgenda);

            string json = JsonConvert.SerializeObject(DataSetAgenda, Formatting.Indented);

            return json;
        }
        [HttpPost]
        public string Alt_Professo(string DataCriacao, 
            string Reserva, 
            bool Disponibilidade, 
            int Professor_ID)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoDadosTeste1; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetAgenda = new DataSet();
            try {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $" UPDATE  Agenda  " +
                                         $" SET  DataCriacao =  '{DataCriacao}'" +
                                         $",Reserva =     '{Reserva}'  " +
                                         $",Disponibilidade =  '{Disponibilidade}' " +
                                         $"WHERE Professor_ID  = {Professor_ID}";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(DataSetAgenda);
            }
           
            catch(Exception ex) {
                string vErro = ex.Message.ToString();
            }

            string json = JsonConvert.SerializeObject(DataSetAgenda, Formatting.Indented);

            return json;
        }
        [HttpPut]
        public string Inser_Professo(string DataCriacao,
            string Reserva,
            bool Disponibilidade,
            int Professor_ID)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoDadosTeste1; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetAgenda = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $" INSERT INTO Agenda                 "+
                                $"           (DataCriacao                   "+
                                $"           ,Reserva                       "+
                                $"           ,Disponibilidade               "+
                                $"           ,Professor_ID)                 "+
                                $"     VALUES                                 "+
                                $"           ( {DataCriacao},"+
                                $"            {Reserva}, "+
                                $"            {Disponibilidade} "+
                                $"           , {Professor_ID},)";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(DataSetAgenda);
            }

            catch (Exception ex)
            {
                string vErro = ex.Message.ToString();
            }

            string json = JsonConvert.SerializeObject(DataSetAgenda, Formatting.Indented);

            return json;

        }
}
