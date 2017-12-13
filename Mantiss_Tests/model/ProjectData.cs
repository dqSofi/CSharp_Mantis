using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Mantiss_Tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        [Column(Name = "name")]
        public string Name { get; set; }

        public string ID { get; set; }
        public ProjectData() { }

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

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))//это стандартная проверка
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))//вторая стандартная проверка
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode() // для оптимизации, не совпали хэш коды - точно разные объекты,
                                          //совпали - можно и в equals сравнить
        {
            //return 0; без оптимизации, всегда смотреть в equals
            return Name.GetHashCode();
        }

        public int CompareTo(ProjectData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "name=" + Name;
        }
    }
}
