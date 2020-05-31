using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mso_Backup
{
    class FileManagement
    {

        String Kaynak_Yol = "D:\\Video";
        String Hedef_Yol = "E:\\Video";


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

        public void KlasorListeleme()
        {
            string[] klasorler = Directory.GetDirectories(Kaynak_Yol);

            if (klasorler.Length == 0)
            {
                Console.WriteLine("Belirtilen dizinde herhangi bir klasör mevcut değildir.");
            }
            else
            {
                foreach (string klasor in klasorler)
                {
                    Console.WriteLine(klasor);
                }
            }
        }

        public void DosyaListeleme(string path)
        {
            string[] dosyalar = Directory.GetFiles(path);

            if (dosyalar.Length == 0)
            {
                Console.WriteLine($"{path} : Belirtilen dizinde herhangi bir dosya mevcut değildir.");
            }
            else
            {
                foreach (string dosya in dosyalar)
                {
                    Console.WriteLine(dosya);
                }
            }

        }

        public string[] ListofDirectory(string path)
        {
            string[] directories = Directory.GetDirectories(Kaynak_Yol);
            return directories;
        }

        public void TumDosyalariListele()
        {
            string[] klasorler = ListofDirectory(Kaynak_Yol);
            if (klasorler.Length != 0)
            {
                foreach (var klasor in klasorler)
                {
                    DosyaListeleme(klasor);
                }

                DosyaListeleme(Kaynak_Yol);
            }
            else
            {
                DosyaListeleme(Kaynak_Yol);
            }
        }

        public void GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Kaynak_Yol);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*", SearchOption.AllDirectories);

            foreach (var fileInfo in fileInfos)
            {
                GetFileInformation(fileInfo);
                Console.ReadLine();
            }
        }

        public void KlasorBilgileri()
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

        public void GetFileInformation(FileInfo fileInfo)
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
                            }
                            catch { }
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

        public void FileCopyTest()
        {
            FileCopy(Kaynak_Yol + "\\360 (2).mp4", Hedef_Yol + "\\360 (2).mp4");
        }
    }
}
