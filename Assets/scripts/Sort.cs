using UnityEngine;

public class Sort : MonoBehaviour
{
    public GameObject[] cubes;

    void Start()
    {
        SortCubes();
    }

    void SortCubes()
    {
        for (int i = 0; i < cubes.Length - 1; i++)
        {
            for (int j = 0; j < cubes.Length - i - 1; j++)
            {
                if (cubes[j].transform.localScale.magnitude < cubes[j + 1].transform.localScale.magnitude)
                {
                    var temp = cubes[j];
                    cubes[j] = cubes[j + 1];
                    cubes[j + 1] = temp;
                }
            }
        }

        float xOffset = 0f;
        foreach (var cube in cubes)
        {
            cube.transform.position = new Vector3(xOffset, 0, 0);
            xOffset += cube.transform.localScale.x + 1f; 
        }
    }
}
