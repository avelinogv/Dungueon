using UnityEngine;
using System.Collections;

public class panelcerbe : MonoBehaviour {

    public scripcontrojardin per;
    // Use this for initialization
    void Start()
    {
        per = GameObject.Find("controladorpergaminojar").GetComponent<scripcontrojardin>();
    }

    public void OnTriggerEnter()
    {
        per.activo();
        per.texto.text = "Perro guardian de Hades, Escapo del inframundo quemandolo todo, los mejores arqueros se ocuparon de reducirlo y atraparlo. Ahora pasa sus días encerrado en esta jaula ";


    }

    public void OnTriggerExit()
    {
        per.desactivo();
        //DestroyObject(gameObject);


    }
}