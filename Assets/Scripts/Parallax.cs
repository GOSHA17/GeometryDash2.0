using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //Параллакс эффект создает иллюзию постоянно движущегося заднего фона
    
    public float startX; //Начальная координата X
    public float endX; // Конечная координата X
    public float speed; //скорость движения
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime); //Постоянное движение влево
        if (transform.position.x <= endX) //Если координата по x меньше или равна конечной координате 
        {
            transform.position = new Vector2(startX, transform.position.y); //Возвращаем объект на начальную координату
        }
    }
}
