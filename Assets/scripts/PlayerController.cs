using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Health = 100; // player health
    public float Speed = 10.0f; // player move speed in units per second
    public float ReloadDelay = 0.2f; // reload delay in seconds
    public Vector2 MinMaxX = Vector2.zero; // player min and max X position(in screen)

    // prefab to instantiate
    public GameObject PrefabAmmo = null;
    public GameObject GunPosition = null;
    private bool WeaponsActivated = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // clamping this position between the min and the max horizontal value.
        // and these values(min, max,speed... can be modified.)
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime, MinMaxX.x, MinMaxX.y),
            transform.position.y,
            transform.position.z
        );
    }
    // check input
    void LateUpdate()
    {
        if (Input.GetButton("Fire1") && WeaponsActivated)
        {
            Instantiate(PrefabAmmo, GunPosition.transform.position, PrefabAmmo.transform.rotation);
            WeaponsActivated = false;
            Invoke("ActivateWeapons", ReloadDelay); // activate the weapon later(0.2s later, as designated by ReloadDelay)
        }
    }
    void ActivateWeapons()
    {
        WeaponsActivated = true;
    }
}
