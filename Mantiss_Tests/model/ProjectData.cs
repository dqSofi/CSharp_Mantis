using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mantiss_Tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData
    {
        [Column(Name = "id"), PrimaryKey, Identity]
        public string ID { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }
        
        public ProjectData(string name)
        {
            Name = name;
        }
        public static List<ProjectData> GetAllFromDB()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from g in db.Projects select g).ToList();
            }
        }
    }
}
