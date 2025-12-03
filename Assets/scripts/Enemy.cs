using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Prefab;

    private List<string> nameList = new List<string>()
    {
         "Огненный элементал", "Ледяной голем", "Темный маг", "Каменный страж", "Призрачный охотник"
    };

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemyInstance = Instantiate(Prefab, transform.position + Random.insideUnitSphere * 5f, Quaternion.identity);

        Enemy enemyScript = enemyInstance.GetComponent<Enemy>();
        enemyScript.enemyName = namesList[Random.Range(0, namesList.Count)];
        enemyScript.healthPoints = Random.Range(10f, 100f); // Здоровье от 10 до 100
        enemyScript.level = Random.Range(1, 6); // Уровень от 1 до 5

        // Обновляем UI текстовые поля
        enemyScript.nameText.text = "Имя: " + enemyScript.enemyName;
        enemyScript.levelText.text = "Уровень: " + enemyScript.level.ToString();
        enemyScript.healthText.text = "Здоровье: " + Mathf.RoundToInt(enemyScript.healthPoints).ToString(); // Округляем здоровье до целого числа
    }
}