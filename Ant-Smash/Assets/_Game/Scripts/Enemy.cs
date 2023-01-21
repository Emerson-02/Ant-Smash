using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Movement()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }
}
