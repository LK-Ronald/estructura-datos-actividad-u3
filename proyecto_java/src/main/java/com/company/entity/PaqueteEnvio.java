package com.company.entity;

import java.time.LocalDate;
import java.util.UUID;

public class PaqueteEnvio {
    private final String numeroGuia;
    private String destino;
    private String origen;
    private final LocalDate fecha;

    public PaqueteEnvio(String destino, String origen) {
        this.numeroGuia = UUID.randomUUID().toString();
        this.destino = destino;
        this.origen = origen;
        this.fecha = LocalDate.now();
    }

    public String getNumeroGuia() {
        return numeroGuia;
    }

    public String getDestino() {
        return destino;
    }

    public String getOrigen() {
        return origen;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setDestino(String destino) {
        this.destino = destino;
    }

    public void setOrigen(String origen) {
        this.origen = origen;
    }

    @Override
    public String toString() {
        return "PaqueteEnvio{" +
                "numeroGuia='" + numeroGuia + '\'' +
                ", origen='" + origen + '\'' +
                ", destino='" + destino + '\'' +
                ", fecha=" + fecha +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        PaqueteEnvio that = (PaqueteEnvio) o;
        return numeroGuia != null ? numeroGuia.equalsIgnoreCase(that.numeroGuia) : that.numeroGuia == null;
    }

    @Override
    public int hashCode() {
        return numeroGuia != null ? numeroGuia.toLowerCase().hashCode() : 0;
    }
}
