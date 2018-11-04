using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ControladorBola : MonoBehaviour {
    
    Material orbe;

    public persocompleto scrippers;
    // Use this for initialization
    void Start()
    {
        scrippers = GameObject.Find("PersonajeJuego").GetComponent<persocompleto>();
        orbe = this.GetComponent<Image>().material;
       

    }

    // Update is called once per frame
    void Update()
    {
        
        orbe.SetFloat("_Value", scrippers.contadorvida/ scrippers.vidacompleta);

    }

  
}
