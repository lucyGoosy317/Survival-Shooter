using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shot : MonoBehaviour
{
  public void GotShot()
    {
        enemy_movement behavior = GetComponent<enemy_movement>();
        if (behavior!= null)
        {
            behavior.SetAlive(false);
        }
        //behavior.anime.SetInteger("Condition",3);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        //this.transform.Rotate(-75,0,0);
        yield return new WaitForSeconds(10.5f);
        Destroy(this.gameObject);
    }
}
