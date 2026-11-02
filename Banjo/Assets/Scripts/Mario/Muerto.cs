using UnityEngine;

public class Muerto : Estado
{
    public override void Entrar(string anterior)
    {
        Debug.Log("Mario ha muerto...");
    }

    public override void Salir(string siguiente)
    {
        Debug.Log("Mario ha revivido");
    }

    public override string AlRecibir(string trigger, int valor)
    {
        return null;
    }
}