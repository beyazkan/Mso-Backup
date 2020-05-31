using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mso_Backup
{
    class Database
    {
        FileManagement _file = new FileManagement();
        static string _exePath = Application.StartupPath;
        static string _Name = "\\msobackup.db";
        static string _filePath = _exePath + _Name;
        static string _connectionString = $"Data Source={_filePath};Version=3";
        SQLiteConnection _connection;
        static string _CreateUsersTable = "CREATE TABLE 'Users' (" +
                                            "'id'    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                                            "'username'  TEXT NOT NULL UNIQUE, " +
                                            "'password'  TEXT NOT NULL," +
                                            "'firstname' TEXT NOT NULL," +
                                            "'lastname'  TEXT NOT NULL," +
                                            "'email'  TEXT NOT NULL," +
                                            "'attempt'   INTEGER," +
                                            "'attemptdatetime'   TEXT," +
                                            "'createdatetime'    TEXT NOT NULL," +
                                            "'updatedatetime'    TEXT," +
                                            "'lastlogin' TEXT);";

        static string _CreateFilesTable = "CREATE TABLE 'Files' (" +
                                          "'id'	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                          "'name'	TEXT NOT NULL," +
                                          "'extension'	TEXT NOT NULL," +
                                          "'size'	INTEGER NOT NULL," +
                                          "'hashcode'	TEXT NOT NULL," +
                                          "'attributes'	TEXT NOT NULL," +
                                          "'directoryname'	BLOB NOT NULL," +
                                          "'parentfolder'	TEXT," +
                                          "'creationtime'	TEXT NOT NULL," +
                                          "'lastwritetime'	TEXT NOT NULL," +
                                          "'lastaccesstime'	TEXT NOT NULL," +
                                          "'copystate'	INTEGER DEFAULT 0," +
                                          "'copytime'	TEXT," +
                                          "'copycount'	INTEGER," +
                                          "'controlstate'	INTEGER DEFAULT 0," +
                                          "'controltime'	TEXT," +
                                          "'controlcount'	INTEGER," +
                                          "'createtime'	TEXT NOT NULL," +
                                          "'updatetime'	TEXT," +
                                          "'deletetime'	TEXT," +
                                          "'userid'	INTEGER);";

        static string _CreateDrivesTable = "CREATE TABLE 'Drivers' (" +
                                           "'id'	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                                           "'pnpdeviceid'	TEXT NOT NULL," +
                                           "'model'	TEXT NOT NULL," +
                                           "'serialnumber'	TEXT NOT NULL," +
                                           "'driveletter'	TEXT NOT NULL," +
                                           "'size'	INTEGER NOT NULL," +
                                           "'freespace'	INTEGER NOT NULL," +
                                           "'state'	INTEGER," +
                                           "'createdatetime'	TEXT NOT NULL," +
                                           "'updatedatetime'	TEXT," +
                                           "'deletedatetime'	TEXT," +
                                           "'userid'	INTEGER NOT NULL);";

        static string _FirstUsers = "INSERT INTO Users(username, password, firstname, lastname, email, createdatetime) VALUES('ykpikacu', '654333', 'Mustafa', 'OĞUZ', 'iyimser.tuzlali@hotmail.com', '02.05.2020 21:24:22');";
        static string _FirstUsers2 = "INSERT INTO Users(username, password, firstname, lastname, email, createdatetime) VALUES('goldpaw', '654333', 'Mustafa', 'OĞUZ', 'm.sabri.oguz@gmail.com', '02.05.2020 21:24:22');";
        static string _SelectAll = "SELECT * FROM Users;";
        static string _UpdateUsers = "UPDATE Users SET firstname = 'Mehmet' WHERE id = 2";
        static string _DeleteUsers = "DELETE FROM Users WHERE id = 2";

        public Database()
        {
            DbFileCheck();
            CreateTable(_CreateUsersTable);
            CreateTable(_CreateFilesTable);
            CreateTable(_CreateDrivesTable);
            Add(_FirstUsers);
            Add(_FirstUsers2);
            ListOfDB();
            Update();
            ListOfDB();
            Delete();
            ListOfDB();

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

                Console.WriteLine("Veritabanı Oluşturuldu.");
            }
            else
            {
                Console.WriteLine("Varolan veritabanı kullanılıyor.");
                Connect();
            }
        }

        private static void CreateDatabase()
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
    }
}
