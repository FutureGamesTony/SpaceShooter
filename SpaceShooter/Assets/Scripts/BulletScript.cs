using UnityEngine;
//Just here to destroy the bullet when it is out of bounds.
public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (_speed * Time.deltaTime), transform.position.y);
        
    }
}
