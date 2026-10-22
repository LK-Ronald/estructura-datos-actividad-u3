package com.company;

public class Nodo {
    private Object dato;
    private Nodo siguiente;
    private Nodo anterior;

    public Nodo() {
    }

    public Nodo(Object dato) {
        this.dato = dato;
    }

    public void setDato(Object dato) {
        this.dato = dato;
    }

    public void setSiguiente(Nodo siguiente) {
        this.siguiente = siguiente;
    }

    public void setAnterior(Nodo anterior) {
        this.anterior = anterior;
    }

    public Object getDato() {
        return dato;
    }

    public Nodo getSiguiente() {
        return siguiente;
    }

    public Nodo getAnterior() {
        return anterior;
    }
}
