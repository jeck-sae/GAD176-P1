using UnityEngine;

public class AssignmentRequirements : MonoBehaviour
{
    [SerializeField] protected int serializeField;
    AssignmentRequirements r;
    void Start()
    {
        if(r == null) 
            r = GetComponent<AssignmentRequirements>();

        var a = (Vector3.zero + Vector3.one).normalized.magnitude;
    }

}
