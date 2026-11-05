using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;


public class Maquina 
{
    public string trigger;
    public string destino;
    public string anterior;

    public Dictionary<string, Estado> estados = new Dictionary<string, Estado>();


    public Contexto Ctx { get; set; }
    public Estado Actual { get; set; }


    public Maquina(List<Estado> lista, Contexto ctx)
    {
        Ctx = ctx;

        foreach (var estado in lista)
        {
            estado.Ctx = ctx;
            estados[estado.Nombre] = estado;
        }
    }


    public void Iniciar(string nombreIncial)
    {
        CambiarA(nombreIncial);
    }

    public void CambiarA(string nombre)
    {
        if (!estados.ContainsKey(nombre))
        {
            Debug.Log("No hay un estado en esa lista con ese nombre :" + nombre);
            return;
        }
        string nombreAnterior = null;

        if (Actual != null)
        {
            nombreAnterior = Actual.Nombre;
            Actual.Salir(nombre);
        }

        Actual = estados[nombre];
        Actual.Entrar(nombreAnterior);

    }

    public void Disparar(string trigger , int valor = 0 )
    {
        if (Actual == null) return;

        string destino = Actual.AlRecibir(trigger, valor);
        {
            if (destino != null)
            {
                CambiarA(destino);
            }
        }
    }

    public void Actualizar(float dt)
    {
        if (Actual == null) return;

        string destino = Actual.Actualizar(dt);
        {
            if (destino != null)
            {
                CambiarA(destino);
            }
        }
    }

}
