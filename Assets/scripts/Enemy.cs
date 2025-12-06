using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform parentTransform;

    public int numberOfUnits = 10;

    public InputField InputField;
    public Button filterByHealthButton;
    public Button filterByLevelButton;
    public Button resetButton;
    public Button changeToBossButton;

    private Enemy[] enemies;

    public class Enemy
    {
        public string Name { get => textName.text; set => textName.text = value; }
        public int Health { get => int.Parse(textHealth.text); set => textHealth.text = value.ToString(); }
        public int Level { get => int.Parse(textLevel.text); set => textLevel.text = value.ToString(); }

        public TMP_Text textName;
        public TMP_Text textHealth;
        public TMP_Text textLevel;

        public Enemy(GameObject obj)
        {
            textName = obj.transform.Find("Canvas").Find("Text_Name").GetComponent<TMP_Text>();
            textHealth = obj.transform.Find("Canvas").Find("Text_Health").GetComponent<TMP_Text>();
            textLevel = obj.transform.Find("Canvas").Find("Text_Level").GetComponent<TMP_Text>();

            Name = "Unit";
            Health = Random.Range(10, 100);
            Level = Random.Range(1, 5);
        }
    }

    #region Методы обработки действий
    void Start()
    {
        for (int i = 0; i < numberOfUnits; i++)
        {
            float posX = Random.Range(-10f, 10f);
            GameObject instance = Instantiate(enemyPrefab, new Vector3(posX, 0, 0), Quaternion.identity, parentTransform);
            enemies[i] = new Enemy(instance);
        }

        filterByHealthButton.onClick.AddListener(FilterByHealth);
        filterByLevelButton.onClick.AddListener(FilterByLevel);
        resetButton.onClick.AddListener(ResetAll);
        changeToBossButton.onClick.AddListener(ChangeToBoss);
    }

    void FilterByHealth()
    {
        if (!int.TryParse(InputField.text, out int healthValue)) return;

        foreach (var enemy in enemies)
        {
            bool visible = enemy.Health > healthValue;
            enemy.textName.gameObject.SetActive(visible);
            enemy.textHealth.gameObject.SetActive(visible);
            enemy.textLevel.gameObject.SetActive(visible);
        }
    }

    void FilterByLevel()
    {
        if (!int.TryParse(InputField.text, out int levelValue)) return;

        foreach (var enemy in enemies)
        {
            bool visible = enemy.Level == levelValue;
            enemy.textName.gameObject.SetActive(visible);
            enemy.textHealth.gameObject.SetActive(visible);
            enemy.textLevel.gameObject.SetActive(visible);
        }
    }

    void ResetAll()
    {
        foreach (var enemy in enemies)
        {
            enemy.textName.gameObject.SetActive(true);
            enemy.textHealth.gameObject.SetActive(true);
            enemy.textLevel.gameObject.SetActive(true);
        }
    }

    void ChangeToBoss()
    {
        string nameFilter = InputField.text.Trim();

        foreach (var enemy in enemies)
        {
            if (enemy.Name.Contains(nameFilter))
            {
                enemy.Name = "Boss";
                enemy.Level += 1;
                enemy.Health *= 3;
            }
        }
    }
    #endregion
}