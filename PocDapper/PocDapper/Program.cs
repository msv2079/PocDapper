using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PocDapper
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var connectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Environment.CurrentDirectory}\Data\PocDapper.mdf;Integrated Security=True";

			IEnumerable<Pessoa> listaPessoas;
			Pessoa pessoa;

			using (var conexao = new SqlConnection(connectionString))
			{
				conexao.Open();

				var retornoPessoas = await conexao.QueryAsync<Pessoa>("SELECT * FROM PESSOA");
				pessoa = await conexao.QueryFirstAsync<Pessoa>("SELECT * FROM PESSOA WHERE ID = 1");

				conexao.Close();

				listaPessoas = retornoPessoas.ToList();
			}

			foreach (var item in listaPessoas)
			{
				Console.WriteLine(item.Id);
				Console.WriteLine(item.Nome);
				Console.WriteLine(item.Endereco);
				Console.WriteLine(item.Documento);
			}

			Console.WriteLine(new string('*', 100));

			Console.WriteLine(pessoa.Id);
			Console.WriteLine(pessoa.Nome);
			Console.WriteLine(pessoa.Endereco);
			Console.WriteLine(pessoa.Documento);

			Console.ReadKey();
		}
	}
}
