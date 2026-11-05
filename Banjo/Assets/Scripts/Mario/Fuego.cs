using UnityEngine;

public class Fuego : Estado
  {
    public override void Entrar(string anterior)
   {
      Debug.Log("Mario Fuego");
   }

public override string AlRecibir(string trigger, int valor = 0)
    {
        if (trigger == "estrella") { return "Estrella"; }
        if (trigger == "dano") { return "Grande"; }
        return null;
        
    }

public override void Salir(string anterior)
  {
        Debug.Log("Saliendo del Estado Fuego");
  }

}

