using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 2.0f);
    }
}
