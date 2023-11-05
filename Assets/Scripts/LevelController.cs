using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float speed; //скорость
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime); //Постоянное движение влево
        if (transform.position.x <= -12.96f) //если координата по x меньше или равна -12.96
        {
            Destroy(gameObject); //уничтожение объекта
        }
    }
}
