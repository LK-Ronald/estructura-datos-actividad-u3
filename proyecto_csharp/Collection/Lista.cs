namespace ProyectoCsharp.Collection
{
    public class Lista
    {
        private int cuenta;
        private Nodo cabeza;
        private Nodo cola;

        public bool IsVacia()
        {
            return (cuenta == 0);
        }

        public void Agregar(object dato)
        {
            if (dato == null)
                throw new Exception("El dato no puede ser nulo");

            Nodo objetivo = new Nodo(dato);
            if (IsVacia())
            {
                objetivo.SetAnterior(null);
                objetivo.SetSiguiente(null);
                cabeza = objetivo;
                cola = objetivo;
            }
            else
            {
                cola.SetSiguiente(objetivo);
                objetivo.SetAnterior(cola);
                objetivo.SetSiguiente(null);
                cola = objetivo;
            }
            ++cuenta;
        }

        private Nodo Buscar(int indice)
        {
            if (IsVacia())
                throw new Exception("La lista esta vacia");

            if (indice < 0 || indice >= cuenta)
                throw new Exception("La posicion " + indice + " esta fuera de rango 0 - " + (cuenta - 1));

            Nodo actual = cabeza;
            for (int i = 0; i < cuenta; ++i)
            {
                if (indice == i)
                    break;
                actual = actual.GetSiguiente();
            }
            return actual;
        }

        private int Buscar(object dato)
        {
            if (IsVacia())
                throw new Exception("La lista esta vacia");

            Nodo actual = cabeza;
            for (int i = 0; i < cuenta; ++i)
            {
                if (actual.GetDato().Equals(dato))
                    return i;
                actual = actual.GetSiguiente();
            }
            throw new Exception("El elemento no esta en la lista");
        }

        public object BuscarDato(int indice)
        {
            Nodo actual = Buscar(indice);
            return actual.GetDato();
        }

        public int BuscarDato(object dato)
        {
            return Buscar(dato);
        }

        public int CuentaElementos()
        {
            return cuenta;
        }
    }
}
