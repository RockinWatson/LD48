using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    private Text _text = null;

    private void Awake()
    {
        _text = this.GetComponent<Text>();
    }

    private void Start()
    {
        var depth = GlobalManager.Get().GetPizzaDepth();
        var heat = GlobalManager.Get().GetPizzaHeat();

        var modifier = heat / 200f;

        var score = depth * modifier;

        var scoreString = $"Score: {score}\n\nDepth: {depth}\n\nHeat: {heat}";

        _text.text = scoreString;
    }
}
