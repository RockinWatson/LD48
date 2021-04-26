using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureBar : MonoBehaviour
{
    [SerializeField] private Image _image = null;

    private void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        var temperatureScale = Player.Get().GetTemperatureScale();
        var localScale = _image.transform.localScale;
        localScale.y = temperatureScale;
        _image.transform.localScale = localScale;
    }
}
