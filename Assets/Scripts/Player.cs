using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float upDown = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rightLeft = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(rightLeft, upDown, 0);
    }
}
