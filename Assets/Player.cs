using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float SpeedPlayer;
    Rigidbody2D rigidbody;
    private bool onMouse = false;
    public Canvas canvas;
    private int kol=6;
    private int startX;
    private int sizeX;
    private void Start()
    {
        sizeX = (int)canvas.GetComponent<RectTransform>().sizeDelta.x / kol;
        int kolY = (int)(canvas.GetComponent<RectTransform>().sizeDelta.y / sizeX);
        float fieldWidth = Screen.width - 30;
        float fieldHeight = Screen.width - sizeX;
        var cellSize = (fieldWidth - (12 * (kol)) - 12) / (kol);


         startX = (int)(-(fieldWidth / 2) + (cellSize / 2));
        int startY = (int)((fieldHeight / 2) - (cellSize /2) ) * 2;
       
        transform.localPosition = new Vector2(startX + (sizeX * 2), startY - (sizeX * (kolY -2.5f)));
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX + (sizeX / 2), sizeX + (sizeX / 2));
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(sizeX / 2, sizeX / 2);
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Debug.Log(startX + (sizeX * (kol - 1)));
        Debug.Log(startX);
   
        if (onMouse == true)
        {
            if (transform.localPosition.x < startX)
            {
                transform.localPosition = new Vector2(startX+sizeX, transform.localPosition.y); onMouse = false;
            }
            if (transform.localPosition.x > startX + (sizeX * (kol - 1)))
            {
                transform.localPosition = new Vector2(startX + (sizeX * (kol - 2)), transform.localPosition.y); onMouse = false;
            }
              else
            {
                gameObject.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
            }
           
        }
       
    }

    void OnMouseDown()
    {
        onMouse = true;
    }
    void OnMouseUp()
    {
        onMouse = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="GroundLeft")
        {
            transform.localPosition = new Vector2(startX, transform.localPosition.y);
        }
    }
}
