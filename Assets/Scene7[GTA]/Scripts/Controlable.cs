using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controlable : MonoBehaviour
{
    public Transform cameraArmSoket;
    public Transform cameraArm;



    //추상 클래스를 상속받는 클래스는 추상 메소드를 반드시 강제로 구현해야함
    public abstract void Move(Vector2 input);
    public abstract void Rotate(Vector2 input);
    public abstract void Interact();
    public abstract void Jump();
}
