using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FogataController : MonoBehaviour
{
    private Maquina maquina;
    private Contexto ctx;
    private string ultimoEstado;

    void Start()
    {
        Debug.Log("Teclas: 1/2/3/4, P/L/Z, C, I, X, R");

        ctx = new Contexto();
        CargarCatalogo();

        List<Estado> estados = new List<Estado>();
        estados.Add(new Fogata());
        estados.Add(new Forjando());
        estados.Add(new Almas());
        estados.Add(new Invasion());
        estados.Add(new Cierre());

        maquina = new Maquina(estados, ctx);
        maquina.Iniciar("Fogata");
        ultimoEstado = "";
    }

    void Update()
    {
        if (Keyboard.current == null || maquina == null || maquina.Actual == null)
        {
            return;
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame) maquina.Disparar("reforzar", 1);
        if (Keyboard.current.digit2Key.wasPressedThisFrame) maquina.Disparar("reforzar", 2);
        if (Keyboard.current.digit3Key.wasPressedThisFrame) maquina.Disparar("reforzar", 3);
        if (Keyboard.current.digit4Key.wasPressedThisFrame) maquina.Disparar("reforzar", 4);

        if (Keyboard.current.pKey.wasPressedThisFrame) maquina.Disparar("pagar", 20000);
        if (Keyboard.current.lKey.wasPressedThisFrame) maquina.Disparar("pagar", 100);
        if (Keyboard.current.zKey.wasPressedThisFrame) maquina.Disparar("pagar", 0);

        if (Keyboard.current.cKey.wasPressedThisFrame) maquina.Disparar("cancelar", 0);
        if (Keyboard.current.iKey.wasPressedThisFrame) maquina.Disparar("invasion", 0);
        if (Keyboard.current.xKey.wasPressedThisFrame) maquina.Disparar("cerrar", 0);

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            maquina.Ctx.Limpiar();
            CargarCatalogo();
            maquina.CambiarA("Fogata");
        }

        maquina.Actualizar(Time.deltaTime);

        if (maquina.Actual.Nombre != ultimoEstado)
        {
            Debug.Log("Estado actual: " + maquina.Actual.Nombre);
            ultimoEstado = maquina.Actual.Nombre;
        }
    }

    private void CargarCatalogo()
    {
        Dictionary<int, Arma> catalogo = ctx.ObtenerOCrear<Dictionary<int, Arma>>("catalogo");
        catalogo.Clear();

        catalogo.Add(1, new Arma("Daga", 800, 6f, 1));
        catalogo.Add(2, new Arma("Espada", 1500, 10f, 3));
        catalogo.Add(3, new Arma("Escudo", 1000, 8f, 2));
    }
}