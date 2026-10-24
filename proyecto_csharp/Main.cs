using ProyectoCsharp.Collection;
using ProyectoCsharp.Entity;

namespace ProyectoCsharp
{
    public class SistemaEnvios
    {
        private static readonly Lista listaGeneral = new Lista();
        private static readonly Cola colaPendientes = new Cola();
        private static readonly Pila pilaHistorial = new Pila();

        public static void Run(string[] args)
        {
            int opcion = -1;
            do
            {
                Menu();
                try
                {
                    Console.Write("Seleccione una opcion: ");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out opcion))
                        throw new FormatException("Por favor, ingrese un numero valido.");

                    switch (opcion)
                    {
                        case 1:
                            RegistrarElemento();
                            break;
                        case 2:
                            EnviarAColaPendientes();
                            break;
                        case 3:
                            ProcesarSiguienteElemento();
                            break;
                        case 4:
                            BuscarEnListaGeneral();
                            break;
                        case 5:
                            CancelarElementosPendientes();
                            break;
                        case 6:
                            DeshacerUltimoProcesamiento();
                            break;
                        case 7:
                            MostrarReportesBasicos();
                            break;
                        case 8:
                            MostrarListaGeneral();
                            break;
                        case 0:
                            Console.WriteLine("\nSaliendo del sistema. ¡Hasta pronto!");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida. Ingrese un numero entre 0 y 9.");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error inesperado: " + e.Message);
                }

