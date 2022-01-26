using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    private float Score;
    public Text ScoreText;


    private float timer = 30;
    int timeRemaining;
    public Text timerText;

    // Particles //
    public GameObject CoinParticle;
    public GameObject SpawnPoint;
     
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timer % 30);
        timerText.text = "Timer: " + timeRemaining.ToString();

        if (Score >= 60)
        {
            if(timer <= 30)
            {
                SceneManager.LoadScene("GameWin");
            }          
        }
        else if (timer <= 0)
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Instantiate(CoinParticle, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            Score += 10;
            ScoreText.text = "Score: " + Score.ToString();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLose");
        }
    }

}
