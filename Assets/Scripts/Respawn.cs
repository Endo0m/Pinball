using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Определенный тег пола
    public string floorTag = "Floor";

    // Точка телепортации
    public Transform teleportPoint;

    // Метод вызывается, когда объект соприкасается с другим коллайдером
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что тег объекта соответствует заданному тегу пола
        if (other.gameObject.CompareTag(floorTag))
        {
            // Телепортируем объект в заданную точку
            transform.position = teleportPoint.position;
        }
    }
}
