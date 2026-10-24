package com.company;

import com.company.collection.Cola;
import com.company.collection.Lista;
import com.company.collection.Pila;
import com.company.entity.PaqueteEnvio;

import java.util.Scanner;

public class Main {
    private static final Scanner sc = new Scanner(System.in);

    private static final Lista listaGeneral = new Lista();
    private static final Cola colaPendientes = new Cola();
    private static final Pila pilaHistorial = new Pila();

    public static void main(String[] args) {
        int opcion = -1;
        do {
            menu();
            try {
                System.out.print("Seleccione una opcion: ");
                opcion = sc.nextInt();
                sc.nextLine();

                switch (opcion) {
                    case 1:
                        registrarElemento();
                        break;
                    case 2:
                        enviarAColaPendientes();
                        break;
                    case 3:
                        procesarSiguienteElemento();
                        break;
                    case 4:
                        buscarEnListaGeneral();
                        break;
                    case 5:
                        cancelarElementosPendientes();
                        break;
                    case 6:
                        deshacerUltimoProcesamiento();
                        break;
                    case 7:
                        mostrarReportesBasicos();
                        break;
                    case 8:
                        mostrarListaGeneral();
                        break;
                    case 0:
                        System.out.println("\nSaliendo del sistema. ¡Hasta pronto!");
                        sc.close();
                        break;
                    default:
                        System.out.println("Opcion no valida. Ingrese un numero entre 0 y 9.");
                        break;
                }
            } catch (NumberFormatException e) {
                System.out.println("Error: Por favor, ingrese un numero valido.");
            } catch (Exception e) {
                System.out.println("Error inesperado: " + e.getMessage());
            }

            System.out.println();
        } while (opcion != 0);
    }

    public static void menu() {
        System.out.println("==================== MENU ====================");
        System.out.println("1. Registrar un nuevo elemento.");
        System.out.println("2. Enviarlo a una cola de pendientes.");
        System.out.println("3. Procesar el siguiente elemento pendiente.");
        System.out.println("4. Buscar elementos en la lista general.");
        System.out.println("5. Cancelar elementos pendientes.");
        System.out.println("6. Deshacer el ultimo procesamiento.");
        System.out.println("7. Mostrar reportes basicos.");
        System.out.println("8. Mostrar lista general de paquetes");
        System.out.println("0. Salir.");
        System.out.println("==============================================");
    }

    private static void registrarElemento() {
        System.out.println("\n--- Registrar Nuevo Paquete ---");
        System.out.print("Ingrese origen: ");
        String origen = sc.nextLine().trim();

        System.out.print("Ingrese destino: ");
        String destino = sc.nextLine().trim();

        if (origen.isEmpty() || destino.isEmpty()) {
            System.out.println("Advertencia: Los campos no pueden estar vacios.");
            return;
        }

        var paqueteEnvio = new PaqueteEnvio(destino, origen);
        try {
            listaGeneral.agregar(paqueteEnvio);
            System.out.println("Elemento registrado exitosamente en memoria:" + paqueteEnvio);
        } catch (Exception e) {
            System.out.println("Error al registrar el elemento: " + e.getMessage());
        }
    }

