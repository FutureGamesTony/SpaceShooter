
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveVertical;
    private float _moveHorizontal;
    //TODO: Change from magic values to data collected from scene and camera
    private float _speed = 15f;
    private float _minX = -10f;
    private float _maxX = 10f;
    private float _minY = -4.5f;
    private float _maxY = 4.5f;

    public GameObject bullet;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        _moveVertical = Input.GetAxis("Vertical");
        _moveHorizontal = Input.GetAxis("Horizontal");
        transform.position = new Vector2(transform.position.x + (_moveHorizontal * _speed * Time.deltaTime), transform.position.y + (_moveVertical * _speed * Time.deltaTime));
        OutOfBounds();
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire4"))
        {
            
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 1), Quaternion.identity);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OutOfBounds()
    {
        if (transform.position.y > _maxY)
            transform.position = new Vector2(transform.position.x, _maxY);
       if (transform.position.y < _minY)
            transform.position = new Vector2(transform.position.x, _minY);
       if (transform.position.x < _minX)
            transform.position = new Vector2(_minX, transform.position.y);
       if (transform.position.x > _maxX)
            transform.position = new Vector2(_maxX, transform.position.y);
    }
}
