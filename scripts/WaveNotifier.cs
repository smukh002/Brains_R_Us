using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveNotifier : MonoBehaviour
{
    public GameObject uiText;

    public GameObject waveDisp;
    public GameObject notifText;

    void Start()
    {
        waveDisp.SetActive(false);
    }

    public void Display(int num)
    {
        StartCoroutine(Disp(num));
    }

    // Update is called once per frame
    IEnumerator Disp(int num)
    {
        uiText.SetActive(false);
        waveDisp.SetActive(true);
        notifText.SetActive(true);
        
        notifText.GetComponent<TextMeshProUGUI>().SetText("Wave " + num.ToString());
        yield return new WaitForSeconds(0.5f);
        notifText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        notifText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        notifText.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        notifText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        notifText.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        waveDisp.SetActive(false);
        uiText.SetActive(true);
        uiText.GetComponent<TextMeshProUGUI>().SetText("Wave " + num.ToString());

        yield break;
    }
}
