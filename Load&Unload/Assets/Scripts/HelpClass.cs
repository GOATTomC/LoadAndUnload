using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpClass {

public static IEnumerator PositionLerp(Transform target, Transform end, float time, float delay = 0)
    {

        float elapsedTime = 0;
        yield return new WaitForSeconds(delay);
        while (elapsedTime < time)
        {
            target.position = Vector3.Lerp(target.position, end.position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        target.position = end.position;
    }

public static IEnumerator RotationLerp(Transform target, Transform end, float time, float delay = 0)
    {

        float elapsedTime = 0;
        yield return new WaitForSeconds(delay);
        while (elapsedTime < time)
        {
            target.rotation = Quaternion.Lerp(target.rotation, end.rotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        target.rotation = end.rotation;
    }

    public static IEnumerator RotationLerp(Transform target, Quaternion end, float time, float delay = 0)
    {

        float elapsedTime = 0;
        yield return new WaitForSeconds(delay);
        while (elapsedTime < time)
        {
            target.rotation = Quaternion.Lerp(target.rotation, end, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        target.rotation = end;
    }

    public static Quaternion LookRotation(Vector3 a, Vector3 b)
    {
        Vector3 lookDir = (b - a).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(lookDir);

        return lookRotation;
    }

}