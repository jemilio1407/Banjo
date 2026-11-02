using System.Collections.Generic;
using UnityEngine;

public class Maquina
{
    public string anterior;
    public string trigger;
    public string destino;
    public Contexto Ctx { get; set; }
    public Estado Actual { get; set; }
    public Dictionary<string, Estado> estados;    

    public Maquina(List<Estado> lista, Contexto ctx)
    {
        Ctx = ctx;
        foreach (var estado in lista)
        {
            estados[estado.Nombre] = estado;
        }
    }

    public void Iniciar(string nombre)
    {
         CambiarA(nombre);
    }

    public string CambiarA(string nombre)
    {
        if (!estados.ContainsKey(nombre))
        {
            Debug.Log("No hay estado en la lista con ese nombre");

            return nombre;
        }
            
       string anterior = null;

        if (Actual != null)
        {
            Actual.Salir(nombre);
        }
    }

    public void Actualizar(float dt)
    {
        if (Actual == null)
        {
            return;
        }

        destino = Actual.Actualizar(dt);

        if (destino != null && destino != Actual.Nombre)
        {
            CambiarA(destino);
        }
    }

    public void Disparar(string trigger, int valor = 0)
    {
        if (Actual == null)
        {
            return;
        }

        this.trigger = trigger;
        destino = Actual.AlRecibir( trigger,  valor);

        if (destino != null && destino != Actual.Nombre)
        {
            CambiarA(destino);
        }
    }
}