    private static void enviarAColaPendientes() {
        System.out.println("\n--- Enviar a Cola de Pendientes ---");

        System.out.print("Ingrese el numero de guia del paquete a enviar: ");
        String resp = sc.nextLine().trim();

        if (resp.isEmpty()) {
            System.out.println("Advertencia: El numero de guia no puede estar vacio.");
            return;
        }

        try {
            for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
                PaqueteEnvio p = (PaqueteEnvio) listaGeneral.buscarDato(i);
                if (resp.equals(p.getNumeroGuia())) {
                    colaPendientes.encolar(p);
                }
            }
            System.out.println("Elemento enviado correctamente a la cola de pendientes.");
            System.out.println("Total de elementos pendientes en la cola: " + colaPendientes.tamano());
        } catch (Exception e) {
            System.out.println("Error al encolar el elemento: " + e.getMessage());
        }
    }

    private static void procesarSiguienteElemento() {
        System.out.println("\n--- Procesar Siguiente Elemento Pendiente ---");
        if (colaPendientes.isVacia()) {
            System.out.println("No hay elementos pendientes por procesar en la cola.");
            return;
        }

        try {
            PaqueteEnvio p = (PaqueteEnvio) colaPendientes.desencolar();
            System.out.println("Procesando elemento pendiente...");
            guardarEnPilaHistorial(p);
            System.out.println("Elemento procesado con exito!");
            System.out.println("Elementos restantes en cola: " + colaPendientes.tamano());
        } catch (Exception e) {
            System.out.println("Error al procesar el elemento: " + e.getMessage());
        }
    }

    private static void guardarEnPilaHistorial(final PaqueteEnvio paqueteEnvio) {
        if (paqueteEnvio == null) {
            System.out.println("No hay ningun elemento procesado recientemente para guardar en el historial.");
            return;
        }
        try {
            pilaHistorial.apilar(paqueteEnvio);
        } catch (Exception e) {
            System.out.println("Error al apilar el elemento en el historial: " + e.getMessage());
        }
    }

    private static void buscarEnListaGeneral() {
        System.out.println("\n--- Buscar Elementos en Lista General ---");
        if (listaGeneral.isVacia()) {
            System.out.println("La lista general esta vacia. No hay elementos para buscar.");
            return;
        }
        System.out.println("Ingresa la guia del paquete a buscar:");
        String guiaBuscar = sc.nextLine().trim();
        if (guiaBuscar.isEmpty()) {
            System.out.println("Advertencia: El numero de guia no puede estar vacio.");
            return;
        }
        try {
            for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
                PaqueteEnvio p = (PaqueteEnvio) listaGeneral.buscarDato(i);
                if (guiaBuscar.equals(p.getNumeroGuia())) {
                    System.out.println("Elemento encontrado en la lista general:");
                    System.out.println(p);
                }
            }
        } catch (Exception e) {
            System.out.println("Error al buscar el elemento: " + e.getMessage());
        }
    }

    private static void cancelarElementosPendientes() {
        System.out.println("\n--- Cancelar Elementos Pendientes ---");
        if (colaPendientes.isVacia()) {
            System.out.println("No hay elementos pendientes para cancelar en la cola.");
            return;
        }

        int count = 0;
        try {
            System.out.println("Cancelando todos los elementos pendientes...");
            while (!colaPendientes.isVacia()) {
                colaPendientes.desencolar();
                count++;
            }
            System.out.println("Se cancelaron todos los elementos pendientes (" + count + " elementos cancelados).");
        } catch (Exception e) {
            System.out.println("Error al cancelar elementos: " + e.getMessage());
        }
    }

    private static void deshacerUltimoProcesamiento() {
        System.out.println("\n--- Deshacer Ultimo Procesamiento ---");
        if (pilaHistorial.isVacia()) {
            System.out.println("No hay historial de procesamientos para deshacer.");
            return;
        }

        try {
            PaqueteEnvio deshecho = (PaqueteEnvio) pilaHistorial.desapilar();
            System.out.println("Se ha deshecho el ultimo procesamiento del historial:");
            System.out.println(deshecho);

            colaPendientes.encolar(deshecho);
            System.out.println("El paquete ha sido devuelto a la cola de pendientes.");
        } catch (Exception e) {
            System.out.println("Error al deshacer el procesamiento: " + e.getMessage());
        }
    }

    private static void mostrarReportesBasicos() {
        System.out.println("\n================ REPORTES BASICOS ================");

        System.out.println("\n--- LISTA GENERAL ---");
        System.out.println("Total de elementos en la lista: " + listaGeneral.cuentaElementos());
        if (listaGeneral.isVacia()) {
            System.out.println("  (Lista vacia)");
        } else {
            try {
                for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
                    System.out.println("  [" + i + "] " + listaGeneral.buscarDato(i));
                }
            } catch (Exception e) {
                System.out.println("  Error al listar elementos: " + e.getMessage());
            }
        }

        System.out.println("\n--- COLA DE PENDIENTES ---");
        System.out.println("Total de elementos en cola: " + colaPendientes.tamano());
        if (colaPendientes.isVacia()) {
            System.out.println("  (Cola vacia)");
        } else {
            try {
                System.out.println("  Frente de la cola (siguiente a procesar): " + colaPendientes.peek());
            } catch (Exception e) {
                System.out.println("  Error al consultar frente: " + e.getMessage());
            }
        }

        System.out.println("\n--- PILA DE HISTORIAL (PROCESADOS) ---");
        System.out.println("Total de elementos en historial: " + pilaHistorial.tamano());
        if (pilaHistorial.isVacia()) {
            System.out.println("  (Historial vacio)");
        } else {
            try {
                System.out.println("  Cima de la pila (ultimo procesado): " + pilaHistorial.peek());
            } catch (Exception e) {
                System.out.println("  Error al consultar cima: " + e.getMessage());
            }
        }

        System.out.println("==================================================");
    }

    private static void mostrarListaGeneral() {
        System.out.println("\n================ LISTA GENERAL ================");
        if (listaGeneral.isVacia()) {
            System.out.println("La lista esta vacia.");
        } else {
            try {
                for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
                    System.out.println("[" + i + "] " + listaGeneral.buscarDato(i));
                }
            } catch (Exception e) {
                System.out.println("Error al listar elementos: " + e.getMessage());
            }
        }
    }
}
