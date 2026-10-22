package com.company;

public class PruebaLista {
    public static void main(String[] args) {
        String s1 = "Toyota";
        String s2 = "Mazda";
        Lista lista = new Lista();

        try {
            System.out.println("Elementos: " + lista.cuentaElementos());
            lista.agregar(s1);
            System.out.println("Elementos: " + lista.cuentaElementos());
            lista.agregar(s2);
            System.out.println("Elementos: " + lista.cuentaElementos());
            System.out.println("En la posicion 0: " + lista.buscarDato(0));
            System.out.println("En la posicion 1: " + lista.buscarDato(1));
            System.out.println("Mazda esta en la posicion: " + lista.buscarDato("Mazda"));
            System.out.println("Toyota esta en la posicion: " + lista.buscarDato("Toyota"));
            System.out.println("BMW esta en la posicion: " + lista.buscarDato("BMW"));
            System.out.println(lista.buscarDato(2));
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
    }
}
