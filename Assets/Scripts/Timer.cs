using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TMP_Text timer;
    public float duration;
    private float dur;

    void Start()
    {
        dur = duration;
    }

    void Update()
    {
        dur -= Time.deltaTime;
        timer.text = "Timer: " + Mathf.Round (dur*100)/100;

        if (dur <0)
        {
            dur = duration;
            GetComponent<Manager>().Player.transform.position = GetComponent<Manager>().Player.GetComponent<Movement>().startingPoint;
            // Mahdollisia lisäyksiä: Time's up - teksti kun ajastin loppuu, parin sekunnin viive tason alkaessa
        }
    }
}
