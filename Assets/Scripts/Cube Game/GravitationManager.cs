using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationManager : MonoBehaviour {

    public Rigidbody[] cubesBody;

    public void SwitchGravitation(bool state)
    {
        foreach(var r in cubesBody)
        {
            r.useGravity = state;
        }
    }
}
