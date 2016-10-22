/*
 * Sound for the seal provided by http://www.freesfx.co.uk. This link should be included in the game's credits as per the License agreement
 */

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
        yield return new WaitForSeconds(handController.faceSlapDuration * 3);
        MakeSealIdle();
    }

    public void MakeSealIdle()
    {
        spriteRenderer.sprite = idleSeal;
    }
}
