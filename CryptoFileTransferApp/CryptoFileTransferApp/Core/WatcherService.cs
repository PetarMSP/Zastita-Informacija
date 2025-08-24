using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFileTransferApp.Core
{
    public class WatcherService
    {
        private readonly FileSystemWatcher _watcher;

        public event Action<string> FileCreated;

        public WatcherService(string path)
        {
            _watcher = new FileSystemWatcher(path, "*.*")
            {
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };


            _watcher.Created += (s, e) =>
            {

                try
                {
                    FileCreated?.Invoke(e.FullPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Greška u WatcherService: {ex.Message}");
                }
            };
        }

        public void Start() => _watcher.EnableRaisingEvents = true;
        public void Stop() => _watcher.EnableRaisingEvents = false;
    }
}

