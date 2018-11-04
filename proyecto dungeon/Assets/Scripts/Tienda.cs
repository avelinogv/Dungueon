using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tienda : MonoBehaviour {

    public GameObject panel;
    public GameObject simboloprohi;

    public Text textodinero;
    public InventarioManager inven;
    public Resume Scripresume;
    // Use this for initialization
    void Start () {
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        inven = GameObject.Find("Inventariomanager").GetComponent<InventarioManager>();
        panel = GameObject.Find("Paneltienda");
        simboloprohi = GameObject.Find("simprohibido");
        simboloprohi.SetActive(false);
        panel.SetActive(false);
       textodinero = GameObject.Find("Textobanco").GetComponent<Text>();
        
      
    }
	


    public void activopanel()
    {
        panel.SetActive(true);
    }


    public void desactivopanel()
    {
        panel.SetActive(false);
        simboloprohi.SetActive(false);
    }

    public void comproespada()
    {
        if (Scripresume.dinero >= 200)
        {
            inven.Itempantalla(0);
            Scripresume.dinero -= 200;
        }
        else simboloprohi.SetActive(true);
    }

    public void comproarmor()
    {
        if (Scripresume.dinero >= 200)
        {
            inven.Itempantalla(3);
            Scripresume.dinero -= 200;
        }
        else simboloprohi.SetActive(true);

    }

    public void comprocasco()
    {
        if (Scripresume.dinero >= 500)
        {
            inven.Itempantalla(2);
            Scripresume.dinero -= 500;
        }
        else simboloprohi.SetActive(true);

    }

    public void comproguantes()
    {
        if (Scripresume.dinero >= 800)
        {
            inven.Itempantalla(4);
            Scripresume.dinero -= 800;
        }
        else simboloprohi.SetActive(true);

    }

    public void comprobotas()
    {
        if (Scripresume.dinero >= 600)
        {
            inven.Itempantalla(5);
            Scripresume.dinero -= 600;
        }
        else simboloprohi.SetActive(true);

    }

    public void desactivoprohi()
    {
         simboloprohi.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        
        textodinero.text = Scripresume.dinero.ToString();
    }
}
