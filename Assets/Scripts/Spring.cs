using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public SpringJoint springJoint;
    public float compressionAmount = 0.5f;
    public float compressionSpeed = 5f;
    public float compressionInterval = 2f;

    private float currentCompression = 0f;
    private float compressionTimer = 0f;
    private bool isCompressed = false;

    private void Start()
    {
        // Получаем ссылку на компонент Spring Joint
        springJoint = GetComponent<SpringJoint>();

        // Инициализируем таймер сжатия
        compressionTimer = compressionInterval;
    }

    private void Update()
    {
        // Обновляем таймер сжатия
        compressionTimer -= Time.deltaTime;

        // Проверяем, если таймер достиг нуля
        if (compressionTimer <= 0f)
        {
            // Инвертируем состояние сжатия
            isCompressed = !isCompressed;

            if (isCompressed)
            {
                // Сжимаем пружину
                currentCompression = 4f;
            }
            else
            {
                // Расширяем пружину
                currentCompression = 0f;
            }

            // Сбрасываем таймер сжатия
            compressionTimer = compressionInterval;
        }

        // Изменяем параметры пружины в соответствии с текущей сжатостью
        springJoint.minDistance = 0f;
        springJoint.maxDistance = currentCompression * compressionAmount;
    }
}