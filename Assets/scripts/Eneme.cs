using UnityEngine;
using TMPro;

public class Eneme : MonoBehaviour
{
    public TMP_Text Name_text;
    public TMP_Text Health_Text;
    public TMP_Text Level_Text;

    private string _name;
    private int _health;
    private int _level;

    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            Name_text.text = $"ИМЯ: {_name}";
        }
    }

    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Clamp(value, 0, 100);
            Health_Text.text = $"Здоровье :{_health}";
        }
    }

    public int Level
    {
        get { return _level; }
        set
        {
            _level = Mathf.Max(value, 1);
            Level_Text.text = $"Уровень: {_level}";
        }
    }

    private void Awake()
    {
        Name_text = GetComponent<TMP_Text>();
        Health_Text = GetComponent<TMP_Text>();
        Level_Text = GetComponent<TMP_Text>();

        if (Name_text || Health_Text || Level_Text)
            Debug.LogError("Не найдены компоненты");
    }
}
