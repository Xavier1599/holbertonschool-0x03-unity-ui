using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    public Rigidbody rb;

    private int score = 0;

    public int health = 5;

    public Text scoreText;

    public Text healthText;

    void SetScoreText()
    {
        score++;
        scoreText.text = "Score: " + score;
        // scoreText.text = $"Score: {this.score}" ;
    }

    void SetHealthText()
    {
        health--;
        healthText.text = "Health: " + health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            // Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
            SetScoreText();
        }

        if (other.tag == "Trap")
        {
            // Debug.Log($"Health: {health}");
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
