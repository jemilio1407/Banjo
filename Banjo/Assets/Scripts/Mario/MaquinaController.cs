using System.Collections.Generic;
using UnityEngine;

public class MaquinaController : MonoBehaviour
{

    private Contexto ctx;
    private List<Estado> lista;

    private Maquina maquina;
    private string ultimo = "";


    void Start()
    {
        Debug.Log("Teclas : H hongo | F flor | S estrella | D dano | V vacio | R reiniciar");

        ctx = new Contexto();
        lista = new List<Estado>();

        lista.Add(new Pequeno());
        lista.Add(new Grande());
        lista.Add(new Fuego());
        lista.Add(new Estrella());
        lista.Add(new Muerto());


        maquina = new Maquina(lista, ctx);
        maquina.Iniciar("Pequeno");

    }



    void Update()
    {

        if (maquina == null || maquina.Actual == null)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.H)) maquina.Disparar("hongo");
        if (Input.GetKeyDown(KeyCode.F)) maquina.Disparar("flor");
        if (Input.GetKeyDown(KeyCode.S)) maquina.Disparar("estrella");
        if (Input.GetKeyDown(KeyCode.D)) maquina.Disparar("dano");

        if (Input.GetKeyDown(KeyCode.V) && maquina.Actual.Nombre != "Muerto")
        {
            Debug.Log("Mario Vacio");
            maquina.CambiarA("Muerto");
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            maquina.Ctx.Limpiar();
            maquina.CambiarA("Pequeno");
        }



        maquina.Actualizar(Time.deltaTime);

        if (maquina.Actual.Nombre != ultimo)
        {
            ultimo = maquina.Actual.Nombre;
            Debug.Log("Estado actual: " + ultimo);

        }

        
    }


}


