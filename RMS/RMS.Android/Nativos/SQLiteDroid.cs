using Xamarin.Forms;
using RMS.Data.Interfaces;
using RMS.Droid.Nativos;
using SQLite;
using System.Threading.Tasks;
using System;
using System.IO;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace RMS.Droid.Nativos
{
    public class SQLiteDroid : ISQLite
    {
        private SQLiteAsyncConnection _conn;

        static readonly string _databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "AgillisPhone.db3");


        private static string GetDatabasePath()
        {
            return _databasePath;
        }

        public SQLiteConnection GetConnection()
        {
            var dbPath = GetDatabasePath();

            return new SQLiteConnection(dbPath);
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            var dbPath = GetDatabasePath();

            if (_conn == null)
            {
                _conn = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.FullMutex, true);
                Task.Run(async () => await _conn.EnableWriteAheadLoggingAsync());
            }

            return _conn;
        }

        public void CloseConnection()
        {
            if (_conn != null)
            {
                _conn = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public void DeleteDatabase()
        {
            var path = GetDatabasePath();

            try
            {
                if (_conn != null)
                    _conn = null;
            }
            catch (Exception ex)
            {
            }

            if (File.Exists(path))
                File.Delete(path);

            _conn = null;
        }

    }
}