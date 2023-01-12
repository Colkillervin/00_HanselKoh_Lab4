using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
    public Text ScoreText;
    int score = 0;
    private int totalfood = 10;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        if (score == totalfood)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Healthy")
        {
            score += 1;
            ScoreText.text = "Healthy Food Collected: " + score.ToString();
        }

        if (collision.gameObject.tag == "Unhealthy")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
