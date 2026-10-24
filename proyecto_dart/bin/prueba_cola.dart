import 'collection/cola.dart';

void main() {
  try {
    final cola = Cola();

    cola.encolar('Toyota');
    cola.encolar('Mazda');
    cola.encolar('BMW');

    print('Elementos en la cola: ${cola.tamano()}');
    print('Frente: ${cola.peek()}');

    print('Atendiendo: ${cola.desencolar()}');
    print('Atendiendo: ${cola.desencolar()}');

    print('Elementos en la cola: ${cola.tamano()}');
    print('Frente actual: ${cola.peek()}');
  } catch (e) {
    print('Error: $e');
  }
}
