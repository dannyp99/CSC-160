using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text healthText;

    public void SetMaxHealth(float health) 
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
        healthText.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
    }
    public void SetHealth(float health) 
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

        healthText.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
    }


}
