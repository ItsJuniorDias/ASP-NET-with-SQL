using System;
using System.Configuration;
using System.Data.SqlClient;
using BDProjeto.Aplicacao;
using BDProjeto.Dominio;

namespace ConexaoBD
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var app = new UsuarioAplicacao();


            SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
            conexao.Open();

            Console.WriteLine("Digite o nome do usuario:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o cargo:");
            string cargo = Console.ReadLine(); 

            Console.WriteLine("Digite a data de cadastro:");
            string data = Console.ReadLine();


            var usuarios = new Usuarios
            {
               nome = nome,
               cargo = cargo,
               data = DateTime.Parse(data)

            };

           // usuarios.id = 5;

             app.Salvar(usuarios);



            //   string strQueryUpdate = "Update usuarios SET nome = 'Alexandre' WHERE id = 1";
            //   SqlCommand cmdComandoUpdate = new SqlCommand(strQueryUpdate, conexao);
            //   cmdComandoUpdate.ExecuteNonQuery();

            //   string strQueryDelete = "Delete FROM usuarios WHERE id= 1";
            //    SqlCommand cmdComandoDelete = new SqlCommand(strQueryDelete, conexao);
            //    cmdComandoDelete.ExecuteNonQuery();

            //string strQueryInsert = string.Format("Insert INTO usuarios (nome,cargo,data) Values('{0}', '{1}', '{2}')", nome, cargo, data);
            //   bd.ExecutaComando(strQueryInsert);

            var dados = app.ListarTodos();

            foreach (var usuario in dados)
            {
                Console.WriteLine("id:{0}, nome: {1}, cargo :{2}, data:{3}", usuario.id, usuario.nome, usuario.cargo, usuario.data);
            }
        }
    }
}
