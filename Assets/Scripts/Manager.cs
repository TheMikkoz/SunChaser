using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Rect PlayerRect;
    [SerializeField] private Rect[] Ground;

    // Update is called once per frame
    void Update()
    {
        PlayerRect.position = Player.transform.position;
        for (int i = 0; i < Ground.Length; i++)
        {
            if (PlayerRect.Overlaps(Ground[i]))
            {
                Player.GetComponent<Movement>().grounded = true;
            }
        }
    }
}
