using System.Collections;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Vector3 Direction = Vector3.up;
    public float Speed = 20.0f;
    public float LifeTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMe", LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }
    // destroy myself
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
