using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedBoost = 2f;
    public float slowSpeed = 0.5f;
    public bool isInverted = false;
    public bool movementEnabled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!movementEnabled)
            return;
        float upDown = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rightLeft = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (isInverted)
        {
            upDown = -upDown;
            rightLeft = -rightLeft;
        }

        transform.Translate(rightLeft, upDown, 0);
    }

    public void InvertControls()
    {
        isInverted = !isInverted;
    }

    public void ApplyBoost()
    {
        moveSpeed = moveSpeed * speedBoost;
    }

    public void ApplySlow()
    {
        moveSpeed = moveSpeed * slowSpeed;
    }

    public void SetMovement(bool val_ = true)
    {
        movementEnabled = val_;
    }
}
