using UnityEngine;
using System.Collections;

public class scripborracha : MonoBehaviour {


    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }



    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Vaya parece que la gemela en vez de vigilar estubo bebiendo con el monje";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
