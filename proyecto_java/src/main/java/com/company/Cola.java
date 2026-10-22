package com.company;

public class Cola {
    private int cuenta;
    private Nodo cabeza;
    private Nodo cola;

    public Cola() {
        cuenta = 0;
        cabeza = null;
        cola = null;
    }

    public boolean isVacia() {
        return (cuenta == 0);
    }

    public void encolar(Object dato) throws Exception {
        if (dato == null) {
            throw new Exception("El dato no puede ser nulo");
        }
        Nodo nuevo = new Nodo(dato);
        if (isVacia()) {
            cabeza = nuevo;
            cola = nuevo;
        } else {
            cola.setSiguiente(nuevo);
            nuevo.setAnterior(cola);
            cola = nuevo;
        }
        ++cuenta;
    }

    public Object desencolar() throws Exception {
        if (isVacia()) {
            throw new Exception("La cola esta vacia");
        }
        Object dato = cabeza.getDato();
        cabeza = cabeza.getSiguiente();

        if (cabeza != null) {
            cola.setAnterior(null);
        } else {
            cola = null;
        }

        --cuenta;
        return dato;
    }

    public Object peek() throws Exception {
        if (isVacia()) {
            throw new Exception("La cola esta vacia");
        }
        return cabeza.getDato();
    }

    public int tamano(){
        return cuenta;
    }
}
