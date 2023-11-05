using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void pointerDown() 
    {
        transform.localScale = new Vector3(0.9f,0.9f,0.9f); //уменьшение размера в 0.9 раз
    }
    public void pointerUp() 
    {
        transform.localScale = new Vector3(1f,1f,1f); //возврат изначального размера
    }
    public void restartGame() {
        Time.timeScale = 1; //Разморозка времени
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //загрузка сцены, на которой находимся
    }
    public void mainMenu() 
    {
        SceneManager.LoadScene("MainMenu"); //загрузка главного меню
    }
    public void nextLevel() 
    {
        Time.timeScale = 1; //разморозка времени
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //загрузка следующей сцены
    }
    public void Exit() 
    {
        Application.Quit(); //выход из приложения
    }
}
