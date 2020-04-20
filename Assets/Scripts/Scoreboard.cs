using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bulletsFired;
    GameObject enemiesKilled;
    GameObject deaths;

    private int score_deaths;
    private int score_shots;
    private int score_kills;

    public static Scoreboard scoreboard_instance;
    private void Awake()
    {
        if (scoreboard_instance == null)
        {
            scoreboard_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name != "Endscreen") return;

        deaths = GameObject.Find("Deathcount");
        enemiesKilled = GameObject.Find("Killcount");
        bulletsFired = GameObject.Find("Shotcount");


        enemiesKilled.GetComponent<TextMeshProUGUI>().text = score_kills.ToString();
        deaths.GetComponent<TextMeshProUGUI>().text = score_deaths.ToString();
        bulletsFired.GetComponent<TextMeshProUGUI>().text = score_shots.ToString();

    }

    public void IncreaseKills()
    {
        score_kills++;
    }

    public void IncreaseDeaths()
    {
        score_deaths++;
    }

    public void IncreaseShots()
    {
        score_shots++;
    }

}
