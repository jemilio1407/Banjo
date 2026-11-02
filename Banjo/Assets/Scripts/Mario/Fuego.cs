using UnityEngine;

public class Fuego : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("Flor Fuego");
    }

    public override string AlRecibir(string trigger, int valor)
    {
        if (trigger == "daño") 
        { 
            return "pequeño"; 
        }
        else 
        { 
            return null; 
        }
    }
}
