using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource sound; //компонент AudioSource
    public AudioClip clip; //аудиоклип
    public float jumpForce; //сила прыжка
    public GameObject deathEffect; //частицы смерти
    public GameObject deathMenu; //меню проигрыша
    public Image progressBar; //полоса прогресса
    public Transform finish; //координаты финиша
    public Text[] txtProgress; //текст прогресса
    public float progress; //прогресс в процентах
    private float distanceToFinish; //расстояние до финиша
    private float startDistanceToFinish; //стартовое расстояние до финиша
    private bool canJump = true; //может ли прыгать игрок
    Rigidbody2D rb; //компонент Rigidbody2D

    void Awake()
    {
        deathMenu.SetActive(false); //Преждевременное отключение меню проигрыша
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Подключение к компоненту Rigidbody2D
        startDistanceToFinish = Mathf.Abs(transform.position.x - finish.position.x); //Расчет стартовой дистанции от игрока до финиша
    }

    // Update is called once per frame
    void Update()
    {
        //Полоса прогресса
        distanceToFinish = Mathf.Abs(transform.position.x - finish.position.x); //Расчет дистанции от игрока до финиша 
        progressBar.fillAmount = 1 - distanceToFinish/startDistanceToFinish; //Изменение полосы прогресса
        progress = Mathf.Round((1 - distanceToFinish/startDistanceToFinish)*100); //Расчет прогресса в процентах
        //Вывод на экран прогресса в процентах
        for (int i=0; i<txtProgress.Length; i++) 
        txtProgress[i].text = progress.ToString() + "%"; //Вывод на экран
        //Прыжок игрока
        if (Input.GetKeyDown(KeyCode.Space) && canJump) //Проверка на нажатие клавиши SPACE и может ли игрок прыгать
        {
            rb.AddForce(Vector3.up*jumpForce, ForceMode2D.Impulse); //Прыжок
            rb.AddTorque(-1f, ForceMode2D.Impulse);
            canJump = false; //игрок не может прыгать
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       if (other.collider.CompareTag("Ground") || other.collider.CompareTag("Cube")) //Если игрок на земле или на кубе
       {
           canJump = true; //игрок может прыгать
       } 
       if (other.collider.CompareTag("Spike")) //Если игрок столкнулся с шипом
       {
           Death(); //вызов функции Death
       }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Cube")) //Если игрок столкнулся с кубом
        {
           if (transform.position.y <= other.gameObject.transform.position.y) //Если позиция игрок ниже или равна позиции куба
           {
               Death(); //вызов функции Death
           }
       }
    }
    //
    void Death() {
        sound.clip = clip; //присваивание компоненту AudioSource звук смерти
        sound.Play(); //включение звука смерти
        Time.timeScale = 0; //заморозка времени
        Instantiate(deathEffect, transform.position, Quaternion.identity); //создание партиклов
        deathMenu.SetActive(true); //включение меню смерти
        Destroy(gameObject); //уничтожение объекта
    }
}
