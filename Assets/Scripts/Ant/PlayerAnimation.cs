using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    public void Idle()
    {
        ClearAnimations();
    }

    private void ClearAnimations()
    {
        playerAnimator.SetBool("run", false);
        playerAnimator.SetBool("goofyRun", false);
        playerAnimator.ResetTrigger("dead");
    }

    public void RunFast()
    {
        playerAnimator.SetBool("run", true);
        playerAnimator.SetBool("goofyRun", false);

    }
    
    public void RunSlow()
    {
        playerAnimator.SetBool("goofyRun", true);
        playerAnimator.SetBool("run", false);
    }
    
    public void Dead()
    {
        playerAnimator.SetTrigger("dead");
    }
}
