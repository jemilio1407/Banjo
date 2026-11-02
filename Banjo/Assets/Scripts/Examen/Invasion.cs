using UnityEngine;

public class Invasion : Estado
{
    private string estadoPrevio;
    private float tiempo;

    public override void Entrar(string anterior)
    {
        estadoPrevio = anterior;
        tiempo = 0f;

        int incidentes = Ctx.Obtener<int>("incidentes");
        Ctx.Fijar("incidentes", incidentes + 1);

        Debug.Log("Otro jugador invade la fogata");
    }

    public override string Actualizar(float dt)
    {
        tiempo += dt;

        if (tiempo >= 4f)
        {
            return estadoPrevio;
        }

        return null;
    }

    public override string AlRecibir(string trigger, int valor)
    {
        Debug.Log("Evento ignorado");
        return null;
    }

    public override void Salir(string siguiente)
    {
        Debug.Log("El incidente se resolvio");
    }
}