using UnityEngine;

public class ConsoleTest : MonoBehaviour
{
    private float numberA = 0f;
    public float numberB = 0f;
    public float result = 0f;

    void Start()
    {
        Debug.Log("Hello World, this is MY TCC");
        Soma(1, 1);
        Soma(2, 2);
    }

    private void Soma(float numberA, float numberB)
    {
        Debug.Log(numberA + numberB);
    }
}
