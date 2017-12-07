using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace Mantiss_Tests
{
    public class MantisDB : LinqToDB.Data.DataConnection
    {
        public MantisDB() : base("root") { }

        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }
    }
}
