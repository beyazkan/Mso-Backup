using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;
using Mso_Backup.Entity;
using NLog;

namespace Mso_Backup
{
    public class DiskYonetimi
    {
        Komut _komut = new Komut();
        //String _DeviceID = "\"@USBSTOR\\DISK&VEN_TOSHIBA&PROD_TRANSMEMORY&REV_PMAP\\000AEBFFB4C1EB70E31D0037&0\"";
        private String[] _Durum = { "enable", "disable" };
        String _RestartReq = "-r";
        public List<Disk> disks = new List<Disk>();
        Logger logger = LogManager.GetCurrentClassLogger();
        Database database = new Database();

        public DiskYonetimi()
        {
            //saveToDatabase();
            getDisk();
        }

        public void Online(string PnpDeviceId)
        {
            String arguman = _RestartReq + " " +_Durum[0] + " " + PnpDeviceId;
            _komut.Calistir(arguman);
        }

        public void Offline(string PnpDeviceId)
        {
            String arguman = _RestartReq + " " + _Durum[1] + " " + PnpDeviceId;
            _komut.Calistir(arguman);
        }

        public void DepolamaCihazlari()
        {
            ListOfExternalDisk();
            //ListOfDisk();
            //ListOfInternalDisk();
        }

        private void ListOfExternalDisk()
        {
            if (disks.Count != 0)
                disks.Clear();

            foreach (ManagementObject device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
            {
                Disk diskim = new Disk();
                diskim.Model = (string)device.GetPropertyValue("Model");
                diskim.PNPDeviceId = (string)device.GetPropertyValue("PNPDeviceID");
                diskim.SerialNumber = (string)device.GetPropertyValue("SerialNumber");

                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value
                    + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (ManagementObject disk in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                                    + partition["DeviceID"]
                                    + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        diskim.DriveLetter = (string)disk.GetPropertyValue("Name");
                        foreach (ManagementObject diskInformation in new ManagementObjectSearcher(@"SELECT * FROM Win32_LogicalDisk WHERE DeviceID = '" + disk["Name"] + "'").Get())
                        {
                            diskim.Size = Convert.ToInt64(diskInformation.GetPropertyValue("Size"));
                            diskim.FreeSpace = Convert.ToInt64(diskInformation.GetPropertyValue("FreeSpace"));
                        }
                    }
                    disks.Add(diskim);
                }
            }
        }

        private void ListOfDisk()
        {
            if (disks.Count != 0)
                disks.Clear();

            foreach (ManagementObject device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive").Get())
            {
                Disk diskim = new Disk();
                diskim.Model = (string)device.GetPropertyValue("Model");
                diskim.PNPDeviceId = (string)device.GetPropertyValue("PNPDeviceID");
                diskim.SerialNumber = (string)device.GetPropertyValue("SerialNumber");

                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value
                    + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (ManagementObject disk in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                                    + partition["DeviceID"]
                                    + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        diskim.DriveLetter = (string)disk.GetPropertyValue("Name");
                        foreach (ManagementObject diskInformation in new ManagementObjectSearcher(@"SELECT * FROM Win32_LogicalDisk WHERE DeviceID = '" + disk["Name"] + "'").Get())
                        {
                            diskim.Size = Convert.ToInt64(diskInformation.GetPropertyValue("Size"));
                            diskim.FreeSpace = Convert.ToInt64(diskInformation.GetPropertyValue("FreeSpace"));
                        }
                    }
                    disks.Add(diskim);
                }
            }
        }

        private void ListOfInternalDisk()
        {
            if (disks.Count != 0)
                disks.Clear();

            foreach (ManagementObject device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE NOT InterfaceType LIKE 'USB%'").Get())
            {
                Disk diskim = new Disk();
                diskim.Model = (string)device.GetPropertyValue("Model");
                diskim.PNPDeviceId = (string)device.GetPropertyValue("PNPDeviceID");
                diskim.SerialNumber = (string)device.GetPropertyValue("SerialNumber");

                foreach (ManagementObject partition in new ManagementObjectSearcher(
                    "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value
                    + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                {
                    foreach (ManagementObject disk in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
                                    + partition["DeviceID"]
                                    + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                    {
                        diskim.DriveLetter = (string)disk.GetPropertyValue("Name");
                        foreach (ManagementObject diskInformation in new ManagementObjectSearcher(@"SELECT * FROM Win32_LogicalDisk WHERE DeviceID = '" + disk["Name"] + "'").Get())
                        {
                            diskim.Size = Convert.ToInt64(diskInformation.GetPropertyValue("Size"));
                            diskim.FreeSpace = Convert.ToInt64(diskInformation.GetPropertyValue("FreeSpace"));
                        }
                    }
                    disks.Add(diskim);
                }
            }
        }

        private void saveToDatabase()
        {
            try
            {
                // Güncel Usb Durumunu Listele
                ListOfExternalDisk();

                if (database.hasAnyEntry("SELECT * FROM Drivers"))
                {
                    foreach (var disk in disks)
                    {
                        // Varolan diskleri güncelle
                        if(database.hasAnyEntry($"SELECT * FROM Drivers WHERE serialnumber = '{disk.SerialNumber}'")){
                            string sqlQuery = $"UPDATE Drivers SET driveletter = '{disk.DriveLetter}', freespace = '{disk.FreeSpace}', state = '1', updatedatetime = '{DateTime.Now}' WHERE serialnumber = '{disk.SerialNumber}'";
                            database.Update(sqlQuery);
                            logger.Info($"{disk.Model}-{disk.SerialNumber} disk bilgisi güncellendi.");
                        }
                        // Yeni diskleri ekle
                        else
                        {
                            string sqlQuery = $"INSERT INTO Drivers (pnpdeviceid, model, serialnumber, driveletter, size, freespace, state, createdatetime, userid) VALUES ('{disk.PNPDeviceId}','{disk.Model}','{disk.SerialNumber}','{disk.DriveLetter}','{disk.Size}','{disk.FreeSpace}', '1', '{DateTime.Now}', '1')";
                            database.Add(sqlQuery);
                            logger.Info($"{disk.Model}-{disk.SerialNumber} disk bilgisi veritabanına eklendi.");
                        }
                    }
                }
                else
                {
                    // Yeni diskleri Ekle
                    foreach (var disk in disks)
                    {
                        string sqlQuery = $"INSERT INTO Drivers (pnpdeviceid, model, serialnumber, driveletter, size, freespace, state, createdatetime, userid) VALUES ('{disk.PNPDeviceId}','{disk.Model}','{disk.SerialNumber}','{disk.DriveLetter}','{disk.Size}','{disk.FreeSpace}', '1', '{DateTime.Now}', '1')";
                        database.Add(sqlQuery);
                        logger.Info($"{disk.Model}-{disk.SerialNumber} disk bilgisi veritabanına eklendi.");
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                MessageBox.Show(e.Message);
            }
            
        }

        public void getDisk()
        {
            disks = database.GetDisks();
        }
    }
}
