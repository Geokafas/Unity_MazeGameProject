using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public smashAnimation _smash;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var y = Input.GetAxis("Jump") * Time.deltaTime * 5.0f;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        transform.Translate(0, y, 0);




        if (Input.GetButtonDown("Fire1"))
        {
            _smash.attack();
        }
    }
}