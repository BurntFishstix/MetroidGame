using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    void Start()
    {
        
    }

    void Update()
    {
        if (MoveRight)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        else
        {
            transform.position += -transform.right * Time.deltaTime * speed;
        }
    }
}
