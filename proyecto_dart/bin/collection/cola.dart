import 'nodo.dart';

class Cola {
  int _cuenta = 0;
  Nodo? _cabeza;
  Nodo? _cola;

  Cola() {
    _cuenta = 0;
    _cabeza = null;
    _cola = null;
  }

  bool isVacia() => _cuenta == 0;

  void encolar(Object dato) {
    final nuevo = Nodo.conDato(dato);
    if (isVacia()) {
      _cabeza = nuevo;
      _cola = nuevo;
    } else {
      _cola!.siguiente = nuevo;
      nuevo.anterior = _cola;
      _cola = nuevo;
    }
    ++_cuenta;
  }

  Object? desencolar() {
    if (isVacia()) {
      throw Exception('La cola esta vacia');
    }
    final dato = _cabeza!.dato;
    _cabeza = _cabeza!.siguiente;

    if (_cabeza != null) {
      _cola!.anterior = null;
    } else {
      _cola = null;
    }

    --_cuenta;
    return dato;
  }

  Object? peek() {
    if (isVacia()) {
      throw Exception('La cola esta vacia');
    }
    return _cabeza!.dato;
  }

  int tamano() => _cuenta;
}
