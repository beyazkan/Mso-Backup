using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mso_Backup.Entity
{
    class CFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        public string Hashcode { get; set; }
        public string Attributes { get; set; }
        public string DirectoryName { get; set; }
        public string OnlyDirectoryName { get { return DirectoryName.Split('\\').ToList<string>().Last(); } set { } }
        public string ParentFolder { get; set; }
        public string CreationTime { get; set; }
        public string LastWriteTime { get; set; }
        public string LastAccessTime { get; set; }
        public int CopyState { get; set; }
        public string CopyTime { get; set; }
        public int CopyCount { get; set; }
        public int ControlState { get; set; }
        public string ControlTime { get; set; }
        public int ControlCount { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string DeleteTime { get; set; }
        public int UserId { get; set; }
    }
}
