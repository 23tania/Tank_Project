using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Defined movement speed of the tank
    public float moveSpeed = 0.2f;

    // Rotation speed of the tank
    public float rotationSpeed = 2.5f;

    // Necessary: using UnityEngine.UI
    public Text minesUIText;
    public Text livesUIText;
    public Text finalUIText;

    int lives = 3;
    int mines = 5;

    Rigidbody rigidbody;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // A movement vector - an instruction on where to move the tank
        // 3 dimensional vector - x,y,z
        Vector3 movement = new Vector3(vertical, 0.0f, 0);
        // Object transformations are done through the "transform" class

        // It will move based on the moveSpeed multiplied
        transform.Translate(movement * moveSpeed);
        // Defining the rotation based on Euler angles
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y 
        + horizontal * rotationSpeed, 0);
    }

    // Check the trigger conditions - when tank collides with the object it disables (disappears)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MedicalPill") || other.gameObject.CompareTag("Ammo"))
        {
            other.gameObject.SetActive(false);

            // To permanently remove elements from the scene:
            Destroy(other.gameObject);
        }

        // Adding and removing health
        if (other.gameObject.CompareTag("MedicalPill"))
        {
            if (lives < 3)
            {
                lives++;
                updateLivesUIText();
            }
        }

        if (other.gameObject.CompareTag("Ammo"))
        {
            mines += 2;
            updateMinesUIText();
        }
    }


    void updateMinesUIText()
    {
        minesUIText.text = "Mines: " + mines.ToString();
    }

    void updateLivesUIText()
    {
        livesUIText.text = "Lives: " + lives.ToString();
    }

    void setFinalUIText(string text)
    {
        finalUIText.text = text;
        finalUIText.gameObject.SetActive(true);
    }

    void removeAllObjects()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject ob in allObjects)
        {
            if ((ob.CompareTag("MedicalPill")) || 
                (ob.CompareTag("Ammo")) || (ob.CompareTag("ATMine")))
            {
                Destroy(ob);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Whenever a collision with a mine happens
        if (collision.gameObject.CompareTag("ATMine"))
        {
            // Lives decrease
            lives--;
            updateLivesUIText();

            rigidbody.AddForce(Random.Range(1.0f, 2.0f) * 1.5f,
                Random.Range(1.5f, 2.5f) * 2.0f,
                Random.Range(1.0f, 2.0f) * 1.5f, ForceMode.Impulse);

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);

            // Game Over
            if (lives <= 0)
            {
                setFinalUIText("Game Over");
                removeAllObjects();

                // Bluring effect
                GameObject.Find("PostProcessing").GetComponent<PostProcessingController>().BlurAtRuntime();
            }
        }
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
