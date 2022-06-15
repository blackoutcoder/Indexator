using System;
using System.IO;
using System.Linq;
using Models;
using Services;

namespace Indexator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Input the path:");
            //var x = Console.ReadLine();
            //Console.WriteLine(x);
            // C:/Users/Rokas/Desktop/Compliance.AssociatedAccounts

            //var path = "C:/Users/Rokas/Desktop/Compliance.AssociatedAccounts";

            FileDbContext filesDbContext = new FileDbContext();

            // atidaryti direktorija
            // uzrasyti visa info is jos
            // atidaryti kita direktorija
            // vel uzrasyti
            // jei nebera direktoriju breakint

            OpenAllDirectories(@"C:\Users\romka\source\CsharpAdvanceExam\Restaurant ordering system");
        }

        public static void OpenAllDirectories(string path)
        {
            FileDbContext filesDbContext = new FileDbContext();

            var mainList = filesDbContext.IndexedFolders.Select(x => x.Path).ToList();

            if (!mainList.Contains(Path.GetDirectoryName(path)))
            {
                var folder = new IndexedFolder
                {
                    FolderId = Guid.NewGuid(),
                    Name = Path.GetDirectoryName(path),
                    Path = path,
                };

                filesDbContext.IndexedFolders.Add(folder);
                filesDbContext.SaveChanges();
            }

            var directoryPaths = Directory.EnumerateDirectories(path);
            foreach (var directoryPath in directoryPaths)
            {
                Console.WriteLine(directoryPath);
                OpenAllFiles(directoryPath);
                OpenAllDirectories(directoryPath);
            }
        }

        public static void OpenAllFiles(string path)
        {
            FileDbContext filesDbContext = new FileDbContext();

            var filePaths = Directory.EnumerateFiles(path);
            foreach (var filePath in filePaths)
            {
                var mainList = filesDbContext.Files.Select(x => x.Name).ToList();
                if (!mainList.Contains(Path.GetDirectoryName(path)))
                {
                    Guid tempId = Guid.NewGuid();
                    try
                    {
                        tempId = filesDbContext.IndexedFolders.Where(f => f.Name == Path.GetDirectoryName(filePath))
                        .FirstOrDefault().FolderId;
                    }
                    catch (NullReferenceException)
                    {

                        tempId = Guid.NewGuid();
                    }

                    IndexedFile file = new IndexedFile
                    {
                        Id = Guid.NewGuid(),
                        Name = Path.GetFileName(filePath),
                        Size = new FileInfo(filePath).Length,
                        FullPath = filePath,
                        FolderId = tempId,
                    };
                    filesDbContext.Files.Add(file);
                }
            }
            filesDbContext.SaveChanges();
        }

    }
}
