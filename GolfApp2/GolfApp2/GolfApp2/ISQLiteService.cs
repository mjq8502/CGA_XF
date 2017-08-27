using System;
using SQLite;

namespace GolfApp2
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection(string databaseName);
        long GetSize(string databaseName);
    }
}
