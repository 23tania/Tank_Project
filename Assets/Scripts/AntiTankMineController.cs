using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiTankMineController : MonoBehaviour
{
    public GameObject AntiTankMine;
    void createMineRandomly() 
    {
        Vector3 vector = new Vector3(Random.Range(-12.0f, 4.0f),
                                 -1.7f,
                                 Random.Range(-12.0f, 4.0f));

        Instantiate(AntiTankMine, vector, AntiTankMine.transform.rotation, gameObject.transform);
    }

    public void createMine(GameObject tank)
    {
        Vector3 vector = tank.transform.position - tank.transform.right * 1.45f;

        Instantiate(AntiTankMine, new Vector3(vector.x, 0.02f, vector.z),
            AntiTankMine.transform.rotation, gameObject.transform);
    }

    private void Start()
    {
        for (int i = 0; i <= 6; i++)
        {
            createMineRandomly();
        }
    }
}
