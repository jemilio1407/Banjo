using UnityEngine;

public class Estrella : Estado
{


    public float tiempo;
    public string EstadoAnterior;
    public override void Entrar(string anterior)
    {
        tiempo = 0f;
        EstadoAnterior = anterior;
        Debug.Log("Mario Estrella ");
    }

    public override string Actualizar(float dt)
    {
        tiempo += dt;
        if (tiempo >= 5f) { return EstadoAnterior; }
        return null;
        
    }

    public override void Salir(string anterior)
    {
        Debug.Log("Saliendo del Estado Estrella");
    }

}