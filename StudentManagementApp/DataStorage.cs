using System.Collections.Generic;

namespace StudentManagementApp
{
    public class DataStorage
    {
        public List<Student> Students { get; set; }
        public List<Group> Groups { get; set; }

        private static DataStorage dataStorage;
        public static DataStorage Instance
        {
            get
            {
                if (dataStorage == null)
                    dataStorage = new DataStorage();
                return dataStorage;
            }
        }

        private DataStorage()
        {
            Students = new List<Student>();
            Groups = new List<Group>();
        }

    }
}

