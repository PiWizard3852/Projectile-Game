using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class GenerateTargets : MonoBehaviour
{
    public GameObject target;

    private Random random = new();
    
    private GameObject targetOne;
    private GameObject targetTwo;
    
    void Start()
    {
        targetOne = Instantiate(target, new Vector3(random.Next(0, 1) == 1 ? 9.8f : -9.8f, random.Next(1, 4), random.Next(-4, 4)), Quaternion.Euler(0, 90, 0));
        targetTwo = Instantiate(target, new Vector3(random.Next(-4, 4), random.Next(1, 4), random.Next(0, 1) == 1 ? 9.8f : -9.8f), Quaternion.Euler(0, 0, 0));
    }

    void Update()
    {
        if (targetOne.IsDestroyed())
        {
            targetOne = Instantiate(target, new Vector3(random.Next(0, 1) == 1 ? 9.8f : -9.8f, random.Next(1, 4), random.Next(-4, 4)), Quaternion.Euler(0, 90, 0));
        }
        
        if (targetTwo.IsDestroyed())
        {
            targetTwo = Instantiate(target, new Vector3(random.Next(-4, 4), random.Next(1, 4), random.Next(0, 1) == 1 ? 9.8f : -9.8f), Quaternion.Euler(0, 0, 0));
        }
    }
}
