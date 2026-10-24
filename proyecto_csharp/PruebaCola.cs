using ProyectoCsharp.Collection;

namespace ProyectoCsharp
{
    public class PruebaCola
    {
        public static void Run(string[] args)
        {
            try
            {
                Cola cola = new Cola();

                cola.Encolar("Toyota");
                cola.Encolar("Mazda");
                cola.Encolar("BMW");

                Console.WriteLine("Elementos en la cola: " + cola.Tamano());
                Console.WriteLine("Frente: " + cola.Peek());

                Console.WriteLine("Atendiendo: " + cola.Desencolar());
                Console.WriteLine("Atendiendo: " + cola.Desencolar());

                Console.WriteLine("Elementos en la cola: " + cola.Tamano());
                Console.WriteLine("Frente actual: " + cola.Peek());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
