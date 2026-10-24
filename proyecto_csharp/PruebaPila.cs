using ProyectoCsharp.Collection;

namespace ProyectoCsharp
{
    public class PruebaPila
    {
        public static void Run(string[] args)
        {
            try
            {
                Pila pila = new Pila();

                pila.Apilar("Toyota");
                pila.Apilar("Mazda");
                pila.Apilar("BMW");

                Console.WriteLine("Elementos en la pila: " + pila.Tamano());
                Console.WriteLine("Cima: " + pila.Peek());

                Console.WriteLine("Sacando: " + pila.Desapilar());
                Console.WriteLine("Sacando: " + pila.Desapilar());

                Console.WriteLine("Elementos en la pila: " + pila.Tamano());
                Console.WriteLine("Cima actual: " + pila.Peek());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
