using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class GameController : MonoBehaviour
{
    public int lives = 10;
    //public GameObject[] wave;
    public TMP_Text LivesNum;


    // Start is called before the first frame update
    void Start()
    {
        LivesNum.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //LivesNum.text = lives.ToString();
    }

    public void LoseLife()
    {
        lives--;
        LivesNum.text = lives.ToString();
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
