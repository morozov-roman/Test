using System;
using Spire.Doc;

namespace Test
{
    public class DocxToText
    {
        public void Create(string path)
        {
            //Create word document
            Document document = new Document();
            document.LoadFromFile(path);

            //Save doc file.
            document.SaveToFile(@"test01.txt", FileFormat.Txt);

            //Launching the MS Word file.
            WordDocViewer(@"test01.txt");
        }

        private void WordDocViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}