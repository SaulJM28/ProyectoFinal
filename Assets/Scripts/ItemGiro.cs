using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiro : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 Rotacion = new Vector3(15, 30, 45);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotacion * Time.deltaTime);
    }
}
