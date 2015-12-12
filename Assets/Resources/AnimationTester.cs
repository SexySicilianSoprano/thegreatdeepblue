using UnityEngine;
using System.Collections;

public class AnimationTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Animator Anim = gameObject.GetComponent<Animator>();
        Anim.runtimeAnimatorController =
            (RuntimeAnimatorController)RuntimeAnimatorController.Instantiate(Resources.Load("TestAnimationController"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
