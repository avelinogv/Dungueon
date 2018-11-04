using UnityEngine;
using System.Collections;

public class scripcajaco : MonoBehaviour
{
    public Resume Scripresume;

    // Use this for initialization
    void Start()
    {
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        if (Scripresume!=null &&Scripresume.cacomida)
        {
            Debug.Log("comida activada");
            gameObject.SetActive(false);

        }
      
    }
    void Update()
    {


    }
}