
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

public static class PurchaseRecoveryStore
{
    private static readonly string FolderPath =
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "ROMS-SALES");

    private static readonly string DbPath =
        Path.Combine(FolderPath, "PurchaseRecovery.db");

    private static string ConnectionString =>
        "Data Source=" + DbPath;


    public static void Initialize()
    {
        try
        {
            Directory.CreateDirectory(FolderPath);

            using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS PurchaseRecovery
                    (
                        RecoveryKey TEXT PRIMARY KEY,
                        JsonData TEXT NOT NULL,
                        UpdatedAt TEXT NOT NULL
                    );";

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            string details = ex.ToString();

            MessageBox.Show(
                details,
                "SQLite Initialization Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            throw;
        }
    }


    public static void Save(string key, object snapshot)
    {
        string json = JsonConvert.SerializeObject(snapshot);

        using (var connection =
            new SqliteConnection(ConnectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    INSERT OR REPLACE INTO PurchaseRecovery
                    (RecoveryKey, JsonData, UpdatedAt)
                    VALUES ($key, $json, $updatedAt);";

                command.Parameters.AddWithValue("$key", key);
                command.Parameters.AddWithValue("$json", json);
                command.Parameters.AddWithValue(
                    "$updatedAt", DateTime.Now.ToString("o"));

                command.ExecuteNonQuery();
            }
        }
    }

    public static string Load(string key)
    {
        using (var connection =
            new SqliteConnection(ConnectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    SELECT JsonData
                    FROM PurchaseRecovery
                    WHERE RecoveryKey = $key;";

                command.Parameters.AddWithValue("$key", key);

                return command.ExecuteScalar() as string;
            }
        }
    }

    public static void Delete(string key)
    {
        using (var connection =
            new SqliteConnection(ConnectionString))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    "DELETE FROM PurchaseRecovery WHERE RecoveryKey = $key;";

                command.Parameters.AddWithValue("$key", key);
                command.ExecuteNonQuery();
            }
        }
    }
}
