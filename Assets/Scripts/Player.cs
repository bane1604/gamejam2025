using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedBoost = 2f;
    public float slowSpeed = 0.5f;
    public bool isInverted = false;
    public bool movementEnabled = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator _animator;

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

        if (upDown != 0 || rightLeft != 0)
        {
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }

        if (rightLeft != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (rightLeft > 0 ? 1 : -1);
            transform.localScale = scale;
        }

        _animator.SetFloat("movementSpeed", moveSpeed);
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
