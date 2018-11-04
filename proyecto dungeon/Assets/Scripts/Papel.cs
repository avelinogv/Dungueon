using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Papel : MonoBehaviour {
    private Item item;
    private string texto;
    private GameObject papel;

    void Start()
    {
        papel = GameObject.Find("Papel");

        papel.SetActive(false);
    }

    void Update()
    {
        if (papel.activeSelf)
        {
            papel.transform.position= Input.mousePosition;
        }

    }

    public void Activado(Item item)
    {
        this.item = item;
        Escritor();
        papel.SetActive(true);

    }


    public void Desactivado()
    {

        papel.SetActive(false);
    }



    public void Escritor()
    {

        texto = "<color=#0846DBFF><b>" + item.Nombre+"</b></color>\n_____________\n"+item.Descripcion+"\n_____________\nPrecio:"+item.precio
            + "\nDaño: "+item.daño+" Fuerza: "+item.fuerza+"  Vida: "+item.vida+ "  Defensa: "+item.defensa+"  Velocidad:  "+item.velocidad;
        papel.transform.GetChild(0).GetComponent<Text>().text = texto;
    }

}
