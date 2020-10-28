using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DocxToText f = new DocxToText();
            f.Create(@"/Users/romanmorozov/RiderProjects/Test/Test/test01.docx");
            Parser p = new Parser();
            p.Start(@"test01.txt");
            File.Delete("test01.txt");
        }
    }
}