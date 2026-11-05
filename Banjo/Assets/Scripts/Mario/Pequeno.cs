using UnityEngine;

public class Pequeno : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("Mario Pequeno ");
    }

    public override string AlRecibir(string trigger, int valor = 0)
    {
        if (trigger == "hongo") { return "Grande"; }
        if (trigger == "flor") { return "Fuego"; }
        if (trigger == "estrella") { return "Estrella"; }
        if (trigger == "dano") { return "Muerto"; }

        return null;
    }

    public override void Salir(string anterior)
    {
        Debug.Log("Saliendo de Pequeno");
    }

}
