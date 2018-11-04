using UnityEngine;
using System.Collections;

public class anterior : MonoBehaviour {

    public Resume resu;
    private InventarioManager scripInven;
    private InventarioEquipado scripEquipo;
    void Start()
    {
        scripInven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
        resu = GameObject.Find("Manageguardado").GetComponent<Resume>();
        scripEquipo = GameObject.Find("Personaje").GetComponent<InventarioEquipado>();

    }


    public void Anterior()
    {
        for (int i = 0; i < scripInven.itemlist.Count; i++)
        {
            if (scripInven.itemlist[i].identificador != -1)
            {
                resu.listainventario.Add(scripInven.itemlist[i]);
            }
        }



        for (int i = 0; i < scripEquipo.itemlist.Count; i++)
        {
            if (scripEquipo.itemlist[i].identificador != -1)
            {
             
                resu.listaequipo.Add(scripEquipo.itemlist[i]);
            }
        }

        resu.daño = scripEquipo.cuentodaño;
        resu.defensa     = scripEquipo.cuentodefensa;
        resu.vida = scripEquipo.cuentovida;
        resu.fuerza = scripEquipo.cuentofuerza;
        resu.velocidad = scripEquipo.cuentovelocidad;
  
        Application.LoadLevel("Juego");
      
    }

}
