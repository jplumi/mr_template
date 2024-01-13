using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float spawnSpeed = 2;

    void Start()
    {

    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = transform.forward * spawnSpeed;
        }
    }
}
