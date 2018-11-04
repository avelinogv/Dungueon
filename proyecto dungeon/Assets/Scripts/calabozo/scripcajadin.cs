using UnityEngine;
using System.Collections;

public class scripcajadin : MonoBehaviour
{


    public Resume Scripresume;

    // Use this for initialization
    void Start()
    {
        Scripresume = GameObject.Find("Manageguardado").GetComponent<Resume>();
        if (Scripresume.cadinero)
        {
            Debug.Log("comida activada");
            gameObject.SetActive(false);

        }

    }
    void Update()
    {


    }
}