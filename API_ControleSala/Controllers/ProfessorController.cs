﻿using Microsoft.AspNetCore.Http;
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
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        public string Cont_Professor(string o_Professor)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoProjetoER; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetProfessor = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from Professor where ID like '%{o_Professor}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(DataSetProfessor);

            string json = JsonConvert.SerializeObject(DataSetProfessor, Formatting.Indented);

            return json;
        }
        [HttpPost]
        public string Cont_Professor2(string o_Professor)
        {

            string ChaveConexao = "Data Source=10.39.45.44; Initial Catalog=BancoProjetoER; User ID=Turma2022;Password=Turma2022@2022";

            DataSet DataSetAgenda = new DataSet();

            SqlConnection Conexao = new SqlConnection(ChaveConexao);
            Conexao.Open();
            string wQuery = $"select * from Professor where ID like '''%{o_Professor}%'";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(DataSetAgenda);

            string json = JsonConvert.SerializeObject(DataSetAgenda, Formatting.Indented);

            return json;
        }
    }
}