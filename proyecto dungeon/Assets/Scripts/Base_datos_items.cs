using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class Base_datos_items
{
    public List<Item> lista = new List<Item>();
    private Item objeto;


    public Base_datos_items() {

        objeto = new Item("Espadon", "Espada que mata nada mas mirarla",200,20,10,0,0,0, 0);
        objeto.Imagen = Resources.Load<Sprite>("Sprites/Espada");
        lista.Add(objeto);

        objeto = new Item("Casco del dragon", "Casco que cayendote una roca no pasa nada",500,0,0,15,0,10,2);
        objeto.Imagen = Resources.Load<Sprite>("Sprites/casco");
        lista.Add(objeto);


        objeto = new Item("Armadura diamante", "Armadura diamante resistente ante cualquier flecha",200,0,0,20,0,30,3);
        objeto.Imagen = Resources.Load<Sprite>("Sprites/Armadura");
        lista.Add(objeto);

        objeto = new Item("Guantelete que te mete", "Da ostias como panes",800,10,15,0,0,0,4);
        objeto.Imagen = Resources.Load<Sprite>("Sprites/guantes");
        lista.Add(objeto);

        objeto = new Item("Botas de Vulcano", "Robadas del dios , provocan fuego por donde pisan ",600,0,0,0,20,10,5);
        objeto.Imagen = Resources.Load<Sprite>("Sprites/botas");
        lista.Add(objeto);

    }



    public Item Consigue(int id)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].identificador == id)
            {
                return lista[i];
                
            }


        }
        return null;
        
    }





}



