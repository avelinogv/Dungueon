using UnityEngine;
using System.Collections;

public class puerta_fuego : MonoBehaviour {

    public Animation animo;
    public Controladorpanel hoja;
    public persocompleto acceso;
    public GameObject fuegote;

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
            hoja.texto.text = "Esta Sala esta ardiendo, consejo vende los guantes, comprate un buen casco y una coraza";
          
            animo.Play("Open");
  
        //gameObject.GetComponent(Animation).Play("Open");

    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();

            animo.Play("Close");
       
        //gameObject.GetComponent(Animation).Play("Close");

    }

}
