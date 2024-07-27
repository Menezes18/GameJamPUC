using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Eroding : MonoBehaviour
{
    public float erodeRate = 0.03f;
    public float erodeRefreshRate = 0.01f;
    public float erodeDelay = 1.25f;
    public SkinnedMeshRenderer erodeObject;
    public List<VisualEffect> effect = new List<VisualEffect>();
    void Start()
    {
        for(int i = 0; i < effect.Count; i++)
        effect[i].SendEvent("OnStop");
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            StartCoroutine(ErodeObject());
            Debug.Log(erodeObject.material.GetFloat("_Erode"));
        }
    }
    IEnumerator ErodeObject()
    {
        yield return new WaitForSeconds(erodeDelay);
        if(erodeObject.material.GetFloat("_Erode") >= 1f){
            for(int i = 0; i < effect.Count; i++)
            effect[i].SendEvent("OnStop");
            float t = 1;
            while (t > 0)
            {
                t -= erodeRate;
                for(int i = 0; i < erodeObject.materials.Length; i++)
                erodeObject.materials[i].SetFloat("_Erode", t);
                yield return new WaitForSeconds(erodeRefreshRate);
            }
        }
        else 
        {
            float t = 0;
            if(effect != null)
            for(int i = 0; i < effect.Count; i++)
            effect[i].SendEvent("OnPlay");
            while (t < 1)
            {
                t += erodeRate;
                for(int i = 0; i < erodeObject.materials.Length; i++)
                erodeObject.materials[i].SetFloat("_Erode", t);
                yield return new WaitForSeconds(erodeRefreshRate);
            }
        }
    }
}