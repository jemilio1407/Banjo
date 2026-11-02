using UnityEngine;

public class Arma
{
    public string nombre;
    public int costo;
    public float duracion;

    public int existencias;

    public Arma(string nombre, int costo, float duracion, int existencias)
    {
        this.nombre = nombre;
        this.costo = costo;
        this.duracion = duracion;
        this.existencias = existencias;
    }

    public Refuerzo Crear(int numero)
    {
        if (existencias <= 0)
        {
            return null;
        }

        existencias = existencias - 1;

        return new Refuerzo(numero, nombre, costo, duracion);
    }
}
