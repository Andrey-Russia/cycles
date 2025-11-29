using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName = "Безымянный монстр";

    public int level = 1;

    public float healthPoints = 100f;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        if (nameText != null && levelText != null && healthText != null)
        {
            nameText.text = "Имя: " + enemyName;
            levelText.text = "Уровень: " + level.ToString();
            healthText.text = "Здоровье: " + healthPoints.ToString("F0");
        }
    }
}