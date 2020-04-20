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
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
    }

    void Start()
    {
        deaths = GameObject.Find("Deathcount");
        enemiesKilled = GameObject.Find("Killcount");
        bulletsFired = GameObject.Find("Shotcount");

        deaths.GetComponent<TextMeshProUGUI>().text = score_deaths.ToString();
        bulletsFired.GetComponent<TextMeshProUGUI>().text = score_shots.ToString();
        enemiesKilled.GetComponent<TextMeshProUGUI>().text = score_kills.ToString();


    }

    // Update is called once per frame
    void Update()
    {

        //
        //
        //
    }


    public void IncreaseKills()
    {
        score_kills++;
        if (SceneManager.GetActiveScene().name != "Endscreen") return;
        enemiesKilled.GetComponent<TextMeshProUGUI>().text = score_kills.ToString();
    }

    public void IncreaseDeaths()
    {
        score_deaths++;
        if (SceneManager.GetActiveScene().name != "Endscreen") return;
        deaths.GetComponent<TextMeshProUGUI>().text = score_deaths.ToString();
    }

    public void IncreaseShots()
    {
        score_shots++;
        if (SceneManager.GetActiveScene().name != "Endscreen") return;
        bulletsFired.GetComponent<TextMeshProUGUI>().text = score_shots.ToString();
    }

}
