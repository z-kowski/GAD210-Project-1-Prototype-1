using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public Animator swordAnimator;

    // Start is called before the first frame update
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            swordAnimator.SetTrigger("AttackA");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            swordAnimator.SetTrigger("AttackB");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            swordAnimator.SetTrigger("AttackC");
        }
    }
}
