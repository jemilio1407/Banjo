using UnityEngine;
using UnityEngine.Rendering;

public class Estrella : Estado
{

    public float tiempo;
    public string anterior;

    public Maquina maquina;
    public override void Entrar(string anterior)
    {
        tiempo = 0;
        this.anterior = anterior;
        Debug.Log("Mario es invensible");
    }
    public override void Salir(string siguiente)
    {
        Debug.Log("Mario no es invensible");
    }
    public override string Actualizar(float dt)
    {
        tiempo += dt;
        Debug.Log("Tiempo transcurrido: " + tiempo);

        if (tiempo >= 5f)
        {
            tiempo = 0;
            return anterior;
        }
        return null;
    }
    public override string AlRecibir(string trigger, int valor)
    {
        if (trigger == "Hongo")
        {
            return null;
        }
        if (trigger == "Flor")
        {
            return null;
        }

        if (trigger == "Estrella")
        {
            return null;
        }

        if (trigger == "Daño")
        {
            return null;
        }
        return null;
    }
}
