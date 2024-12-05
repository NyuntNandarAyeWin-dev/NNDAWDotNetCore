using System.Data;
using System.Data.SqlClient;

namespace NNDAWDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable Query(string query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (sqlParameters is not null)
            {
                foreach (var sqlParam in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(sqlParam.Name, sqlParam.Value);
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        public int Execute(string query, params SqlParameterModel[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            if (sqlParameters is not null)
            {
                foreach (var sqlParam in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(sqlParam.Name, sqlParam.Value);
                }
            }
            var result = cmd.ExecuteNonQuery();

            connection.Close();

            return result;
        }
    }

    public class SqlParameterModel
    {
        public string Name { get; set; }
        public Object Value { get; set; }

        public SqlParameterModel() { }

        public SqlParameterModel(string name, Object value)
        {
            Name = name;
            Value = value;
        }
    }
}
