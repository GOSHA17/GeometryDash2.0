using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public float speed; //скорость
    public GameObject victoryMenu; //меню выигрыша

void Awake()
{
    victoryMenu.SetActive(false); //Преждевременное отключение меню выигрыша
}
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime); //Постоянное движение влево
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0; //заморозка времени
        victoryMenu.SetActive(true); //включение меню выигрыша 
    }
}
