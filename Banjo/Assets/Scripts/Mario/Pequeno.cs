using UnityEngine;

public class Pequeno : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("Mario es pequeño");
    }

    public override void Salir(string siguiente)
    {
        Debug.Log("Mario dejó de ser pequeño");
    }

    public override string AlRecibir(string trigger, int valor)
    {
        if (trigger == "hongo")
        {
            return "Grande";
        }

        if (trigger == "flor")
        {
            return "Fuego";
        }

        if (trigger == "estrella")
        {
            return "Estrella";
        }

        if (trigger == "dano")
        {
            return "Muerto";
        }

        return null;
    }
}