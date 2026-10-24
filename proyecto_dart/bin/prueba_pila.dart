import 'collection/pila.dart';

void main() {
  try {
    final pila = Pila();

    pila.apilar('Toyota');
    pila.apilar('Mazda');
    pila.apilar('BMW');

    print('Elementos en la pila: ${pila.tamano()}');
    print('Cima: ${pila.peek()}');

    print('Sacando: ${pila.desapilar()}');
    print('Sacando: ${pila.desapilar()}');

    print('Elementos en la pila: ${pila.tamano()}');
    print('Cima actual: ${pila.peek()}');
  } catch (e) {
    print('Error: $e');
  }
}
