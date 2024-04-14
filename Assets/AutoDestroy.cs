using UnityEngine;

// ReSharper disable All

public class AutoDestroy : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }       
    }
}
