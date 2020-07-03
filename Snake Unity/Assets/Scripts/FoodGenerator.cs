using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {

    public GameObject Food;
    public GameObject TopBorder;
    public GameObject BottomBorder;
    public GameObject LeftBorder;
    public GameObject RightBorder;
    
    // Use this for initialization
    void Start ()
    {
        Spawn(new List<Transform>());
    }

    public void Spawn(List<Transform> snakeTail)
    {
        var x = 0;
        var y = 0;

        while (true)
        {
            x = (int)Random.Range(LeftBorder.transform.position.x, RightBorder.transform.position.x);
            y = (int)Random.Range(BottomBorder.transform.position.y, TopBorder.transform.position.y);
            var isBody = false;

            foreach (var t in snakeTail)
            {
                if (t.position.x == x && t.position.y == y)
                {
                    isBody = true;
                    break;
                }
            }
            if (!isBody)
            {
                break;
            }
        }

        Instantiate(Food, new Vector2(x, y), Quaternion.identity);
    }


}
