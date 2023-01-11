using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Controlable controlTarget;

    public void ChangeControlTarget(Controlable origin, Controlable target)
    {
        StartCoroutine(MoveCameraArm(origin, target));
        controlTarget = target;
    }

    public IEnumerator MoveCameraArm(Controlable origin, Controlable target)
    {
        if (origin.cameraArm != null)
        {
            var cameraArm = origin.cameraArm;
            Vector3 startPos = cameraArm.position;
            Quaternion startRot = cameraArm.rotation;
            float timer = 0f;
            while (timer <= 1f)
            {
                yield return null;
                timer += Time.deltaTime * 3f;
                cameraArm.position = Vector3.Lerp(startPos, target.cameraArmSoket.position, timer);
                cameraArm.rotation = Quaternion.Slerp(startRot, target.cameraArm.rotation, timer);

            }
            cameraArm.SetParent(target.cameraArmSoket);
            target.cameraArm = cameraArm;
        }
    }
}
