using UnityEngine;
using System.Collections;

public class item_recogido : MonoBehaviour
{
    public Controladorpanel hoja;
    public Resume Scripresume;
    public Item objeto;
    public Objetivo scripob;

    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        objeto = new Item();
        scripob = GameObject.Find("Camera_mapa").GetComponent<Objetivo>();
}

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter()
    {
        hoja.activo();
        scripob.primerito = false;
        hoja.texto.text = "Guantes recogidos, equipalos para tener mas fuerza";
        Scripresume.primerapuerta = true;
        scripob.primerito = false;
        objeto.identificador = 4;
        Scripresume.listainventario.Add(objeto);

    }

    public void OnTriggerExit()
    {

        Scripresume.segundo_objet = true;
        hoja.Desactivo();
        DestroyObject(gameObject);


    }

}