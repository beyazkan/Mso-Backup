using IWshRuntimeLibrary;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mso_Backup.Entity;
using NLog.Fluent;
using System.Data;

namespace Mso_Backup
{
    public class Database
    {
        FileManagement _file = new FileManagement();
        Logger logger = LogManager.GetCurrentClassLogger();
        EfInstall _install;
        static string _exePath = Application.StartupPath;
        static string _Name = "\\msobackup.db";
        public string _filePath;
        public string _connectionString;
        SQLiteConnection _connection;
        static string _SelectAll = "SELECT * FROM Users;";
        static string _DeleteUsers = "DELETE FROM Users WHERE id = 2";

        public Database()
        {
            _filePath = _exePath + _Name;
            _connectionString = $"Data Source={_filePath};Version=3";

            DbFileCheck();
            //Add(_FirstUsers);
            //Add(_FirstUsers2);
            //ListOfDB();
            //Update();
            //ListOfDB();
            //Delete();
            //ListOfDB();
        }
        public Database(string path, EfInstall install)
        {
            _install = install;
            _filePath = path + _Name;
            _connectionString = $"Data Source={_filePath};Version=3";
            DbFileCheck();
            CreateUser(_install.User);
            logger.Info("{0} adlı kullanıcı, varsayılan kullanıcı olarak eklenmiştir.", install.User.Username);
            InsertSettings();
            logger.Info("Ayarlar veritabanına girildi.");
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
        private void Update(string sqlQuery)
        {
            try
            {
                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, _connection);
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
                tables.Add("Users-Table.sql");

                foreach (var table in tables)
                {
                    string filepath = sqlpath + table;
                    string sqlContent = _file.GetFileAllText(filepath);

                    CreateTable(sqlContent);
                    logger.Info("{0} isimli tablo oluşturuldu.", table);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            
        }
        private void CreateUser(EfUser user)
        {
            try
            {
                string sql = "INSERT INTO Users(username, password, firstname, lastname, email, createdatetime) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');";
                string sqlCommand = string.Format(sql, user.Username, user.Password, user.FirstName, user.LastName, user.Email, DateTime.Now.ToString());

                Add(sqlCommand);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }
        private void InsertSettings()
        {
            try
            {
                string sql = "INSERT INTO Settings(Agreement, " +
                "StartOnStartup, DestinationPath, " +
                "Smtp_Server, Smtp_Port, Support_SSL, " +
                "Smtp_Username, Smtp_Password, " +
                "Log_Database, Log_File, Log_Email, " +
                "Log_EmailOptionError, Log_EmailOptionSuccess, " +
                "Log_EmailOptionInfo, Log_EmailOptionWarn, " +
                "InstallLocation, InstallDateTime, InstallState) " +
                "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'," +
                "'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}');";
                string sqlCommand = string.Format(sql, _install.AgreementToDB, _install.StartOnStartupToDB, _install.DestinationPath,
                    _install.smtp.Server, _install.smtp.Port, _install.smtp.SSLSupportToDB, _install.smtp.Username, _install.smtp.Password,
                    _install.Log_DatabaseToDB, _install.Log_FileToDB, _install.Log_EmailToDB, _install.Log_EmailOptionErrorToDB, _install.Log_EmailOptionSuccessToDB,
                    _install.Log_EmailOptionInfoToDB, _install.Log_EmailOptionWarnToDB, _install.InstallLocation, DateTime.Now.ToString(), 1);

                Add(sqlCommand);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }
        public void updateLastLogin(string username)
        {
            string TarihZaman = DateTime.Now.ToString();
            string sqlQuery = $"UPDATE Users SET lastlogin = '{TarihZaman}' WHERE username = '{ username }'";
            Update(sqlQuery);
        }
        public bool checkUser(string username, string password)
        {
            try
            {
                string sqlQuery = "SELECT * FROM Users WHERE username=@username AND password=@password;";
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, _connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                DataTable dt = new DataTable();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    updateLastLogin(username);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                logger.Error(e.Message);
                return false;
            }
        }
        public void login_attemp(string username)
        {
            try
            {
                int attempt;
                DateTime dateTime;
                string sqlQuery = "SELECT attempt, attemptdatetime FROM Users WHERE username=@username;";

                _connection.Open();
                SQLiteCommand cmd = new SQLiteCommand(sqlQuery, _connection);
                cmd.Parameters.AddWithValue("@username", username);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows) {
                        reader.Read();
                        attempt = Int32.Parse(reader["attempt"].ToString());
                        dateTime = Convert.ToDateTime(reader["attemptdatetime"]);
                        MessageBox.Show(username + "adlı kullanının " + attempt + "kere deneme yapmıştır." + dateTime.ToString() + "tarihinde");
                    }
                }
                _connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                logger.Error(e.Message);
            }
            

        }
    }
}
