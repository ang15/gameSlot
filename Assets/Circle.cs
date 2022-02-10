using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Circle : MonoBehaviour
{
    public GameObject platform;
    public Circles circles;
    private float  startPozitionX;
    private float  startPozitionY;
  
  //  public Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        startPozitionX = transform.position.x;
        startPozitionY = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < platform.transform.position.y)
        {
            int z = Random.Range(0, 6);
            if (circles.circles[z].activeSelf == false)
            {
                circles.circles[z].SetActive(true);
                gameObject.transform.position = new Vector2(startPozitionX, startPozitionY);
                gameObject.SetActive(false);
            }
            
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0); 
        }
    }

}
