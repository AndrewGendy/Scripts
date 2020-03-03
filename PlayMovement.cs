using UnityEngine;

public class PlayMovement : MonoBehaviour{

    public Rigidbody2D rb;

    public Animator animator;
    public float moveSpeed = 0.7f;

    public Joystick joystick;


    private Vector2 moveInput;
    private float rotation;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update() {
        TakeInput();


    }

    private void FixedUpdate() {
        MoveCharacter(moveInput);

    }


    void MoveCharacter(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction.normalized * moveSpeed * Time.fixedDeltaTime));
        Debug.Log("Direction is" + direction);

        // Rotating player 
        //if (direction.x > 0.1 && direction.y == 0) {
        //    transform.localEulerAngles = new Vector3(0, 0, -90);
        //}
        //else if (direction.x < -0.1 && direction.y == 0) {
        //    transform.localEulerAngles = new Vector3(0, 0, 90);
        //}
        //else if (direction.y > 0.1 && direction.x == 0) {
        //    transform.localEulerAngles = new Vector3(0, 0, 0);
        //}
        //else if (direction.y < -0.1 && direction.x == 0) {
        //    transform.localEulerAngles = new Vector3(0, 0, 180);
        //}

        //// Rotating player Diagnally
        //else if (direction.y == 1 && direction.x == 1) {
        //    transform.localEulerAngles = new Vector3(0, 0, -45);
        //}
        //else if (direction.y == 1 && direction.x == -1) {
        //    transform.localEulerAngles = new Vector3(0, 0, 45);
        //}
        //else if (direction.y == -1 && direction.x == 1) {
        //    transform.localEulerAngles = new Vector3(0, 0, -135);
        //}
        //else if (direction.y == -1 && direction.x == -1) {
        //    transform.localEulerAngles = new Vector3(0, 0, 135);
        //}

        if (direction != Vector2.zero) {
            if (direction.x > 0.1 && direction.y == 0) {
                //    transform.localEulerAngles = new Vector3(0, 0, -90);
                rotation = -90;
            }
            else if (direction.x < -0.1 && direction.y == 0) {
                    //    transform.localEulerAngles = new Vector3(0, 0, 90);
                rotation = 90;
            }
            else if (direction.y > 0.1 && direction.x == 0) {
                //    transform.localEulerAngles = new Vector3(0, 0, 0);
                rotation = 0;
            }
            else if (direction.y < -0.1 && direction.x == 0) {
                //    transform.localEulerAngles = new Vector3(0, 0, 180);
                rotation = 180;
            }

            //// Rotating player Diagnally
            else if (direction.y > 0.1 && direction.x > 0.1) {
                //    transform.localEulerAngles = new Vector3(0, 0, -45);
                rotation = -45;
            }
            else if (direction.y > 0.1 && direction.x < -0.1) {
                //    transform.localEulerAngles = new Vector3(0, 0, 45);
                rotation = 45;
            }
            else if (direction.y < -0.1 && direction.x > 0.1) {
                //    transform.localEulerAngles = new Vector3(0, 0, -135);
                rotation = -135;
            }
            else if (direction.y < -0.1 && direction.x < -0.1) {
                //    transform.localEulerAngles = new Vector3(0, 0, 135);
                rotation = 135;
            }

            transform.rotation = Quaternion.LookRotation(new Vector3(0,0,rotation), direction);

        }
    }

    private void TakeInput() {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal") + joystick.Horizontal, Input.GetAxisRaw("Vertical") + joystick.Vertical);

            if (moveInput.x != 0 || moveInput.y != 0) {
            animator.SetFloat("Speed", 1);
        }
        else {
            animator.SetFloat("Speed", 0);
        }
    }

    void Shoot() {
        Debug.Log("fire");

    }
}
