import 'nodo.dart';

class Pila {
  int _cuenta = 0;
  Nodo? _cabeza;

  Pila() {
    _cuenta = 0;
    _cabeza = null;
  }

  bool isVacia() => _cuenta == 0;

  void apilar(Object dato) {
    final nuevo = Nodo.conDato(dato);
    if (isVacia()) {
      _cabeza = nuevo;
    } else {
      nuevo.anterior = _cabeza;
      nuevo.siguiente = _cabeza;
      _cabeza = nuevo;
    }
    ++_cuenta;
  }

  Object? desapilar() {
    if (isVacia()) {
      throw Exception('La pila esta vacia');
    }
    final dato = _cabeza!.dato;
    _cabeza = _cabeza!.anterior;

    if (_cabeza != null) {
      _cabeza!.siguiente = null;
    }
    --_cuenta;
    return dato;
  }

  Object? peek() {
    if (isVacia()) {
      throw Exception('La pila esta vacia');
    }
    return _cabeza!.dato;
  }

  int tamano() => _cuenta;
}
