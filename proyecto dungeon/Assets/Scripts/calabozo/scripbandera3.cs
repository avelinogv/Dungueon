using UnityEngine;
using System.Collections;

public class scripbandera3 : MonoBehaviour {


    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Blason de la casa Merk";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
