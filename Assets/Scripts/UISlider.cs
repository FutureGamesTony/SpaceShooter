using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{


    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateSlider(float health)
    {
        
       slider.value = health;

    }
}
