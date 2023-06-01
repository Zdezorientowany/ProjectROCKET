using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        int decimalPlaces = 2;
        float score = Mathf.Round(Time.time * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces); //Rounded time to 2 decimal places with power of math
        scoreText.text = score+"s";
    }

}

