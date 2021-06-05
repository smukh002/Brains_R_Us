using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameFail : MonoBehaviour
{
    public GameObject gameOver, ui, player, music;
    public TextMeshProUGUI text;

    public void EndGame()
    {
        music.SetActive(false);
        gameOver.SetActive(true); // enable
        ui.SetActive(false); // disable
        //player.SetActive(false); // disable
        if (PlayerHealth.kills == 1)
            text.SetText(PlayerHealth.kills.ToString() + " kill");
        else
            text.SetText(PlayerHealth.kills.ToString() + " kills");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
        gameOver.SetActive(false);
        ui.SetActive(true);
        player.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
