using UnityEngine;
using UnityEngine.UI;

public class PointsBar: MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Text pointText;

    public void InitPoints(float points)
    {
        slider.maxValue = points;
        slider.value = points;

        fill.color = gradient.Evaluate(1f);
        pointText.text = slider.value.ToString();
    }
    public void AddPoints()
    {
        slider.maxValue = EnemyGenerator.Points;
        slider.value = EnemyGenerator.Points;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        pointText.text = slider.value.ToString();
    }
    public void SetPoints(float points)
    {
        slider.value = points;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        pointText.text = slider.value.ToString();
    }
}
