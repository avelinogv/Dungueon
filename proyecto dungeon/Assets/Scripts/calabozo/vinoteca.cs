using UnityEngine;
using System.Collections;

public class vinoteca : MonoBehaviour {


    public Controladorpanel hoja;
    // Use this for initialization
    void Start()
    {
        hoja = GameObject.Find("Controladorhoja").GetComponent<Controladorpanel>();
    }



    public void OnTriggerEnter()
    {
        hoja.activo();
        hoja.texto.text = "Todo buen guerrero necesita bebida para potenciar su valentia o estupidez";


    }

    public void OnTriggerExit()
    {
        hoja.Desactivo();
        //DestroyObject(gameObject);


    }


}
