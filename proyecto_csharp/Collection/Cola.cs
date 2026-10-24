namespace ProyectoCsharp.Collection
{
    public class Cola
    {
        private int cuenta;
        private Nodo cabeza;
        private Nodo cola;

        public Cola()
        {
            cuenta = 0;
            cabeza = null;
            cola = null;
        }

        public bool IsVacia()
        {
            return (cuenta == 0);
        }

        public void Encolar(object dato)
        {
            if (dato == null)
                throw new Exception("El dato no puede ser nulo");

            Nodo nuevo = new Nodo(dato);
            if (IsVacia())
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola.SetSiguiente(nuevo);
                nuevo.SetAnterior(cola);
                cola = nuevo;
            }
            ++cuenta;
        }

        public object Desencolar()
        {
            if (IsVacia())
                throw new Exception("La cola esta vacia");

            object dato = cabeza.GetDato();
            cabeza = cabeza.GetSiguiente();

            if (cabeza != null)
                cola.SetAnterior(null);
            else
                cola = null;

            --cuenta;
            return dato;
        }

        public object Peek()
        {
            if (IsVacia())
                throw new Exception("La cola esta vacia");

            return cabeza.GetDato();
        }

        public int Tamano()
        {
            return cuenta;
        }
    }
}
