using UnityEngine;

public class Muerto : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("Mario Muerto ");
    }

    public override string AlRecibir(string trigger, int valor = 0)
    {
       
        return null;
        
    }

    public override void Salir(string anterior)
    {
        Debug.Log("Mario Dead?");
    }

}

