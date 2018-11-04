using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Rota : MonoBehaviour {
    public Transform Person;
    public Slider Barrita;
    public Quaternion rotation = Quaternion.identity;
    void Update()
    {
        //Person.transform.eulerAngles = new Vector3(0, Barrita.value, 0);

        Person.transform.rotation = Quaternion.AngleAxis(Barrita.value,Vector3.up);
    }



}
