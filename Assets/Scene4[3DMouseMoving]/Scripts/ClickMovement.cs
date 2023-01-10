using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ClickMovement : MonoBehaviour
{
    private Camera camera;
    private Animator animator;
    private NavMeshAgent agent;

    private bool isMove;
    private Vector3 destination;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //agent.updatePosition = false: �̵� �ݽ�
        agent.updateRotation = false;//ȸ�� ����
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }

        LookMoveDirection();
    }

    private void SetDestination(Vector3 dest)
    {
        //NavMeshAgent.SetDestination()���� �̵�
        agent.SetDestination(dest);
        destination = dest;
        isMove = true;
        animator.SetBool("isMove", true);
    }

    public void Move()
    {
        if (isMove)
        {
            var dir = destination - transform.position;
            animator.transform.forward = dir;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }

        if(Vector3.Distance(transform.position, destination) <= 0.1f)
        {
            isMove = false;
            animator.SetBool("isMove", false);
        }
    }

    public void LookMoveDirection()
    {
        if (isMove)
        {
            if (agent.velocity.magnitude == 0f)
            {
                isMove = false;
                animator.SetBool("isMove", false);
                return;
            }

            //���̰� �ٸ� �������� Ŭ���ϸ� ȸ���ϴ� ������ ���� ���� ���
            var dir = new Vector3(agent.steeringTarget.x, transform.position.y, agent.steeringTarget.z) - transform.position;
            animator.transform.forward = dir;
        }
    }
}
