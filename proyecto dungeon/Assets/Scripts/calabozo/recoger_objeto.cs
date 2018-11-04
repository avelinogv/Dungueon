using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class recoger_objeto : MonoBehaviour {
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
        hoja.texto.text = "Objeto recogido";


    }

    public void OnTriggerExit()
    {
        DestroyObject(gameObject);
        hoja.Desactivo();
        DestroyObject(gameObject);
  

    }

}
