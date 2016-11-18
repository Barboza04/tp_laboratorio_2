using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;
        private DownloadProgressChangedEventHandler onProgressChanged;
        private DownloadStringCompletedEventHandler onDownloadComplete;

        public Descargador(Uri direccion, DownloadProgressChangedEventHandler onProgressChanged, DownloadStringCompletedEventHandler onDownloadComplete)
        {
            this.html = direccion.AbsolutePath;
            this.direccion = direccion;
            this.onProgressChanged = onProgressChanged;
            this.onDownloadComplete = onDownloadComplete;
            
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.onProgressChanged;
                cliente.DownloadStringCompleted += this.onDownloadComplete;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
        }
    }
}
