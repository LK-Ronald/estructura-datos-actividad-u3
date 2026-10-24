namespace ProyectoCsharp.Collection
{
    public class Pila
    {
        private int cuenta;
        private Nodo cabeza;

        public Pila()
        {
            cuenta = 0;
            cabeza = null;
        }

        public bool IsVacia()
        {
            return (cuenta == 0);
        }

        public void Apilar(object dato)
        {
            if (dato == null)
                throw new Exception("El dato no puede ser nulo");

            Nodo nuevo = new Nodo(dato);
            if (IsVacia())
            {
                cabeza = nuevo;
            }
            else
            {
                nuevo.SetAnterior(cabeza);
                nuevo.SetSiguiente(cabeza);
                cabeza = nuevo;
            }
            ++cuenta;
        }

        public object Desapilar()
        {
            if (IsVacia())
                throw new Exception("La pila esta vacia");

            object dato = cabeza.GetDato();
            cabeza = cabeza.GetAnterior();

            if (cabeza != null)
                cabeza.SetSiguiente(null);

            --cuenta;
            return dato;
        }

        public object Peek()
        {
            if (IsVacia())
                throw new Exception("La pila esta vacia");

            return cabeza.GetDato();
        }

        public int Tamano()
        {
            return cuenta;
        }
    }
}
