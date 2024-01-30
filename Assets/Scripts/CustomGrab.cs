using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 10f))
        {
            Debug.Log(hitInfo.collider.name);
        }
    }
}
