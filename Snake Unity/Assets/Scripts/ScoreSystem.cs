using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public static int Score = 0;
    private Text _text;

    // Use this for initialization
    void Start()
    {
        Score = 0;
        _text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = Score.ToString();
    }
}
