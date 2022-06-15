using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Models
{
    
    public class IndexedFolder
    {
        [Key]
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        /*public IndexedFolder(Guid folderId, string name)
        {
            FolderId = folderId;
            Name = name;
        }*/
    }
}
