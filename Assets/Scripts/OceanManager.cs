using System;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    public static OceanManager _;

    [SerializeField] private Transform water;
    [SerializeField] private Material[] waveAppliedMaterials;
    
    [SerializeField] float steepness = 0.088f;
    [SerializeField] float waveLength = 2.8f;
    [SerializeField] float speed = 0.57f;
    [SerializeField] Vector4 directions = new Vector4(0f, 0.5f, 1f, 0.2f);

    private void Awake()
    {
        if (_ == null)
        {
            _ = this;
            DontDestroyOnLoad(gameObject);

            foreach (var mat in waveAppliedMaterials)
            {
                mat.SetFloat("_Wave_Steepness", steepness);
                mat.SetFloat("_Wave_Length", waveLength);
                mat.SetFloat("_Wave_Speed", speed);
                mat.SetVector("_Wave_Directions", directions);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float WaterHeightAtPos(Vector3 position)
    {
        return water.position.y + GerstnerWaveDisplacement.GetWaveDisplacement(position, steepness, waveLength, speed, directions).y;
    }
}
