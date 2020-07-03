using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeControls : MonoBehaviour
{
    public static float SnakeSpeed = 0.3f;
    public GameObject Tail;
    public GameObject FoodGenerator;
    public GameObject GameOver;

    public GameObject TopBorder;
    public GameObject BottomBorder;
    public GameObject LeftBorder;
    public GameObject RightBorder;
    public Transform TailPart;

    private List<Transform> _snakeTail;
    private Vector2 _movementDirection;
    private bool _hasEaten; 

	// Use this for initialization
	void Start ()
    {
        _movementDirection = Vector2.right;
        _snakeTail = new List<Transform> { TailPart };
        InvokeRepeating("MoveSnake", 0.8f, SnakeSpeed);
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetKeyboardInput();
    }

    void GetKeyboardInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _movementDirection = (_movementDirection == Vector2.left) ? _movementDirection : Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _movementDirection = (_movementDirection == Vector2.up) ? _movementDirection : Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _movementDirection = (_movementDirection == Vector2.right) ? _movementDirection : Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            _movementDirection = (_movementDirection == Vector2.down) ? _movementDirection : Vector2.up;
        }
    }

    void MoveSnake()
    {
        var currentPosition = transform.position;   

        if (CheckIfWillCollide()) 
        {
            Debug.Log("Died");
            EndGame();
        }
        else 
        {
            transform.Translate(_movementDirection);

            if (_hasEaten)
            {
                var tail = Instantiate(Tail, currentPosition, Quaternion.identity);
                _snakeTail.Insert(0, tail.transform);
                _hasEaten = false;
            }
            else if (_snakeTail.Count > 0)
            {
                _snakeTail.LastOrDefault().position = currentPosition;
                _snakeTail.Insert(0, _snakeTail.LastOrDefault());
                _snakeTail.RemoveAt(_snakeTail.Count - 1);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Destroy(collision.gameObject);
            _hasEaten = true;
            ScoreSystem.Score++;
            FoodGenerator.GetComponent<FoodGenerator>().Spawn(_snakeTail);
        }
        else
        {
            EndGame();
        }
    }

    bool CheckIfWillCollide()
    {
        if (_movementDirection == Vector2.up)
        {
            return ((int)transform.position.y + 1 == (int)TopBorder.transform.position.y);
        }
        else if (_movementDirection == Vector2.down)
        {
            return ((int)transform.position.y - 1 == (int)BottomBorder.transform.position.y);
        }
        else if (_movementDirection == Vector2.left)
        {
            return ((int)transform.position.x - 1 == (int)LeftBorder.transform.position.x);
        }
        else if (_movementDirection == Vector2.right)
        {
            return ((int)transform.position.x + 1 == (int)RightBorder.transform.position.x);
        }

        return false;    
    }

    void EndGame()
    {
        GameOver.SetActive(true);
        CancelInvoke();
    }
}
