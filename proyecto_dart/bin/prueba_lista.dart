import 'collection/lista.dart';

void main() {
  const s1 = 'Toyota';
  const s2 = 'Mazda';
  final lista = Lista();

  try {
    print('Elementos: ${lista.cuentaElementos()}');
    lista.agregar(s1);
    print('Elementos: ${lista.cuentaElementos()}');
    lista.agregar(s2);
    print('Elementos: ${lista.cuentaElementos()}');
    print('En la posicion 0: ${lista.buscarDatoByIndice(0)}');
    print('En la posicion 1: ${lista.buscarDatoByIndice(1)}');
    print('Mazda esta en la posicion: ${lista.buscarDatoByObjeto('Mazda')}');
    print('Toyota esta en la posicion: ${lista.buscarDatoByObjeto('Toyota')}');
    print('BMW esta en la posicion: ${lista.buscarDatoByObjeto('BMW')}');
    print(lista.buscarDatoByIndice(2));
  } catch (e) {
    print(e.toString().replaceFirst('Exception: ', ''));
  }
}
