using ProyectoCsharp.Collection;

namespace ProyectoCsharp
{
    public class PruebaLista
    {
        public static void Run(string[] args)
        {
            string s1 = "Toyota";
            string s2 = "Mazda";
            Lista lista = new Lista();

            try
            {
                Console.WriteLine("Elementos: " + lista.CuentaElementos());
                lista.Agregar(s1);
                Console.WriteLine("Elementos: " + lista.CuentaElementos());
                lista.Agregar(s2);
                Console.WriteLine("Elementos: " + lista.CuentaElementos());
                Console.WriteLine("En la posicion 0: " + lista.BuscarDato(0));
                Console.WriteLine("En la posicion 1: " + lista.BuscarDato(1));
                Console.WriteLine("Mazda esta en la posicion: " + lista.BuscarDato("Mazda"));
                Console.WriteLine("Toyota esta en la posicion: " + lista.BuscarDato("Toyota"));
                Console.WriteLine("BMW esta en la posicion: " + lista.BuscarDato("BMW"));
                Console.WriteLine(lista.BuscarDato(2));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
