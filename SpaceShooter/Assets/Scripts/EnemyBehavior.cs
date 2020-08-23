using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehavior : MonoBehaviour
{
    public float _horizontalSpeed = -3f;
    public float _sineMagnitude = 2f;
    public float _sineFrequency = 1f;

    public float shootingInterval = 0.5f;
    public GameObject enemyBullet;

    [SerializeField]
    public float hp = 16;
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
                Destroy(gameObject, 0.1f);
        }
    }

    Rigidbody2D rb;

    Coroutine shootRoutine;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shootRoutine = StartCoroutine(Shooting());
    }

    // Update is called once per frame
    void Update()
    {
        float yMovement = Mathf.Sin(Mathf.Deg2Rad * 90 * Time.time * _sineFrequency) * _sineMagnitude * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + _horizontalSpeed * Time.deltaTime, transform.position.y + yMovement);

        if (transform.position.x < -20)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                HP = 0;
                other.GetComponent<PlayerLife>().currentHealth -= 1.0f;
                break;
            case "PlayerBullet":
                HP -= 5;
                Destroy(other.gameObject);
                break;
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingInterval);
            if (enemyBullet)
            {
                GameObject bullet = Instantiate(enemyBullet);
                bullet.transform.position = transform.position;
            }
                
        }
    }
}
