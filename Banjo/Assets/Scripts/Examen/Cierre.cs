using System.Collections.Generic;
using UnityEngine;

public class Cierre : Estado
{
    public override void Entrar(string anterior)
    {
        Dictionary<string, int> vendidos = Ctx.ObtenerOCrear<Dictionary<string, int>>("vendidos");

        Debug.Log("cierre");
        foreach (KeyValuePair<string, int> venta in vendidos)
        {
            Debug.Log(venta.Key + ": " + venta.Value);
        }

        Debug.Log("Atendidos: " + Ctx.Obtener<int>("atendidos"));
        Debug.Log("Recaudado: " + Ctx.Obtener<int>("recaudado"));
        Debug.Log("Cancelados: " + Ctx.Obtener<int>("cancelados"));
        Debug.Log("Incidentes: " + Ctx.Obtener<int>("incidentes"));
    }
}