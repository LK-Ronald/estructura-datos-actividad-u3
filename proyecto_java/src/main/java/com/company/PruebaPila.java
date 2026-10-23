package com.company;

import com.company.collection.Pila;

public class PruebaPila {
    public static void main(String[] args) {
        try {
            Pila pila = new Pila();

            pila.apilar("Toyota");
            pila.apilar("Mazda");
            pila.apilar("BMW");

            System.out.println("Elementos en la pila: " + pila.tamano());
            System.out.println("Cima: " + pila.peek());

            System.out.println("Sacando: " + pila.desapilar());
            System.out.println("Sacando: " + pila.desapilar());

            System.out.println("Elementos en la pila: " + pila.tamano());
            System.out.println("Cima actual: " + pila.peek());

        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
