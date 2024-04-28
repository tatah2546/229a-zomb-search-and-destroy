using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    
    public TextMeshProUGUI playerHpText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI zombieKillCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHpText.text = "Health : " + player.Hp;
        scoreText.text = "Score: "+ player.score;
        zombieKillCountText.text = "ZombieKilled : " + player.zombieKillCount + "/15";

        if (player.Hp <= 0)
        {
            Destroy(player.gameObject); //player dead = lose;
        }
        
        if (player.zombieKillCount >= 15)
        {
            Debug.Log("End Game"); //player win end game
            win();
        }
    }

    void win()
    {
        SceneManager.LoadSceneAsync(2);
    }

    void menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    
}
