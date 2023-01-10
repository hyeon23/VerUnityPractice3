using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//Ű����, ���콺, ��ġ�� �̺�Ʈ�� ������Ʈ�� ���� �� �ִ� ��� ����

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{   
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10, 150)]
    private float leverRange;

    private Vector2 inputDirection;
    private bool isInput;

    [SerializeField]
    private TPSCharacterController controller;

    public float sensitivity = 1f;

    public enum JoystickType { Move, Rotate, Count };
    public JoystickType joystickType;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoustickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoustickLever(eventData);
    }

    private void ControlJoustickLever(PointerEventData eventData)
    {
        //��ġ ��ġ: eventData.position
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;//inputVector�� �ػ󵵸� ������� �������, �̸� ������� ����ϸ� �ʹ� ū ����
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
        switch (joystickType)
        {
            case JoystickType.Move:
                controller.MoveJoystick(Vector2.zero);
                break;
            case JoystickType.Rotate:
                break;
        }
    }

    private void InputControlVector()
    {
        //ĳ���Ϳ��� �Էº��͸� ����
        Debug.Log(inputDirection.x + " / " + inputDirection.y);
        switch (joystickType)
        {
            case JoystickType.Move:
                controller.MoveJoystick(inputDirection * sensitivity);
                break;
            case JoystickType.Rotate:
                controller.LookAroundJoystick(inputDirection * sensitivity);
                break;
        }   
    }

    private void Update()
    {
        if (isInput)
        {
            InputControlVector();
        }
    }
}
