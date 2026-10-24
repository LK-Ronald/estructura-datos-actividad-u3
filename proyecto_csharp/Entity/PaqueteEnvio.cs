using System;

namespace ProyectoCsharp.Entity
{
    public class PaqueteEnvio
    {
        private readonly string numeroGuia;
        private string destino;
        private string origen;
        private readonly DateTime fecha;

        public PaqueteEnvio(string destino, string origen)
        {
            this.numeroGuia = Guid.NewGuid().ToString();
            this.destino = destino;
            this.origen = origen;
            this.fecha = DateTime.Today;
        }

        public string GetNumeroGuia()
        {
            return numeroGuia;
        }

        public string GetDestino()
        {
            return destino;
        }

        public string GetOrigen()
        {
            return origen;
        }

        public DateTime GetFecha()
        {
            return fecha;
        }

        public void SetDestino(string destino)
        {
            this.destino = destino;
        }

        public void SetOrigen(string origen)
        {
            this.origen = origen;
        }

        public override string ToString()
        {
            return "PaqueteEnvio{" +
                   "numeroGuia='" + numeroGuia + "'" +
                   ", origen='" + origen + "'" +
                   ", destino='" + destino + "'" +
                   ", fecha=" + fecha.ToString("yyyy-MM-dd") +
                   "}";
        }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            PaqueteEnvio that = (PaqueteEnvio)o;
            return numeroGuia != null
                ? string.Equals(numeroGuia, that.numeroGuia, StringComparison.OrdinalIgnoreCase)
                : that.numeroGuia == null;
        }

        public override int GetHashCode()
        {
            return numeroGuia != null ? numeroGuia.ToLower().GetHashCode() : 0;
        }
    }
}
