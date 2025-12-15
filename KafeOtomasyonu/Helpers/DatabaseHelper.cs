using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace KafeOtomasyonu.Helpers
{
    /// <summary>
    /// Veritabanı işlemleri için yardımcı sınıf
    /// </summary>
    public static class DatabaseHelper
    {
        // Connection string - App.config'den okunur
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["KafeOtomasyonuDB"]?.ConnectionString
                        ?? "Server=localhost;Database=KafeOtomasyonuDB;Integrated Security=True;TrustServerCertificate=True;";
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// Yeni bir SQL bağlantısı oluşturur
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Bağlantıyı test eder
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// SELECT sorgusu çalıştırır ve DataTable döndürür
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Sorgu çalıştırılırken hata oluştu: {ex.Message}", ex);
            }

            return dataTable;
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE sorguları çalıştırır
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Sorgu çalıştırılırken hata oluştu: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tek bir değer döndüren sorgu çalıştırır (COUNT, MAX, vb.)
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Sorgu çalıştırılırken hata oluştu: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// INSERT işlemi yapar ve eklenen kaydın ID'sini döndürür
        /// </summary>
        public static int ExecuteInsertAndGetId(string query, SqlParameter[] parameters = null)
        {
            try
            {
                // Sorgunun sonuna SCOPE_IDENTITY() ekle
                string queryWithIdentity = query + "; SELECT SCOPE_IDENTITY();";

                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(queryWithIdentity, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        var result = command.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Kayıt eklenirken hata oluştu: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// SHA256 ile şifre hash'leme
        /// </summary>
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Şifre doğrulama
        /// </summary>
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return string.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// SQL parametresi oluşturur (null değer kontrolü ile)
        /// </summary>
        public static SqlParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Birden fazla SQL parametresi oluşturur
        /// </summary>
        public static SqlParameter[] CreateParameters(params (string name, object value)[] parameters)
        {
            SqlParameter[] sqlParams = new SqlParameter[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                sqlParams[i] = CreateParameter(parameters[i].name, parameters[i].value);
            }
            return sqlParams;
        }
    }
}

