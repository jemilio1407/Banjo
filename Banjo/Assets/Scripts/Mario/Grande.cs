using UnityEngine;

public class Grande : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("Mario Grande ");
    }

    public override string AlRecibir(string trigger, int valor = 0)
    {
        if (trigger == "flor") { return "Fuego"; }
        if (trigger == "estrella") { return "Estrella"; }
        if (trigger == "dano") { return "Pequeno"; }

        return null;
    }

    public override void Salir(string anterior)
    {
        Debug.Log("Saliendo del Estado Grande");
    }

}

