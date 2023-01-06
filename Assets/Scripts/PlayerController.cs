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

    public GameObject WinLoseBG;

    public Text WinLoseText;

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
            WinLoseBG.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            WinLoseText.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
            WinLoseText.text = "You Win!";
            WinLoseBG.SetActive(true);
            StartCoroutine(LoadScene(5));
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
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        
        if (health == 0)
        {
            WinLoseBG.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            WinLoseText.GetComponent<Text>().color = new Color32(255, 255, 255, 255);
            WinLoseText.text = "Game Over!";
            WinLoseBG.SetActive(true);
            StartCoroutine(LoadScene(5));
        }
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("maze");
    }
}
