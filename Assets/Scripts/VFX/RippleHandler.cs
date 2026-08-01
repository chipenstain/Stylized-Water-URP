using System;
using UnityEngine;

public class RippleHandler : MonoBehaviour
{
    [SerializeField] private LayerMask waterLayer;
    [SerializeField] private ParticleSystem rippleVFX;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            rippleVFX.Emit(transform.position, Vector3.zero, 5, 0.1f, Color.white);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            rippleVFX.Emit(transform.position, Vector3.zero, 5, 0.1f, Color.white);
        }
    }
}
