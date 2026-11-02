using System.Collections.Generic;
using UnityEngine;

public class Forjando : Estado
{
    public float tiempo;
    public float espera;

    public override void Entrar(string anterior)
    {
        tiempo = 0f;
        espera = 0f;
        List<Refuerzo> orden = Ctx.ObtenerOCrear<List<Refuerzo>>("orden");

        foreach (var r in orden)
        {
            espera += r.duracion;
        }
        Debug.Log("Espera total: " + espera);
    }

    public override string Actualizar(float dt)
    {
        List<Refuerzo> orden = Ctx.ObtenerOCrear<List<Refuerzo>>("orden");
        if (orden.Count == 0)
        {
            return "Fogata";
        }

        tiempo += dt;
        if (tiempo >= espera)
        {
            return "Almas";
        }
        return null;
    }

    public override string AlRecibir(string trigger, int valor)
    {
        List<Refuerzo> orden = Ctx.ObtenerOCrear<List<Refuerzo>>("orden");

        if (trigger == "reforzar")
        {
            Dictionary<int, Arma> catalogo = Ctx.ObtenerOCrear<Dictionary<int, Arma>>("catalogo");

            if (!catalogo.ContainsKey(valor))
            {
                Debug.Log("no existe ese id");
                return null;
            }

            int numero = Ctx.Obtener<int>("consecutivo") + 1;
            Refuerzo r = catalogo[valor].Crear(numero);

            if (r == null)
            {
                Debug.Log("agotado");
                return null;
            }

            orden.Add(r);
            Ctx.Fijar("consecutivo", numero);
            espera += r.duracion;
            return null;
        }

        if (trigger == "cancelar")
        {
            if (orden.Count == 0) return "Fogata";

            espera -= orden[orden.Count - 1].duracion;
            orden.RemoveAt(orden.Count - 1);
            Ctx.Fijar("cancelados", Ctx.Obtener<int>("cancelados") + 1);

            if (orden.Count == 0) return "Fogata";
            return null;
        }

        if (trigger == "invasion")
        {
            return "Invasion";
        }

        return null;
    }
}