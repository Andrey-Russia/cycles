using UnityEngine;

public class ballchanger : MonoBehaviour
{
    public float speedThreshold = 1f;
    public Color slowColor = Color.red;
    public Color normalColor = Color.white;

    private Rigidbody rb;
    private Renderer rend;
    private bool isSlowedDown = false;
    private float timeBelowThreshold = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        CheckSpeed();
    }

    void CheckSpeed()
    {
        float speed = rb.linearVelocity.magnitude;

        if (speed < speedThreshold)
        {
            if (!isSlowedDown)
            {
                isSlowedDown = true;
                ChangeColor(slowColor);
            }
            timeBelowThreshold += Time.deltaTime;
        }
        else
        {
            if (isSlowedDown)
            {
                isSlowedDown = false;
                ChangeColor(normalColor);
                Debug.Log($"Время низкой скорости: {timeBelowThreshold.ToString("F2")} сек.");
                timeBelowThreshold = 0f;
            }
        }
    }

    void ChangeColor(Color color)
    {
        rend.material.color = color;
    }
}
