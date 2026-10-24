import 'package:uuid/uuid.dart';

class PaqueteEnvio {
  final String numeroGuia;
  String destino;
  String origen;
  final DateTime fecha;

  PaqueteEnvio(this.destino, this.origen)
      : numeroGuia = const Uuid().v4(),
        fecha = DateTime.now();

  String getNumeroGuia() => numeroGuia;

  String getDestino() => destino;

  String getOrigen() => origen;

  DateTime getFecha() => fecha;

  void setDestino(String destino) => this.destino = destino;

  void setOrigen(String origen) => this.origen = origen;

  @override
  String toString() {
    return 'PaqueteEnvio{numeroGuia: \'$numeroGuia\', origen: \'$origen\', destino: \'$destino\', fecha: ${fecha.toIso8601String().split('T')[0]}}';
  }

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
    if (other is! PaqueteEnvio) return false;
    return numeroGuia.toLowerCase() == other.numeroGuia.toLowerCase();
  }

  @override
  int get hashCode => numeroGuia.toLowerCase().hashCode;
}
