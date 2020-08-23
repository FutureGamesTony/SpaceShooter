using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private static float _maxHealth = 10.0f;
    public float currentHealth = _maxHealth;
    private CapsuleCollider2D _cc;
    private string _enemyTag = "Enemy";
    private string _bulletTag = "Bullet";
    private string _healthTag = "HealthPack";
    public UISlider HealthUI;

    private void Update()
    {
        if (currentHealth < 0)
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == _bulletTag)
        {
            currentHealth -= 1.0f;
            Destroy(other.gameObject);
        }

        if (other.tag == _healthTag)
        {
            if(currentHealth < 10)
                currentHealth += 1.0f;
            
            Destroy(other.gameObject);
        }
        HealthUI.UpdateSlider(currentHealth);

    }
}
