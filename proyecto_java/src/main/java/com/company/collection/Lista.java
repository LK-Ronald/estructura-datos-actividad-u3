package com.company.collection;

public class Lista {
    private int cuenta;
    private Nodo cabeza;
    private Nodo cola;

    public boolean isVacia() {
        return (cuenta == 0);
    }

    public void agregar(Object dato) throws Exception {
        if (dato == null) {
            throw new Exception("El dato no puede ser nulo");
        }
        Nodo objetivo = new Nodo(dato);
        if (isVacia()) {
            objetivo.setAnterior(null);
            objetivo.setSiguiente(null);
            cabeza = objetivo;
            cola = objetivo;
        } else {
            cola.setSiguiente(objetivo);
            objetivo.setAnterior(cola);
            objetivo.setSiguiente(null);
            cola = objetivo;
        }
        ++cuenta;
    }

    private Nodo buscar(int indice) throws Exception {
        if (isVacia()) {
            throw new Exception("La lista esta vacia");
        }
        if (indice < 0 || indice >= cuenta) {
            throw new Exception("La posicion " + indice + " esta fuera de rango 0 - " + (cuenta - 1));
        }
        Nodo actual = cabeza;
        for (int i = 0; i < cuenta; ++i) {
            if (indice == i) {
                break;
            }
            actual = actual.getSiguiente();
        }
        return actual;
    }

    private int buscar(Object dato) throws Exception {
        if (isVacia()) {
            throw new Exception("La lista esta vacia");
        }
        Nodo actual = cabeza;
        for (int i = 0; i < cuenta; ++i) {
            if (actual.getDato().equals(dato)) {
                return i;
            }
            actual = actual.getSiguiente();
        }
        throw new Exception("El elemento no esta en la lista");
    }

    public Object buscarDato(int indice) throws Exception {
        Nodo actual = buscar(indice);
        return actual.getDato();
    }

    public int buscarDato(Object dato) throws Exception {
        return buscar(dato);
    }

    public int cuentaElementos() {
        return cuenta;
    }
}
