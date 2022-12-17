using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DissolvePositioner : MonoBehaviour
{
    public GameObject targetObject, sourceObject;
    public float distance;
    public bool isReady;
    public Vector3 OffSet;

    private void Update()
    {
        if (isReady)
            calculateDistance(targetObject.transform);
        else
            return;
    }
    public void calculateDistance(Transform target)
    {
        if (targetObject.GetComponent<MeshRenderer>().material == null)
        {
            return;
        }
        else
        {
            Material mat = targetObject.GetComponent<MeshRenderer>().material;
            distance = Vector3.Distance(sourceObject.transform.position, target.position+ OffSet);
            Vector3 scaleValues = sourceObject.transform.localScale;
            float totalAverage = scaleValues.x + scaleValues.y + scaleValues.z;
            float Average = totalAverage / 3;
            mat.SetVector("position", -sourceObject.transform.position / 1.1f);
            float distanceAverage = (distance * 1.08f) - (Average / 4);
            mat.SetFloat("dissolve", distanceAverage);
            Color color = Color.red * 10;
            mat.SetColor("edgecolor", color);
        }
    }
}
