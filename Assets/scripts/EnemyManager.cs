using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform unitsParent;
    public int numUnits = 5;
    private List<Enemy> enemiesList;
    public TMP_InputField inputField;

    void Start()
    {
        GenerateUnits(numUnits);

        enemiesList = FindObjectsOfType<Enemy>().ToList();
    }

    void GenerateUnits(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f)
            );

            GameObject instance = Instantiate(cubePrefab, position, Quaternion.identity, unitsParent);

            Enemy enemy = instance.GetComponent<Enemy>();
            enemy.Name = $"Unit_{i + 1}";
            enemy.Health = Random.Range(80, 150);  
            enemy.Level = Random.Range(1, 5);       
        }
    }

    public void FilterByHealth()
    {
        int filterValue = TryParseInput(inputField.text);
        foreach (var enemy in enemiesList)
        {
            enemy.gameObject.SetActive(enemy.Health > filterValue);
        }
    }

    public void FilterByLevel()
    {
        int filterValue = TryParseInput(inputField.text);
        foreach (var enemy in enemiesList)
        {
            enemy.gameObject.SetActive(enemy.Level == filterValue);
        }
    }

    public void ResetVisibility()
    {
        foreach (var enemy in enemiesList)
        {
            enemy.gameObject.SetActive(true);
        }
    }

    public void ChangeMatchingNames()
    {
        string targetName = inputField.text.Trim().ToLower();
        foreach (var enemy in enemiesList.Where(e => e.Name.ToLower() == targetName))
        {
            enemy.Name = "Boss";         
            enemy.Level++;              
            enemy.Health *= 3;           
        }
    }

    private int TryParseInput(string input)
    {
        return int.TryParse(input, out int parsedInt) ? parsedInt : 0;
    }
}
