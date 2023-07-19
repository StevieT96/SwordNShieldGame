using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdBounceRandom : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        animator.Play("Crowd Bounce", -1, Random.Range(0.0f, 1.0f));
    }
}
