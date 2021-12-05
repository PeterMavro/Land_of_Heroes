using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;
    public TextMeshProUGUI[] _Timers;
    public int timerMinutes = 2;
    public int timerseconds = 59;

    private string displaySeconds;
    private string displayMinutes;
    public string displayFinished;

    public
    // Start is called before the first frame update
    void Start()
    {
        text = _Timers[0];
        if (timerseconds < 10)
        {
            displaySeconds = ":0" + timerseconds; 
        }
        else
        {
            displaySeconds = ":" + timerseconds; 
        }
        if (timerMinutes > 9)
        {
            displayMinutes = "" + timerMinutes;
        }
        else
        {
            displayMinutes = "0" + timerMinutes;
        }
        text.GetComponent<TextMeshProUGUI>().text = displayMinutes + displaySeconds;
        StartCoroutine (Timerticking());

        if (displayFinished == null)
        {
            displayFinished = "timer finished";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Timerticking()
    {
        if (timerMinutes >= 0)
        {
            timerseconds -= 1;
        }
        if (timerseconds < 0)
        {
            timerMinutes -= 1;
            timerseconds = 59;
        }

        yield return new WaitForSeconds(1);
        if (timerseconds < 10)
        {
            displaySeconds = ":0" + timerseconds;
        }
        else
        {
            displaySeconds = ":" + timerseconds;
        }
        if (timerMinutes > 9)
        {
            displayMinutes = "" + timerMinutes;
        }
        else
        {
            displayMinutes = "0" + timerMinutes;
        }
        text.GetComponent<TextMeshProUGUI>().text = displayMinutes + displaySeconds;

        if (timerMinutes < 0)
        {
            StopCoroutine(Timerticking());
            text.GetComponent<TextMeshProUGUI>().text = displayFinished;
        }
        else
        { 
            StartCoroutine(Timerticking()); 
        }
        for (int i = 0; i < _Timers.Length; i++)
        {
            _Timers[i].GetComponent<TextMeshProUGUI>().text = text.text;
        }
    }
}
