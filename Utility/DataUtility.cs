using Microsoft.Data.SqlClient;

namespace AdoDotNet.Utility;

public class DataUtility
{
    private readonly string _connectionString;

    public DataUtility(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ExecuteCommand(string sqlCommand , IList<(string key, object value)>parameters)
    {
     using SqlConnection connection = new SqlConnection(_connectionString);
     using SqlCommand command = connection.CreateCommand();
     command.CommandText = sqlCommand;
     if (parameters != null)
     {
         foreach (var param in parameters)
         {
             command.Parameters.Add(new SqlParameter(param.key, param.value));
         }
     }
     connection.Open();
     command.ExecuteNonQuery(); 
    }
    
    
}