using UnityEngine;

public class DiscRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
