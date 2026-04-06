using UnityEngine;
//Yogay Jain//
//jainyogya07//
//https://github.com/jainyogya07//



public class PlayerMovement : MonoBehaviour
{
	public CharacterController control;
	public float speed = 5f;
	public float SprentSpeed = 7f;
	float Sprint; 
	public float Gravity = -9.81f;
	public float JumpHight = 1.4f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;

	public bool isJumpAviable;
	public bool isSprentAvable;

	Vector3 velocity;
	bool isGrounded;
	public bool isSprenting = false;

	public float x;
	public float z;

    private void Start()
    {
		x = 0f;
		z = 0f;

    }


    // Update is called once per frame
    void Update()

	{
        float CSpeed = SprentSpeed / speed;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if(isGrounded && velocity.y < 0)
		{
			velocity.y = -0.09f;
		} 

		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");

	   Vector3 move = transform.right * x + transform.forward * z;
	   control.Move(move * speed * Sprint * Time.deltaTime);

		if (isJumpAviable)
		{
			if (Input.GetButtonDown("Jump") && isGrounded)
			{
				velocity.y = Mathf.Sqrt(JumpHight * -2f * Gravity);
			}
		}

		if (isSprentAvable)
		{

			if (Input.GetButtonDown("Fire3"))
			{
				isSprenting = true;
			}

			if (Input.GetButtonUp("Fire3"))
			{
				isSprenting = false;
			}

			if (isSprenting)
			{
				Sprint = CSpeed;
			}
		}
			if (!isSprenting)
			{
				Sprint = 1f;
			}
		

	   velocity.y += Gravity * Time.deltaTime;
	   control.Move(velocity  * Time.deltaTime);
	}
}
