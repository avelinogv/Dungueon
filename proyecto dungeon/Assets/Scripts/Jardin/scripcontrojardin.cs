using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class scripcontrojardin : MonoBehaviour {
    public GameObject Perga;
    public Text texto;
    public GameObject hojainicio;
	// Use this for initialization
	void Start () {
        Perga = GameObject.Find("perjar");
        texto = GameObject.Find("Textoper").GetComponent<Text>();
        Perga.SetActive(false);
        hojainicio= GameObject.Find("introjardin");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activo()
    {
        Perga.SetActive(true);


    }


public void desactivo()
    {
        Perga.SetActive(false);
    }


    public void quitarhoja()
    {
        hojainicio.SetActive(false);

    }

}
