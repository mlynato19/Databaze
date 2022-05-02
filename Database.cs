using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Databaze
{
    public class Database
    {
        //pripojeni k db
        private SQLiteAsyncConnection Connection;

        public Database(string Path)
        {
            Connection = new SQLiteAsyncConnection(Path);
            Connection.CreateTableAsync<Avenger>().Wait();

        }

        public Task<int> SaveAvengerAsync(Avenger avenger)
        {
            if (avenger.ID != 0)
            {
                return Connection.UpdateAsync(avenger);
            }
            else
            {
                return Connection.InsertAsync(avenger);
            }
        }
        public Task<List<Avenger>> DeleteAvengers()
        {
            return Connection.QueryAsync<Avenger>("DELETE * FROM [Avenger]");
        }
        public Task<List<Avenger>> GetAllAvengers()
        {
            return Connection.QueryAsync<Avenger>("SELECT * FROM [Avenger] WHERE 1");
        }


    }
}