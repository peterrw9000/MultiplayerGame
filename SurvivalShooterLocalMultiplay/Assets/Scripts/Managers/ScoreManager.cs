using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public PlayerMovement second;
    public Camera cam2;

    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
        if (Input.GetButton("DropIn"))
        {
            second.gameObject.SetActive(true);
            cam2.gameObject.SetActive(true);
            cam2.GetComponent<CameraFollow>().SetOffset();
        }
    }
}
