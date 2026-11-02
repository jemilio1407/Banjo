using System.Collections.Generic;
using UnityEngine;

public class Fogata : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("No hay trabajo en curso");
    }

    public override string AlRecibir(string trigger, int valor)
    {
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

            List<Refuerzo> orden = Ctx.ObtenerOCrear<List<Refuerzo>>("orden");
            orden.Add(r);
            Ctx.Fijar("consecutivo", numero);

            return "Forjando";
        }

        if (trigger == "cerrar")
        {
            int atendidos = Ctx.Obtener<int>("atendidos");
            if (atendidos == 0)
            {
                Debug.Log("Aun no se atiende ningun pedido");
                return null;
            }

            return "Cierre";
        }

        return null;
    }
}