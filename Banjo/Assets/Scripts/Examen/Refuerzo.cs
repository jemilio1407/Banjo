using UnityEngine;

public class Refuerzo
{
    public int numero;
    public string nombre;
    public int costo;
    public float duracion;

    public Refuerzo(int numero, string nombre, int costo, float duracion)
    {
        this.numero = numero;
        this.nombre = nombre;
        this.costo = costo;
        this.duracion = duracion;
    }

    public string Describir()
    {
        return numero + " " + nombre + ": ($" + costo + ")";
    }
}
