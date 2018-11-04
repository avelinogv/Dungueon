using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controlador_hoja_menusito : MonoBehaviour {
    public Animator animo;
    public Text texto;
    public GameObject papel;
    // Use this for initialization
    void Start () {
        texto = GameObject.Find("Texto_menu").GetComponent<Text>();
        papel = GameObject.Find("Panel_menu");
        papel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}



    public void Activo()
    {
        papel.SetActive(true);
        
    }

    public void Desactivo()
    {
        papel.SetActive(false);

    }




}
