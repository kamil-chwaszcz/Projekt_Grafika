using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Car car;
    public GameObject needle;
    private float startPosition = 220f;
    private float endPosition = -42f;
    private float expectedPosition;
    public float carSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float tempSpeed = car.velocity * 2.5f;

        if (tempSpeed < 0.0f)
        {
            tempSpeed -= 2 * tempSpeed;
        }
        carSpeed = tempSpeed;

        updateNeedle();
    }

    public void updateNeedle()
    {
        expectedPosition = startPosition - endPosition;
        float temp = carSpeed / 180;

        if (temp > 1f)
        {
            temp = 1f;
        }

        needle.transform.eulerAngles = new Vector3(0, 0, (startPosition - temp * expectedPosition));
    }
}
