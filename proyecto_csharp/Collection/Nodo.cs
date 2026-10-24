namespace ProyectoCsharp.Collection
{
    public class Nodo
    {
        private object dato;
        private Nodo siguiente;
        private Nodo anterior;

        public Nodo() { }

        public Nodo(object dato)
        {
            this.dato = dato;
        }

        public void SetDato(object dato)
        {
            this.dato = dato;
        }

        public void SetSiguiente(Nodo siguiente)
        {
            this.siguiente = siguiente;
        }

        public void SetAnterior(Nodo anterior)
        {
            this.anterior = anterior;
        }

        public object GetDato()
        {
            return dato;
        }

        public Nodo GetSiguiente()
        {
            return siguiente;
        }

        public Nodo GetAnterior()
        {
            return anterior;
        }
    }
}
