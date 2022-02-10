using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject GroundLeft;
    [SerializeField]
    private GameObject GroundRight;

    private int kol=6;
    void Start()
    {
        int sizeX =(int) gameObject.GetComponent<RectTransform>().sizeDelta.x / kol;
        float fieldWidth = Screen.width - 30;
        float fieldHeight = Screen.width - sizeX;
        var cellSize = (fieldWidth - (12 * (kol)) - 12) / (kol);


        int startX = (int)(-(fieldWidth / 2) + (cellSize / 2) + (12 * 2));
        int startY = (int)(((fieldHeight / 2) - (cellSize / 2) - (12 * 2))) * 2;

        int x = (int)(UnityEngine.Random.Range(1, (kol - 2)));
        int y = (int)(UnityEngine.Random.Range(2, (kol - 3)));

        int positionX = startX + (int)(sizeX * x);
        int positionY = startY - (int)(sizeX * y);
        GroundLeft.transform.localPosition = new Vector2(startX - (sizeX), startY - (sizeX * (int)((kol - 1) / 2)));
        GroundRight.transform.localPosition = new Vector2(startX + (sizeX * (kol-1)), startY - (sizeX * (int)((kol - 1) / 2)));

    }
    void Update()
    {
        
    }
}
