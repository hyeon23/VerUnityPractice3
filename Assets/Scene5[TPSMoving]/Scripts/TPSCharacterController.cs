using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm;

    Animator animator;

    private void Start()
    {
        animator = characterBody.GetComponent<Animator>();
    }

    private void Update()
    {
        //LookAround();
        //Move();
    }

    //키보드 방향키 이동
    private void Move()
    {
        
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isMove", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = lookForward;//FPS식
            //characterBody.forward = moveDir;//RPG식
            transform.position += moveDir * Time.deltaTime * 5f;//이동속도
        }
    }

    //조이스틱 이동
    public void MoveJoystick(Vector2 inputDirection)
    {

        Vector2 moveInput = inputDirection;
        bool isMove = moveInput.magnitude != 0;
        animator.SetBool("isMove", isMove);
        if (isMove)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;

            characterBody.forward = lookForward;//FPS식
            //characterBody.forward = moveDir;//RPG식
            transform.position += moveDir * Time.deltaTime * 5f;//이동속도
        }
    }

    //마우스 방향 회전
    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;


        float x = camAngle.x - mouseDelta.y;
        //한국식: camAngle.x - mouseDelta.y
        //미국식: camAngle.x + mouseDelta.y
        if(x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
    //조이스틱 방향 회전
    public void LookAroundJoystick(Vector3 inputDirection)
    {
        Vector2 mouseDelta = inputDirection;
        Vector3 camAngle = cameraArm.rotation.eulerAngles;


        float x = camAngle.x - mouseDelta.y;
        //한국식: camAngle.x - mouseDelta.y
        //미국식: camAngle.x + mouseDelta.y
        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }
}
