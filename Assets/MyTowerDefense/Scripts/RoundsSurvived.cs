using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundsSurvived : MonoBehaviour
{
    public Text RoundText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        RoundText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.1f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            RoundText.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
}
