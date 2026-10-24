import 'dart:io';
import 'collection/cola.dart';
import 'collection/lista.dart';
import 'collection/pila.dart';
import 'entity/paquete_envio.dart';

final Lista listaGeneral = Lista();
final Cola colaPendientes = Cola();
final Pila pilaHistorial = Pila();

void main() {
  int opcion = -1;
  do {
    menu();
    try {
      stdout.write('Seleccione una opcion: ');
      final input = stdin.readLineSync()?.trim() ?? '';
      opcion = int.parse(input);

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
          print('\nSaliendo del sistema. ¡Hasta pronto!');
          break;
        default:
          print('Opcion no valida. Ingrese un numero entre 0 y 8.');
          break;
      }
    } on FormatException {
      print('Error: Por favor, ingrese un numero valido.');
    } catch (e) {
      print('Error inesperado: $e');
    }

    print('');
  } while (opcion != 0);
}

void menu() {
  print('==================== MENU ====================');
  print('1. Registrar un nuevo elemento.');
  print('2. Enviarlo a una cola de pendientes.');
  print('3. Procesar el siguiente elemento pendiente.');
  print('4. Buscar elementos en la lista general.');
  print('5. Cancelar elementos pendientes.');
  print('6. Deshacer el ultimo procesamiento.');
  print('7. Mostrar reportes basicos.');
  print('8. Mostrar lista general de paquetes');
  print('0. Salir.');
  print('==============================================');
}

void registrarElemento() {
  print('\n--- Registrar Nuevo Paquete ---');
  stdout.write('Ingrese origen: ');
  final origen = stdin.readLineSync()?.trim() ?? '';

  stdout.write('Ingrese destino: ');
  final destino = stdin.readLineSync()?.trim() ?? '';

  if (origen.isEmpty || destino.isEmpty) {
    print('Advertencia: Los campos no pueden estar vacios.');
    return;
  }

  final paqueteEnvio = PaqueteEnvio(destino, origen);
  try {
    listaGeneral.agregar(paqueteEnvio);
    print('Elemento registrado exitosamente en memoria: $paqueteEnvio');
  } catch (e) {
    print('Error al registrar el elemento: $e');
  }
}

void enviarAColaPendientes() {
  print('\n--- Enviar a Cola de Pendientes ---');
  stdout.write('Ingrese el numero de guia del paquete a enviar: ');
  final resp = stdin.readLineSync()?.trim() ?? '';

  if (resp.isEmpty) {
    print('Advertencia: El numero de guia no puede estar vacio.');
    return;
  }

  try {
    for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
      final p = listaGeneral.buscarDatoByIndice(i) as PaqueteEnvio;
      if (resp == p.getNumeroGuia()) {
        colaPendientes.encolar(p);
      }
    }
    print('Elemento enviado correctamente a la cola de pendientes.');
    print('Total de elementos pendientes en la cola: ${colaPendientes.tamano()}');
  } catch (e) {
    print('Error al encolar el elemento: $e');
  }
}

void procesarSiguienteElemento() {
  print('\n--- Procesar Siguiente Elemento Pendiente ---');
  if (colaPendientes.isVacia()) {
    print('No hay elementos pendientes por procesar en la cola.');
    return;
  }

  try {
    final p = colaPendientes.desencolar() as PaqueteEnvio;
    print('Procesando elemento pendiente...');
    guardarEnPilaHistorial(p);
    print('Elemento procesado con exito!');
    print('Elementos restantes en cola: ${colaPendientes.tamano()}');
  } catch (e) {
    print('Error al procesar el elemento: $e');
  }
}

void guardarEnPilaHistorial(PaqueteEnvio paqueteEnvio) {
  try {
    pilaHistorial.apilar(paqueteEnvio);
  } catch (e) {
    print('Error al apilar el elemento en el historial: $e');
  }
}

void buscarEnListaGeneral() {
  print('\n--- Buscar Elementos en Lista General ---');
  if (listaGeneral.isVacia()) {
    print('La lista general esta vacia. No hay elementos para buscar.');
    return;
  }
  print('Ingresa la guia del paquete a buscar:');
  final guiaBuscar = stdin.readLineSync()?.trim() ?? '';
  if (guiaBuscar.isEmpty) {
    print('Advertencia: El numero de guia no puede estar vacio.');
    return;
  }
  try {
    for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
      final p = listaGeneral.buscarDatoByIndice(i) as PaqueteEnvio;
      if (guiaBuscar == p.getNumeroGuia()) {
        print('Elemento encontrado en la lista general:');
        print(p);
      }
    }
  } catch (e) {
    print('Error al buscar el elemento: $e');
  }
}

void cancelarElementosPendientes() {
  print('\n--- Cancelar Elementos Pendientes ---');
  if (colaPendientes.isVacia()) {
    print('No hay elementos pendientes para cancelar en la cola.');
    return;
  }

  int count = 0;
  try {
    print('Cancelando todos los elementos pendientes...');
    while (!colaPendientes.isVacia()) {
      colaPendientes.desencolar();
      count++;
    }
    print('Se cancelaron todos los elementos pendientes ($count elementos cancelados).');
  } catch (e) {
    print('Error al cancelar elementos: $e');
  }
}

void deshacerUltimoProcesamiento() {
  print('\n--- Deshacer Ultimo Procesamiento ---');
  if (pilaHistorial.isVacia()) {
    print('No hay historial de procesamientos para deshacer.');
    return;
  }

  try {
    final deshecho = pilaHistorial.desapilar() as PaqueteEnvio;
    print('Se ha deshecho el ultimo procesamiento del historial:');
    print(deshecho);

    colaPendientes.encolar(deshecho);
    print('El paquete ha sido devuelto a la cola de pendientes.');
  } catch (e) {
    print('Error al deshacer el procesamiento: $e');
  }
}

void mostrarReportesBasicos() {
  print('\n================ REPORTES BASICOS ================');

  print('\n--- LISTA GENERAL ---');
  print('Total de elementos en la lista: ${listaGeneral.cuentaElementos()}');
  if (listaGeneral.isVacia()) {
    print('  (Lista vacia)');
  } else {
    try {
      for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
        print('  [$i] ${listaGeneral.buscarDatoByIndice(i)}');
      }
    } catch (e) {
      print('  Error al listar elementos: $e');
    }
  }

  print('\n--- COLA DE PENDIENTES ---');
  print('Total de elementos en cola: ${colaPendientes.tamano()}');
  if (colaPendientes.isVacia()) {
    print('  (Cola vacia)');
  } else {
    try {
      print('  Frente de la cola (siguiente a procesar): ${colaPendientes.peek()}');
    } catch (e) {
      print('  Error al consultar frente: $e');
    }
  }

  print('\n--- PILA DE HISTORIAL (PROCESADOS) ---');
  print('Total de elementos en historial: ${pilaHistorial.tamano()}');
  if (pilaHistorial.isVacia()) {
    print('  (Historial vacio)');
  } else {
    try {
      print('  Cima de la pila (ultimo procesado): ${pilaHistorial.peek()}');
    } catch (e) {
      print('  Error al consultar cima: $e');
    }
  }

  print('==================================================');
}

void mostrarListaGeneral() {
  print('\n================ LISTA GENERAL ================');
  if (listaGeneral.isVacia()) {
    print('La lista esta vacia.');
  } else {
    try {
      for (int i = 0; i < listaGeneral.cuentaElementos(); i++) {
        print('[$i] ${listaGeneral.buscarDatoByIndice(i)}');
      }
    } catch (e) {
      print('Error al listar elementos: $e');
    }
  }
}
