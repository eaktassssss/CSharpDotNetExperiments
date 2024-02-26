using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterfaces
{
    public class FileWriter: IDisposable
    {
        private StreamWriter _streamWriter;
        private bool _disposed = false;
        private bool disposedValue;

        public FileWriter(string filePath)
        {
            _streamWriter = new StreamWriter(filePath, true); 
        }

        public void WriteToFile(string text)
        {
            if (_disposed)
                throw new ObjectDisposedException("FileWriter", "Nesne zaten dispose edilmiş.");

            _streamWriter.WriteLine(text);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_streamWriter != null)
                    {
                        _streamWriter.Close();
                        _streamWriter = null;
                    }
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~FileWriter()
        {
            Dispose(false);
        }
    }
}
