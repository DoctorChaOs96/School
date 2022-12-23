using System.Text;

internal class Program
{
    static object[] _logsStorages = new object[]
    {
        new WindowsFileSystemStorage(),
        new GoogleDriveStorage(),
        new LinuxFileSystemStorage(),
        new DbStorage()
    }; 

    private static void Main(string[] args)
    {
        var log = "Hello world";
        var data = Encoding.UTF8.GetBytes(log);

        foreach(var storage in _logsStorages)
        {
            if(storage is GoogleDriveStorage) 
                ((GoogleDriveStorage)storage).PrintUsedSpace();

            if (storage is DbStorage)
                ((DbStorage)storage).SaveData(log);

            if(storage is IStorage)
                if(storage is FileStorageBase)
                {
                    var s = (FileStorageBase)storage;

                    s.SaveData(data);
                    s.PrintStorageInfo();
                }
                else
                {
                    ((IStorage)storage).SaveData(data);
                }
        }

        Console.ReadKey();
    }
}


interface IStorage
{
    void SaveData(byte[] data);
}

abstract class FileStorageBase : IStorage
{
    public void SaveData(byte[] data)
    {
        Console.WriteLine("Saving file to local file system.");
    }

    public abstract void PrintStorageInfo();
}

class WindowsFileSystemStorage : FileStorageBase
{
    public void PrintDriversNames()
    {
        Console.WriteLine("Driver 1, Driver 2");
    }

    public override void PrintStorageInfo()
    {
        Console.WriteLine("Windows OS, 1 GB free space");
    }
}

class LinuxFileSystemStorage : FileStorageBase
{
    public override void PrintStorageInfo()
    {
        Console.WriteLine("Linux OS, 2 GB free space");
    }
}

class GoogleDriveStorage : IStorage
{
    public void PrintUsedSpace()
    {
        Console.WriteLine("1 GB");
    }

    public void SaveData(byte[] data)
    {
        Console.WriteLine("Saving file to goole drive.");
    }
}

class DbStorage
{
    public void SaveData(string text)
    {
        Console.WriteLine("Saving text");
    }
}