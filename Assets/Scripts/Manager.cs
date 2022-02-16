using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    [SerializeField] private Rect PlayerRect;

    [SerializeField] private GameObject[] GroundPrefab;
    [SerializeField] private Rect[] Ground;

    private void Start()
    {
        //Collision detection init ->
        //Player
        Sprite plr = Player.GetComponent<SpriteRenderer>().sprite;
        PlayerRect = plr.rect;
        PlayerRect.width = PlayerRect.width* Player.transform.localScale.x / plr.pixelsPerUnit ;
        PlayerRect.height = PlayerRect.height * Player.transform.localScale.y / plr.pixelsPerUnit;
        PlayerRect.center = Player.transform.position;

        //Ground
        Ground = new Rect[GroundPrefab.Length];
        for (int i = 0; i < GroundPrefab.Length; i++)
        {
            Sprite grnd = GroundPrefab[i].GetComponent<SpriteRenderer>().sprite;
            Ground[i] = grnd.rect;
            Ground[i].width = Ground[i].width * GroundPrefab[i].transform.localScale.x / grnd.pixelsPerUnit;
            Ground[i].height = Ground[i].height * GroundPrefab[i].transform.localScale.y / grnd.pixelsPerUnit;

            Ground[i].center = GroundPrefab[i].transform.position;
            Ground[i].position = GroundPrefab[i].transform.position;
        }
    //<- ...
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerRect.bottom);
    //Collision Detection ->
        PlayerRect.position = Player.transform.position;
        for (int i = 0; i < Ground.Length; i++)
        {
            if (PlayerRect.Overlaps(Ground[i]))
            {
                Player.GetComponent<Movement>().grounded = true;
            }
        }
    //<- ...
    }
}
