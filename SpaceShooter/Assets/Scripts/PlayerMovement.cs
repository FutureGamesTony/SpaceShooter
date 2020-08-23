using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveVertical;
    private float _moveHorizontal;
    
    private float _speed = 15f;

    private Bounds bounds;

    //Basically 16:9, only when multiplied by orthographicSize it will become
    //the original coordinates of the level.
    Vector2 resolutionReference = new Vector2(3.2f, 1.8f);

    public GameObject bullet;

    Camera mainCamera;
    Canvas canvas;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        bounds = new Bounds(mainCamera.transform.position, resolutionReference * mainCamera.orthographicSize);
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
        if (!bounds.Contains(transform.position))
        {
            Vector3 boundPosition = bounds.ClosestPoint(transform.position);
            transform.position = new Vector2(boundPosition.x, boundPosition.y);
        }
    }
}
