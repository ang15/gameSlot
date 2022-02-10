using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circles : MonoBehaviour
{
    public GameObject[] circles; 
    public Canvas canvas;
    private int kol=6;
    void Start()
    {  
    float sizeX = canvas.GetComponent<RectTransform>().sizeDelta.x / kol;
        int kolY = (int)(canvas.GetComponent<RectTransform>().sizeDelta.y / sizeX);
        float fieldWidth = Screen.width - 30;
        float fieldHeight = Screen.width - sizeX;
        var cellSize = (fieldWidth - (12 * (kol)) - 12) / (kol);


        int startX = (int)(-(fieldWidth / 2) + (cellSize / 2) /*+ (12 * 2)*/);
        int startY = (int)((fieldHeight / 2) - (cellSize / 2)) /*- (12 * 2))*/ ;

        for (int i = 0;i<circles.Length;i++) {
            circles[i].transform.localPosition = new Vector2(startX + (sizeX * i), startY);
            circles[i].GetComponent<RectTransform>().sizeDelta = new Vector2(sizeX + (sizeX / 2), sizeX + (sizeX / 2));
            circles[i].GetComponent<CircleCollider2D>().radius = sizeX/2;
        }
    }

    // Update is called once per frame
    void Update()
    { 
    }
}
