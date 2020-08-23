using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackMove : MonoBehaviour
{
    public float _speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
    }
}
