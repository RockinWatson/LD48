using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthBar : MonoBehaviour
{
    [SerializeField] private Image _image = null;

    private void Update()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        var temperatureScale = Player.Get().GetDepthScale();
        var localScale = _image.transform.localScale;
        localScale.y = temperatureScale;
        _image.transform.localScale = localScale;
    }
}
