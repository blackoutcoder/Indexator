using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class IndexedFile
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string FullPath { get; set; }
        public Guid FolderId { get; set; }

       /* public IndexedFile(Guid id, string name, long size, string fullPath, Guid folderId)
        {
            Id = id;
            Name = name;
            Size = size;
            FullPath = fullPath;
            FolderId = folderId;
        }*/
    }
}
