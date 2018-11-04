using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Controladorpanel : MonoBehaviour {
    public GameObject hoja;
    public Animation animo;
    public Text texto;
    // Use this for initialization
    void Start () {
        texto = GameObject.Find("Textoin").GetComponent<Text>();
        
        hoja = GameObject.Find("hoja");
        hoja.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activo()
    {
        hoja.SetActive(true);
    }


    public void Desactivo()
    {
        hoja.SetActive(false);
    }


}
