using UnityEngine;
using System.Collections;

public class Siquiente_nivel : MonoBehaviour {

    public Controladorpanel hoja;
    public persocompleto acceso;
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
        hoja.texto.text = "mmmm... Esta barricada parece algo debil , equipate con lo que haga mas daño e intenta romperla pulsando la tecla e";


    }




    public void OnTriggerStay()
    {

        if (Input.GetKey(KeyCode.E)&&acceso.daño>30)
        {

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("destru"))
            {
                Destroy(g);

            }
            Application.LoadLevel("Jardin");

            DestroyObject(gameObject);
            hoja.Desactivo();
      
        }


    }


    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
