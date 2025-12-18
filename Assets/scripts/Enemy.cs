using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string Name = "Default Unit";
    public int Health = 100;
    public int Level = 1;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI levelText;

    void Update()
    {
        if (nameText != null)
            nameText.text = Name;

        if (healthText != null)
            healthText.text = $"Health: {Health}";

        if (levelText != null)
            levelText.text = $"Level: {Level}";
    }
}