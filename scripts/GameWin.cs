using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameWin : MonoBehaviour
{
    public GameObject victory, ui, player, music;
    public TextMeshProUGUI text;

    public void EndGame()
    {
        music.SetActive(false);
        victory.SetActive(true); // enable
        ui.SetActive(false); // disable
        player.SetActive(false); // disable
        if (PlayerHealth.kills == 1)
            text.SetText(PlayerHealth.kills.ToString() + " kill");
        else
            text.SetText(PlayerHealth.kills.ToString() + " kills");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
        victory.SetActive(false);
        ui.SetActive(true);
        player.SetActive(true);

        WaveSpawner.saveWave = 0; // reset wave
        PlayerHealth.kills = 0; // reset kill count
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
