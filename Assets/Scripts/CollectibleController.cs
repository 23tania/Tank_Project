using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public GameObject Ammo;
    public GameObject MedicalPill;

    void createCollectible(GameObject collectible)
    {
        // The second value decides the position (how high)
        Vector3 vector = new Vector3(Random.Range(-12.0f, 1.0f),
                                        0.42f,
                                        Random.Range(-12.0f, 1.0f));

        Instantiate(collectible, vector, collectible.transform.rotation, gameObject.transform);
    }

    public void respawnCollectible()
    {
        GameObject collectible;
        Vector3 vector = new Vector3(Random.Range(-12.0f, 1.0f),
                                        0.42f,
                                        Random.Range(-12.0f, 1.0f));

        if (Random.Range(-1.0f, 1.0f) > 0)
        {
            collectible = Ammo;
        }
        else
        {
            collectible = MedicalPill;
        }

        Instantiate(collectible, vector, collectible.transform.rotation, gameObject.transform);
    }

    void respawnAmmo()
    {
        Vector3 vector = new Vector3(Random.Range(-10.0f, 0.0f),
                                        0.42f,
                                        Random.Range(-10.0f, 0.0f));

        Instantiate(Ammo, vector, Ammo.transform.rotation, gameObject.transform);
    }

    void respawnMedicalPill()
    {
        Vector3 vector = new Vector3(Random.Range(-10.0f, 0.0f),
                                        0.42f,
                                        Random.Range(-10.0f, 0.0f));

        Instantiate(MedicalPill, vector, MedicalPill.transform.rotation, gameObject.transform);
    }

    private void Start()
    {
        for (int i=0; i<3; i++)
        {
            createCollectible(Ammo);
            createCollectible(MedicalPill);
        }
    }
}
