using UnityEngine;
using System.Collections;

public class caja : MonoBehaviour {
    public persocompleto acceso;
    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        acceso = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }

    // Update is called once per frame
    void Update()
    {

  

    }


    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Usa el boton e para romper";


    }



    public void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            hoja.Desactivo();
            DestroyObject(gameObject);
           

        }

    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
