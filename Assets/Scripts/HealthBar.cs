using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // The health bar slider
    public Slider slider; 

    public void setHealth(float healthPercentage)
    {
        // sets the health bar to a value between 0 and 1
        slider.value = healthPercentage;
    }
}
