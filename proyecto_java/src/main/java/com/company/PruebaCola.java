package com.company;

public class PruebaCola {
    public static void main(String[] args) {
        try {

            Cola cola = new Cola();

            cola.encolar("Toyota");
            cola.encolar("Mazda");
            cola.encolar("BMW");

            System.out.println("Elementos en la cola: " + cola.tamano());
            System.out.println("Frente: " + cola.peek());

            System.out.println("Atendiendo: " + cola.desencolar());
            System.out.println("Atendiendo: " + cola.desencolar());

            System.out.println("Elementos en la cola: " + cola.tamano());
            System.out.println("Frente actual: " + cola.peek());

        } catch (Exception e) {
            System.out.println("Error: " + e.getMessage());
        }


    }
}
