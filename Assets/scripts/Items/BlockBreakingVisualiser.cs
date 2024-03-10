using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockBreakingVisualiser : MonoBehaviour
{
    private List<Animator> animators = new List<Animator>();
    public float AnimationSpeed = 0.5f;
    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>().ToList();
        foreach (Animator animator in animators)
        {
            animator.gameObject.SetActive(false);
        }
    }

    public void OnBreakingStart()
    {
        foreach(Animator animator in animators)
        {
            animator.gameObject.SetActive(true);
            animator.speed = AnimationSpeed;
            animator.Play("BlockBreaking");
        }
    }

    public void OnBreakingStop()
    {
        foreach (Animator animator in animators)
        {
            animator.gameObject.SetActive(false);
        }
    }

}
