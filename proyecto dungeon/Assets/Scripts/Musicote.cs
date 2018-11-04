using UnityEngine;
using System.Collections;

public class Musicote : MonoBehaviour {

    public AudioSource altavoz;
        public float volumen=0.3f;
    // Use this for initialization
    void Awake()
    {




        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        

    }
    // Update is called once per frame
    void Update () {
        altavoz.volume = volumen;
    }
}
