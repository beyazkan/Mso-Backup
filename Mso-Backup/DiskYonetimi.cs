using System;
using System.Collections.Generic;
using System.Management;
using Mso_Backup.Entity;

namespace Mso_Backup
{
    class DiskYonetimi
    {
        Komut _komut = new Komut();
        //String _DeviceID = "\"@USBSTOR\\DISK&VEN_TOSHIBA&PROD_TRANSMEMORY&REV_PMAP\\000AEBFFB4C1EB70E31D0037&0\"";
        private String[] _Durum = { "enable", "disable" };
        String _RestartReq = "-r";
        public List<Disk> disks = new List<Disk>();

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
    }
}
