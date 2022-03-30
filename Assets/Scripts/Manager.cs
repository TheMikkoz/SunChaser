using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    

    public GameObject Player;

    [SerializeField, Header("Transition")] float Height;

    private void Start()
    {
        StartCoroutine(transition());
    }


    public void Door()
    {
        StartCoroutine(transition());
    }

    IEnumerator transition()
    {
        Player.GetComponent<Movement>().enabled = false;
        Player.GetComponent<SpriteRenderer>().enabled = false;
        Vector2 pos = Player.transform.position;
        while (true)
        {
            if (pos.y + 10 <= Player.transform.position.y)
            {
                break;
            }
            else
            {
                yield return new WaitForSeconds(0.001f/Height);
                Player.transform.Translate(Vector2.up * Time.deltaTime * Height);
            }
        }

            Player.GetComponent<SpriteRenderer>().enabled = true;
            Player.GetComponent<Movement>().enabled = true;
    }
}
