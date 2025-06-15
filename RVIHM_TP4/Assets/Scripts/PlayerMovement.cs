using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 5f;
    
    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveN = new Vector3(moveX, 0f, moveZ).normalized;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float moveSpeed = isRunning ? runSpeed : walkSpeed;

        animator.SetBool("Run", isRunning);

        if (moveN.magnitude >= 0.1f)
        {
            Vector3 move = transform.TransformDirection(moveN) * moveSpeed * Time.deltaTime;
            transform.Translate(move, Space.World);

            animator.SetFloat("Speed", moveSpeed);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }
}
