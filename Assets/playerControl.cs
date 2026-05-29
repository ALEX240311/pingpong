using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] private float speed = 4f;


    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
