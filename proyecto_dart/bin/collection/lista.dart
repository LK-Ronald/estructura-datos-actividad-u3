import 'nodo.dart';

class Lista {
  int _cuenta = 0;
  Nodo? _cabeza;
  Nodo? _cola;

  bool isVacia() => _cuenta == 0;

  void agregar(Object dato) {
    final objetivo = Nodo.conDato(dato);
    if (isVacia()) {
      objetivo.anterior = null;
      objetivo.siguiente = null;
      _cabeza = objetivo;
      _cola = objetivo;
    } else {
      _cola!.siguiente = objetivo;
      objetivo.anterior = _cola;
      objetivo.siguiente = null;
      _cola = objetivo;
    }
    ++_cuenta;
  }

  Nodo _buscarPorIndice(int indice) {
    if (isVacia()) {
      throw Exception('La lista esta vacia');
    }
    if (indice < 0 || indice >= _cuenta) {
      throw Exception(
          'La posicion $indice esta fuera de rango 0 - ${_cuenta - 1}');
    }
    Nodo? actual = _cabeza;
    for (int i = 0; i < _cuenta; ++i) {
      if (indice == i) break;
      actual = actual!.siguiente;
    }
    return actual!;
  }

  int _buscarPorDato(Object dato) {
    if (isVacia()) {
      throw Exception('La lista esta vacia');
    }
    Nodo? actual = _cabeza;
    for (int i = 0; i < _cuenta; ++i) {
      if (actual!.dato == dato) {
        return i;
      }
      actual = actual.siguiente;
    }
    throw Exception('El elemento no esta en la lista');
  }

  Object? buscarDatoByIndice(int indice) {
    final actual = _buscarPorIndice(indice);
    return actual.dato;
  }

  int buscarDatoByObjeto(Object dato) {
    return _buscarPorDato(dato);
  }

  int cuentaElementos() => _cuenta;
}
