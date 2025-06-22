using System;

namespace FactoryMethodPatternExample
{
    public interface IDocument
    {
        void Open();
        void Close();
    }

    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word Document");
        public void Close() => Console.WriteLine("Closing Word Document");
    }

    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF Document");
        public void Close() => Console.WriteLine("Closing PDF Document");
    }

    public class ExcelDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Excel Document");
        public void Close() => Console.WriteLine("Closing Excel Document");
    }

    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new WordDocument();
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new PdfDocument();
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new ExcelDocument();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Document Management System");
            Console.WriteLine("--------------------------");

            DocumentFactory wordFactory = new WordDocumentFactory();
            DocumentFactory pdfFactory = new PdfDocumentFactory();
            DocumentFactory excelFactory = new ExcelDocumentFactory();

            Console.WriteLine("\nCreating Word Document:");
            IDocument wordDoc = wordFactory.CreateDocument();
            wordDoc.Open();
            wordDoc.Close();

            Console.WriteLine("\nCreating PDF Document:");
            IDocument pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.Open();
            pdfDoc.Close();

            Console.WriteLine("\nCreating Excel Document:");
            IDocument excelDoc = excelFactory.CreateDocument();
            excelDoc.Open();
            excelDoc.Close();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
