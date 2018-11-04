using UnityEngine;
using System.Collections;

public class cartelarcos : MonoBehaviour {


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
        hoja.texto.text = "Arcos de los guerreros , precisos y potentes";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
