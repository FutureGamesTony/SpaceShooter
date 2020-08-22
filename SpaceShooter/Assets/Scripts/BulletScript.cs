using UnityEngine;
//Just here to destroy the bullet when it is out of bounds.
public class BulletScript : MonoBehaviour
{
    private float _speed = 20f;
    private float _bounds = 20f;
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (_speed * Time.deltaTime), transform.position.y);
        if (transform.position.x > _bounds)
            Destroy(gameObject);
        
    }
}
