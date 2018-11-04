using UnityEngine;
using System.Collections;

public class scriplibros : MonoBehaviour {


    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }



    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Varios libros (el arte de la lucha , Maneja tu espada, Dispara el arco con precision)";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
