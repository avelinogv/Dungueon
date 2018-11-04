using UnityEngine;
using System.Collections;

public class hacha_cartel : MonoBehaviour {


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
        hoja.texto.text = "Hachas muy afiladas, ten cuidado que no se te caiga al pie";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
