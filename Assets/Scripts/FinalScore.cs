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

        var scoreString = $"Depth: {depth:n0}\n\nx\n\nHeat: {modifier:n2}\n({heat:n0} degrees)\n\n=\n\nScore: {score:n0}";

        _text.text = scoreString;
    }
}
