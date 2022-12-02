using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Data.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetConnectionAsync();
        void DeleteDatabase();
        void CloseConnection();
    }
}
