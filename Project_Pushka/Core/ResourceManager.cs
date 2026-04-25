using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ResourceManager : IDisposable
    {
        private readonly StreamWriter _writer;
        private bool _disposed = false;

        public ResourceManager(string filePath)
        {
            _writer = new StreamWriter(filePath, append: true);
            _writer.WriteLine($"\n--- Запуск операції: {DateTime.Now} ---");
        }

        public void Log(string message)
        {
            _writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            Console.WriteLine($"[Лог] {message}");
        }

        // Звільнення ресурсів (закриття файлу)
        public void Dispose()
        {
            if (!_disposed)
            {
                _writer.WriteLine($"--- Завершення: {DateTime.Now} ---");
                _writer.Close();
                _writer.Dispose();
                _disposed = true;
                Console.WriteLine("[Система] ResourceManager звільнив ресурси.");
            }
        }
    }
}
