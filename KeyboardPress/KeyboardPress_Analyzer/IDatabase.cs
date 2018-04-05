using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardPress_Analyzer
{
    public interface IDatabase
    {
        void Db_SaveChanges();

        void Db_LoadData();

        void Db_DeleteDataFromDatabase();

        void Db_DeleteDataFromLocalMemory();
    }
}
