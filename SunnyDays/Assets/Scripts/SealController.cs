using UnityEngine;
using System.Collections;

public class SealController : MonoBehaviour {


    public Sprite idleSeal;
    public Sprite happySeal;
    public Sprite sadSeal;

    private SpriteRenderer spriteRenderer;

    public HandController handController;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSeal;
    }
	
	public IEnumerator MakeSealHappy()
    {
        spriteRenderer.sprite = happySeal;
        yield return new WaitForSeconds(handController.highFiveDuration);
        MakeSealIdle();
    }

    public IEnumerator MakeSealSad()
    {
        spriteRenderer.sprite = sadSeal;
        yield return new WaitForSeconds(handController.highFiveDuration);
        MakeSealIdle();
    }

    public void MakeSealIdle()
    {
        spriteRenderer.sprite = idleSeal;
    }
}
