package com.company;

public class Pila {
    private int cuenta;
    private Nodo cabeza;

    public Pila() {
        cuenta = 0;
        cabeza = null;
    }

    public boolean isVacia() {
        return (cuenta == 0);
    }

    public void apilar(Object dato) throws Exception {
        if (dato == null) {
            throw new Exception("El dato no puede ser nulo");
        }
        Nodo nuevo = new Nodo(dato);
        if (isVacia()) {
            cabeza = nuevo;
        } else {
            nuevo.setAnterior(cabeza);
            nuevo.setSiguiente(cabeza);
            cabeza = nuevo;
        }

        ++cuenta;
    }

    public Object desapilar() throws Exception {
        if (isVacia()) {
            throw new Exception("La pila esta vacia");
        }
        Object dato = cabeza.getDato();
        cabeza = cabeza.getAnterior();

        if (cabeza != null) {
            cabeza.setSiguiente(null);
        }
        --cuenta;
        return dato;
    }

    public Object peek() throws Exception {
        if (isVacia()) {
            throw new Exception("La pila esta vacia");
        }
        return cabeza.getDato();
    }

    public int tamano() {
        return cuenta;
    }
}
