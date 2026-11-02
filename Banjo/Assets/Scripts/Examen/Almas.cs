using System.Collections.Generic;
using UnityEngine;

public class Almas : Estado
{
    public int total;

    public override void Entrar(string anterior)
    {
        total = 0;
        List<Refuerzo> orden = Ctx.ObtenerOCrear<List<Refuerzo>>("orden");

        foreach (Refuerzo r in orden)
        {
            total += r.costo;
            Debug.Log(r.Describir());
        }

        Ctx.Fijar("total", total);
        Debug.Log("Total: " + total);
    }

    public override string AlRecibir(string trigger, int valor)
    {
        if (trigger == "pagar")
        {
            if (valor <= 0)
            {
                Debug.Log("pago no valido");
                return null;
            }

            if (valor < total)
            {
                Debug.Log("faltan: " + (total - valor));
                return null;
            }

            Dictionary<string, int> vendidos = Ctx.ObtenerOCrear<Dictionary<string, int>>("vendidos");
            List<Refuerzo> orden = Ctx.ObtenerOCrear<List<Refuerzo>>("orden");

            foreach (Refuerzo r in orden)
            {
                if (!vendidos.ContainsKey(r.nombre))
                {
                    vendidos[r.nombre] = 0;
                }
                vendidos[r.nombre]++;
            }

            int recaudado = Ctx.Obtener<int>("recaudado");
            Ctx.Fijar("recaudado", recaudado + total);

            int atendidos = Ctx.Obtener<int>("atendidos");
            Ctx.Fijar("atendidos", atendidos + orden.Count);

            orden.Clear();
            Debug.Log("cambio = " + (valor - total));

            return "Fogata";
        }

        if (trigger == "invasion")
        {
            return "Invasion";
        }

        return null;
    }
}