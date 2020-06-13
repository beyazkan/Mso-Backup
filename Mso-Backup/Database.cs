using IWshRuntimeLibrary;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup
{
    public class Database
    {
        FileManagement _file = new FileManagement();
        Logger logger = LogManager.GetCurrentClassLogger();
        static string _exePath = Application.StartupPath;
        static string _Name = "\\msobackup.db";
        public string _filePath;
        public string _connectionString;
        SQLiteConnection _connection;

        static string _FirstUsers = "INSERT INTO Users(username, password, firstname, lastname, email, createdatetime) VALUES('ykpikacu', '654333', 'Mustafa', 'OĞUZ', 'iyimser.tuzlali@hotmail.com', '02.05.2020 21:24:22');";
        static string _FirstUsers2 = "INSERT INTO Users(username, password, firstname, lastname, email, createdatetime) VALUES('goldpaw', '654333', 'Mustafa', 'OĞUZ', 'm.sabri.oguz@gmail.com', '02.05.2020 21:24:22');";
        static string _SelectAll = "SELECT * FROM Users;";
        static string _UpdateUsers = "UPDATE Users SET firstname = 'Mehmet' WHERE id = 2";
        static string _DeleteUsers = "DELETE FROM Users WHERE id = 2";

        public Database()
        {
            _filePath = _exePath + _Name;
            _connectionString = $"Data Source={_filePath};Version=3";

            DbFileCheck();
            //CreateTable(_CreateUsersTable);
            //CreateTable(_CreateFilesTable);
            //CreateTable(_CreateDrivesTable);
            //Add(_FirstUsers);
            //Add(_FirstUsers2);
            //ListOfDB();
            //Update();
            //ListOfDB();
            //Delete();
            //ListOfDB();

        }

        public Database(string path)
        {
            _filePath = path + _Name;
            _connectionString = $"Data Source={_filePath};Version=3";
            DbFileCheck();
        }

        private void Delete()
        {
            try
            {
                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(_DeleteUsers, _connection);
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("HATA : " + e.Message);
            }
        }

        private void Update()
        {
            try
            {
                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(_UpdateUsers, _connection);
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("HATA : " + e.Message);
            }
        }

        private void ListOfDB()
        {
            try
            {
                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(_SelectAll, _connection);
                SQLiteDataReader dr = cmd.ExecuteReader();
                //SQLiteDataAdapter da = new SQLiteDataAdapter(_SelectAll, _connection);
                //DataSet ds = new DataSet();
                //da.Fill(ds, "Users");
                while (dr.Read())
                {
                    Console.WriteLine($"Id: {dr.GetInt32(0)}, Kullanıcı Adı: {dr.GetString(1)}, Şifre: {dr.GetString(2)}, " +
                        $"Adı: {dr.GetString(3)}, Soyadı: {dr.GetString(4)}, Email Adresi : {dr.GetString(5)}, Oluşturulma Tarihi: {dr.GetString(8)}");
                }
                _connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("HATA : " + e.Message);
            }
        }

        private void Add(String SqlCmd)
        {
            try
            {
                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(SqlCmd, _connection);
                cmd.ExecuteNonQuery();
                _connection.Close();
                Console.WriteLine("Varsayılan kullanıcı eklenmiştir.");
            }
            catch (Exception e)
            {
                Console.WriteLine("HATA:" + e.Message);
            }
        }

        public void Connect()
        {
            try
            {
                _connection = new SQLiteConnection(_connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Veritabanı Hatası : " + e.Message);
                throw;
            }
        }

        private void CreateTable(string sqlCommand)
        {
            try
            {
                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sqlCommand, _connection);
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata : " + e.Message);
            }
        }

        private void DbFileCheck()
        {
            if (!_file.FileExist(_filePath))
            {
                CreateDatabase();
                Connect();
                InstallTables();

                Console.WriteLine("Veritabanı Oluşturuldu.");
            }
            else
            {
                Console.WriteLine("Varolan veritabanı kullanılıyor.");
                Connect();
            }
        }

        private void CreateDatabase()
        {
            try
            {
                SQLiteConnection.CreateFile(_filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private void InstallTables()
        {
            try
            {
                string sqlpath = Application.StartupPath + "\\SQL\\";
                List<string> tables = new List<string>();
                tables.Add("Drivers-Table.sql");
                tables.Add("Files-Table.sql");
                tables.Add("Settings-Table.sql");

                foreach (var table in tables)
                {
                    string createDriversTable = sqlpath + table;
                    string createDriversTableSQL = System.IO.File.ReadAllText(createDriversTable);

                    CreateTable(createDriversTableSQL);
                    logger.Info("{0} isimli tablo oluşturuldu.", table);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            
        }
    }
}
