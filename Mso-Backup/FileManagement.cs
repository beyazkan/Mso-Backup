using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using Mso_Backup.Forms.Setup;
using System.Threading;

namespace Mso_Backup
{
    class FileManagement
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        public bool FileExist(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FolderExist(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasSubFolder(string sourcepath)
        {
            if (GetDirectoryInfos(sourcepath).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasFiles(string sourcepath)
        {
            if (ListofFiles(sourcepath).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string[] ListofDirectory(string sourcePath)
        {
            string[] directories = Directory.GetDirectories(sourcePath);
            return directories;
        }
        public List<FileInfo> ListofFiles(string sourcePath, bool bSearchOption = false)
        {

            List<string> filepath = new List<string>();
            List<FileInfo> files = new List<FileInfo>();
            DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
            if (bSearchOption)
            {
                FileInfo[] fileInfos = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
                foreach (var fileInfo in fileInfos)
                {
                    files.Add(fileInfo);
                }
            }
            else
            {
                FileInfo[] fileInfos = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
                foreach (var fileInfo in fileInfos)
                {
                    files.Add(fileInfo);
                }
            }

            return files;
        }
        public List<FileInfo> GetFiles(string sourcePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
            List<FileInfo> fileInfos = directoryInfo.GetFiles("*", SearchOption.AllDirectories).ToList<FileInfo>();

            return fileInfos;
        }
        public void FolderInformation()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo("D:\\Video\\");
                Console.WriteLine("Klasor Adı:" + directoryInfo.Name);
                Console.WriteLine("Klasor Yolu:" + directoryInfo.FullName);
                Console.WriteLine("Klasor Oluşturma Tarihi: " + directoryInfo.CreationTime);
                Console.WriteLine("Klasor Değiştirilme Tarihi: " + directoryInfo.LastWriteTime);
                Console.WriteLine("Klasor Son Erişme Tarihi: " + directoryInfo.LastAccessTime);
                Console.WriteLine("Klasorün Ebeveyni: " + directoryInfo.Parent);
                Console.WriteLine("Klasorün Kök Dizini: " + directoryInfo.Root);
                Console.WriteLine("Klasorün Hash Kodu: " + directoryInfo.GetHashCode());
                Console.WriteLine("Klasorün Hash Kodu: " + directoryInfo.GetFiles());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void FileInformation(FileInfo fileInfo)
        {
            Console.WriteLine("Dosya Adı : " + fileInfo.Name);
            Console.WriteLine("Dosya Yolu : " + fileInfo.FullName);
            Console.WriteLine("Dosya Uzantısı : " + fileInfo.Extension);
            Console.WriteLine("Dosya Boyutu : {0} MB", fileInfo.Length * 1024 / 1024 / 1024 / 1024);
            Console.WriteLine("Dosya Klasörü : " + fileInfo.DirectoryName);
            Console.WriteLine("Dosya Özellikleri : " + fileInfo.Attributes);
            Console.WriteLine("Dosya Oluşturulma Tarihi : " + fileInfo.CreationTime);
            Console.WriteLine("Dosya Değiştirilme Tarihi : " + fileInfo.LastWriteTime);
            Console.WriteLine("Dosya Son Erişme Tarihi : " + fileInfo.LastAccessTime);
            Console.WriteLine("Dosyanın Ebeveyni : " + fileInfo.Directory);
            Console.WriteLine("Dosyanın Hash Kodu : " + fileInfo.GetHashCode());
        }
        public void AllCopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                List<FileInfo> files = GetFiles(sourcePath);
                foreach (var file in files)
                {
                    FileCopy(file.FullName, destinationPath + "\\" + file.Name);
                    logger.Info("{0} adlı dosya başarılı bir şekilde kopyalandı.", file.Name);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            
        }
        public void FileCopy(string kaynak, string hedef)
        {
            byte[] buffer = new byte[1048576];

            //Open source file for reading.
            using (FileStream fi = new FileStream(kaynak, FileMode.Open, FileAccess.Read))
            {
                //Get length of source file.
                long FileLen = fi.Length;
                //Open output file for writing
                using (FileStream fo = new FileStream(hedef, FileMode.Create, FileAccess.Write))
                {

                    int block_size = 0;
                    long total_bytes = 0;

                    //While we still have data read the file.
                    while ((block_size = fi.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //Append block size to total bytes
                        total_bytes += block_size;
                        //Work out what present age the file is been copied.
                        double present = (double)total_bytes * 100 / FileLen;
                        //progress bar fails if value is zero. 
                        if (present > 0)
                        {
                            try
                            {
                                //Set progress bar value to percentage of file been copied.
                                //pBar1.Value = (int)present;
                                Console.WriteLine("Kopyalama Durumu : {0}", (int)present);
                                logger.Info("Kopyalama Durumu : {0}", (int)present);
                            }
                            catch (Exception e){
                                logger.Error(e.Message);
                            }
                        }
                        //Write data to the output file.
                        fo.Write(buffer, 0, block_size);
                    }
                    //Close output file.
                    fo.Close();
                }
                //Close source file.
                fi.Close();
            }
        }
        public void FileCopy(string kaynak, string hedef, int total, LoadingUC _parent)
        {
            byte[] buffer = new byte[1048576];

            //Open source file for reading.
            using (FileStream fi = new FileStream(kaynak, FileMode.Open, FileAccess.Read))
            {
                //Get length of source file.
                long FileLen = fi.Length;
                //Open output file for writing
                using (FileStream fo = new FileStream(hedef, FileMode.Create, FileAccess.Write))
                {

                    int block_size = 0;
                    long total_bytes = 0;

                    //While we still have data read the file.
                    while ((block_size = fi.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //Append block size to total bytes
                        total_bytes += block_size;
                        //Work out what present age the file is been copied.
                        double present = (double)total_bytes * 100 / FileLen;
                        //progress bar fails if value is zero. 
                        if (present > 0)
                        {
                            try
                            {
                                //Set progress bar value to percentage of file been copied.
                                //pBar1.Value = (int)present;
                                //Console.WriteLine("Kopyalama Durumu : {0}", (int)present);
                                //logger.Info("Kopyalama Durumu : {0}", (int)present);
                                _parent.changePercent((int)present, kaynak);
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                            }
                        }
                        //Write data to the output file.
                        fo.Write(buffer, 0, block_size);
                    }
                    //Close output file.
                    fo.Close();
                }
                //Close source file.
                fi.Close();
            }
        }
        public List<DirectoryInfo> GetDirectoryInfos(string sourcePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
            List<DirectoryInfo> directories = new List<DirectoryInfo>();


            directories = directoryInfo.GetDirectories().ToList<DirectoryInfo>();

            return directories;
        }
        public void ListofDirectories(List<DirectoryInfo> directories)
        {
            foreach (var directory in directories)
            {
                Console.WriteLine("Klasör Yolu: {0}", directory.FullName);
                Console.WriteLine("Klasör Adı: {0}", directory.Name);
                Console.WriteLine("Klasör Ebeveyni: {0}", directory.Parent);
            }
        }
        public void CreateDirectory(string destinationPath)
        {
            Directory.CreateDirectory(destinationPath);
        }
        public List<string> GetSourcePaths(string sourcePath)
        {
            List<string> sourcePaths = new List<string>();
            List<DirectoryInfo> directoryInfos = GetDirectoryInfos(sourcePath);
            foreach (var directory in directoryInfos)
            {
                sourcePaths.Add(sourcePath + "\\" + directory.Name);
            }

            return sourcePaths;
        }
        public List<string> GetDestinationPaths(string sourcePath, string destinationPath)
        {
            List<string> destinationPaths = new List<string>();
            List<DirectoryInfo> directoryInfos = GetDirectoryInfos(sourcePath);

            foreach (var directory in directoryInfos)
            {
                destinationPaths.Add(destinationPath + "\\" + directory.Name);
            }

            return destinationPaths;
        }
        public string GetDestinationPath(string sourcePath, string destinationPath)
        {
            string folderPath;
            DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
            folderPath = destinationPath + "\\" + directoryInfo.Name;

            return folderPath;
        }
        public void AllCopyFileWithFolder(string sourcePath, string destinationPath)
        {
            try
            {
                if (HasFiles(sourcePath))
                {
                    if (!FolderExist(destinationPath))
                        CreateDirectory(destinationPath);
                    else
                        Console.WriteLine("Klasör zaten mevcut: {0}", destinationPath);

                    List<FileInfo> files = ListofFiles(sourcePath);
                    foreach (var file in files)
                    {
                        FileCopy(file.FullName, destinationPath + "\\" + file.Name);
                    }

                    if (HasSubFolder(sourcePath))
                    {
                        List<string> sourcepaths = GetSourcePaths(sourcePath);
                        List<string> destinatinonpaths = GetDestinationPaths(sourcePath, destinationPath);

                        foreach (var destenationFolder in destinatinonpaths)
                        {
                            if (!FolderExist(destenationFolder))
                                CreateDirectory(destenationFolder);
                            else
                                Console.WriteLine("Klasör zaten mevcut: {0}", destenationFolder);
                        }
                        foreach (var source in sourcepaths)
                        {
                            string folderPath = GetDestinationPath(source, destinationPath);
                            List<FileInfo> filex = ListofFiles(source);
                            foreach (var file in filex)
                            {
                                FileCopy(file.FullName, folderPath + "\\" + file.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

        }
        public void AllCopyForProgressBar(string sourcePath, string destinationPath, LoadingUC _parent)
        {
            try
            {
                if (HasFiles(sourcePath))
                {
                    int totalFile = ListofFiles(sourcePath, true).Count;

                    if (!FolderExist(destinationPath))
                        CreateDirectory(destinationPath);
                    else
                        Console.WriteLine("Klasör zaten mevcut: {0}", destinationPath);

                    List<FileInfo> files = ListofFiles(sourcePath);
                    foreach (var file in files)
                    {
                        FileCopy(file.FullName, destinationPath + "\\" + file.Name, totalFile, _parent);
                    }

                    if (HasSubFolder(sourcePath))
                    {
                        List<string> sourcepaths = GetSourcePaths(sourcePath);
                        List<string> destinatinonpaths = GetDestinationPaths(sourcePath, destinationPath);

                        foreach (var destenationFolder in destinatinonpaths)
                        {
                            if (!FolderExist(destenationFolder))
                                CreateDirectory(destenationFolder);
                            else
                                Console.WriteLine("Klasör zaten mevcut: {0}", destenationFolder);
                        }
                        foreach (var source in sourcepaths)
                        {
                            string folderPath = GetDestinationPath(source, destinationPath);
                            List<FileInfo> filex = ListofFiles(source);
                            foreach (var file in filex)
                            {
                                FileCopy(file.FullName, folderPath + "\\" + file.Name, totalFile, _parent);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

        }
        public void DeleteFilesAndFolder(string folderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);

            foreach (FileInfo file in directory.GetFiles())
            {
                try
                {
                    file.Delete();
                    logger.Info("{0} adlı dosya başarılı bir şekilde silindi.", file.Name);
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }
            }

            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
            {
                try
                {
                    directoryInfo.Delete(true);
                    logger.Info("{0} adlı klasör başarılı bir şekilde silindi.", directoryInfo.Name);
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }
            }
        }
        public string GetFileAllText(string path)
        {
            string text = null;
            try
            {
                text = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return text;
        }
    }
}
