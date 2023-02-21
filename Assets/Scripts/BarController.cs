using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    private Slider slider;
    public Gradient gradient;
    public Image fill_image;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        fill_image.color = gradient.Evaluate(1f);

        SetMaxValue(100f);
        slider.value = slider.maxValue;

        gameObject.SetActive(false);
    }

    public void SetMaxValue(float max) {
        slider.maxValue = max;
    }

    public void UpdateBarValue(float value) {
        slider.value = value;
        fill_image.color = gradient.Evaluate(slider.normalizedValue);
    }
}
