using UnityEngine;
using System.Collections;

public class panelescorpio : MonoBehaviour {

    public scripcontrojardin per;
    // Use this for initialization
    void Start()
    {
        per = GameObject.Find("controladorpergaminojar").GetComponent<scripcontrojardin>();
    }

    public void OnTriggerEnter()
    {
        per.activo();
        per.texto.text = "El autentico Rey de los escorpiones, encontrador en el desierto, el rey de la mezquita pago una fuerte recompensa para desterrarlo de sus tierras,Ahora pasa sus días encerrado en esta jaula ";


    }

    public void OnTriggerExit()
    {
        per.desactivo();
        //DestroyObject(gameObject);


    }
}