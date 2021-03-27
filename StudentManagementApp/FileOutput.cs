using System.IO;

namespace StudentManagementApp
{
    public class FileOutput : IOutput
    {
        private const string FilePath = "d:\\my\\fileoutput.txt";
        public void WriteLine(string str)
        {
            File.AppendAllText(FilePath, str);
        }
    }

}

