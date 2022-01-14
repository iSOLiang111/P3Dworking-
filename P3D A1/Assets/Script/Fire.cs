using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private int speed;

    public Rigidbody theBullet;
    public Transform theMuzzle;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Debug.Log(Ball throw!);

            Rigidbody bulletClone;

            bulletClone = (Rigidbody)Instantiate(theBullet, theMuzzle.position, theMuzzle.rotation);
            bulletClone.velocity = transform.TransformDirection(Vector3.forward * speed);

        }
    }
}