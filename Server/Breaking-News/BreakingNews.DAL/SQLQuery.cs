using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BreakingNews.DAL
{
	public class SQLQuery
	{

		//public static string connectionString = //GetConnectionString();
		public static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BreakingNews;Data Source=localhost\\SQLEXPRESS";
		public delegate void SetDataReader_dg(SqlDataReader reader);
		public delegate object SetResultDataReader_dg(SqlDataReader reader);

		// explanation - this function is a generic function that can be used for any query that do not return a result
		public static void runCommand(string sqlQ, SetDataReader_dg setDataReader)
		{

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{

					connection.Open();

					using (SqlCommand command = new SqlCommand(sqlQ, connection))
					{

						using (SqlDataReader reader = command.ExecuteReader())
						{

							setDataReader(reader);

						}
					}

				}
				catch (SqlException e)
				{
					throw e;
				}
			}
		}

		//  explanation - this function is for select query that return one result
		public static object RunCommandResult(string sqlQ, SetResultDataReader_dg setQueryResult)
		{
			object ret = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string queryString = sqlQ;
				// Adapter
				using (SqlCommand command = new SqlCommand(queryString, connection))
				{
					try
					{
						connection.Open();

						//Reader
						using (SqlDataReader reader = command.ExecuteReader())
						{
							ret = setQueryResult(reader);
						}
					}
					catch (SqlException e)
					{
						throw e;
					}
				}
			}
			return ret;
		}


		// explanation - this function is for select query that return one scalar result
		public static object RunCommandScalar(string sqlQ)
		{
			object ret = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				using (SqlCommand command = new SqlCommand(sqlQ, connection))
				{
					try
					{
						connection.Open();
						ret = command.ExecuteScalar();
					}
					catch (SqlException e)
					{
						throw e;
					}

				}
			}
			return ret;
		}


		public static void RunNonQuery(string sqlQ)
		{

			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				string queryString = sqlQ;

				// Adapter
				using (SqlCommand command = new SqlCommand(queryString, connection))
				{
					try
					{
						connection.Open();
						command.ExecuteNonQuery(); // Optional - get the result into var called affectedRows for Debugging or validation purposes.
					}
					catch (SqlException e)
					{
						throw e;

					}
				}
			}
		}


		//public static string GetConnectionString()
		//{
		//	var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
		//	return config.GetConnectionString("DefaultConnection");
		//}



	}
}