                Console.WriteLine();
            } while (opcion != 0);
        }

        public static void Menu()
        {
            Console.WriteLine("==================== MENU ====================");
            Console.WriteLine("1. Registrar un nuevo elemento.");
            Console.WriteLine("2. Enviarlo a una cola de pendientes.");
            Console.WriteLine("3. Procesar el siguiente elemento pendiente.");
            Console.WriteLine("4. Buscar elementos en la lista general.");
            Console.WriteLine("5. Cancelar elementos pendientes.");
            Console.WriteLine("6. Deshacer el ultimo procesamiento.");
            Console.WriteLine("7. Mostrar reportes basicos.");
            Console.WriteLine("8. Mostrar lista general de paquetes");
            Console.WriteLine("0. Salir.");
            Console.WriteLine("==============================================");
        }

        private static void RegistrarElemento()
        {
            Console.WriteLine("\n--- Registrar Nuevo Paquete ---");
            Console.Write("Ingrese origen: ");
            string origen = Console.ReadLine().Trim();

            Console.Write("Ingrese destino: ");
            string destino = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                Console.WriteLine("Advertencia: Los campos no pueden estar vacios.");
                return;
            }

            var paqueteEnvio = new PaqueteEnvio(destino, origen);
            try
            {
                listaGeneral.Agregar(paqueteEnvio);
                Console.WriteLine("Elemento registrado exitosamente en memoria:" + paqueteEnvio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al registrar el elemento: " + e.Message);
            }
        }

        private static void EnviarAColaPendientes()
        {
            Console.WriteLine("\n--- Enviar a Cola de Pendientes ---");
            Console.Write("Ingrese el numero de guia del paquete a enviar: ");
            string resp = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(resp))
            {
                Console.WriteLine("Advertencia: El numero de guia no puede estar vacio.");
                return;
            }

            try
            {
                for (int i = 0; i < listaGeneral.CuentaElementos(); i++)
                {
                    PaqueteEnvio p = (PaqueteEnvio)listaGeneral.BuscarDato(i);
                    if (resp.Equals(p.GetNumeroGuia()))
                        colaPendientes.Encolar(p);
                }
                Console.WriteLine("Elemento enviado correctamente a la cola de pendientes.");
                Console.WriteLine("Total de elementos pendientes en la cola: " + colaPendientes.Tamano());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al encolar el elemento: " + e.Message);
            }
        }

        private static void ProcesarSiguienteElemento()
        {
            Console.WriteLine("\n--- Procesar Siguiente Elemento Pendiente ---");
            if (colaPendientes.IsVacia())
            {
                Console.WriteLine("No hay elementos pendientes por procesar en la cola.");
                return;
            }

            try
            {
                PaqueteEnvio p = (PaqueteEnvio)colaPendientes.Desencolar();
                Console.WriteLine("Procesando elemento pendiente...");
                GuardarEnPilaHistorial(p);
                Console.WriteLine("Elemento procesado con exito!");
                Console.WriteLine("Elementos restantes en cola: " + colaPendientes.Tamano());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al procesar el elemento: " + e.Message);
            }
        }

        private static void GuardarEnPilaHistorial(PaqueteEnvio paqueteEnvio)
        {
            if (paqueteEnvio == null)
            {
                Console.WriteLine("No hay ningun elemento procesado recientemente para guardar en el historial.");
                return;
            }
            try
            {
                pilaHistorial.Apilar(paqueteEnvio);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al apilar el elemento en el historial: " + e.Message);
            }
        }

        private static void BuscarEnListaGeneral()
        {
            Console.WriteLine("\n--- Buscar Elementos en Lista General ---");
            if (listaGeneral.IsVacia())
            {
                Console.WriteLine("La lista general esta vacia. No hay elementos para buscar.");
                return;
            }
            Console.WriteLine("Ingresa la guia del paquete a buscar:");
            string guiaBuscar = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(guiaBuscar))
            {
                Console.WriteLine("Advertencia: El numero de guia no puede estar vacio.");
                return;
            }
            try
            {
                for (int i = 0; i < listaGeneral.CuentaElementos(); i++)
                {
                    PaqueteEnvio p = (PaqueteEnvio)listaGeneral.BuscarDato(i);
                    if (guiaBuscar.Equals(p.GetNumeroGuia()))
                    {
                        Console.WriteLine("Elemento encontrado en la lista general:");
                        Console.WriteLine(p);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al buscar el elemento: " + e.Message);
            }
        }

        private static void CancelarElementosPendientes()
        {
            Console.WriteLine("\n--- Cancelar Elementos Pendientes ---");
            if (colaPendientes.IsVacia())
            {
                Console.WriteLine("No hay elementos pendientes para cancelar en la cola.");
                return;
            }

            int count = 0;
            try
            {
                Console.WriteLine("Cancelando todos los elementos pendientes...");
                while (!colaPendientes.IsVacia())
                {
                    colaPendientes.Desencolar();
                    count++;
                }
                Console.WriteLine("Se cancelaron todos los elementos pendientes (" + count + " elementos cancelados).");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al cancelar elementos: " + e.Message);
            }
        }

        private static void DeshacerUltimoProcesamiento()
        {
            Console.WriteLine("\n--- Deshacer Ultimo Procesamiento ---");
            if (pilaHistorial.IsVacia())
            {
                Console.WriteLine("No hay historial de procesamientos para deshacer.");
                return;
            }

            try
            {
                PaqueteEnvio deshecho = (PaqueteEnvio)pilaHistorial.Desapilar();
                Console.WriteLine("Se ha deshecho el ultimo procesamiento del historial:");
                Console.WriteLine(deshecho);

                colaPendientes.Encolar(deshecho);
                Console.WriteLine("El paquete ha sido devuelto a la cola de pendientes.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al deshacer el procesamiento: " + e.Message);
            }
        }

        private static void MostrarReportesBasicos()
        {
            Console.WriteLine("\n================ REPORTES BASICOS ================");

            Console.WriteLine("\n--- LISTA GENERAL ---");
            Console.WriteLine("Total de elementos en la lista: " + listaGeneral.CuentaElementos());
            if (listaGeneral.IsVacia())
            {
                Console.WriteLine("  (Lista vacia)");
            }
            else
            {
                try
                {
                    for (int i = 0; i < listaGeneral.CuentaElementos(); i++)
                        Console.WriteLine("  [" + i + "] " + listaGeneral.BuscarDato(i));
                }
                catch (Exception e)
                {
                    Console.WriteLine("  Error al listar elementos: " + e.Message);
                }
            }

            Console.WriteLine("\n--- COLA DE PENDIENTES ---");
            Console.WriteLine("Total de elementos en cola: " + colaPendientes.Tamano());
            if (colaPendientes.IsVacia())
            {
                Console.WriteLine("  (Cola vacia)");
            }
            else
            {
                try
                {
                    Console.WriteLine("  Frente de la cola (siguiente a procesar): " + colaPendientes.Peek());
                }
                catch (Exception e)
                {
                    Console.WriteLine("  Error al consultar frente: " + e.Message);
                }
            }

            Console.WriteLine("\n--- PILA DE HISTORIAL (PROCESADOS) ---");
            Console.WriteLine("Total de elementos en historial: " + pilaHistorial.Tamano());
            if (pilaHistorial.IsVacia())
            {
                Console.WriteLine("  (Historial vacio)");
            }
            else
            {
                try
                {
                    Console.WriteLine("  Cima de la pila (ultimo procesado): " + pilaHistorial.Peek());
                }
                catch (Exception e)
                {
                    Console.WriteLine("  Error al consultar cima: " + e.Message);
                }
            }

            Console.WriteLine("==================================================");
        }

        private static void MostrarListaGeneral()
        {
            Console.WriteLine("\n================ LISTA GENERAL ================");
            if (listaGeneral.IsVacia())
            {
                Console.WriteLine("La lista esta vacia.");
            }
            else
            {
                try
                {
                    for (int i = 0; i < listaGeneral.CuentaElementos(); i++)
                        Console.WriteLine("[" + i + "] " + listaGeneral.BuscarDato(i));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al listar elementos: " + e.Message);
                }
            }
        }
    }
}
