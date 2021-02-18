using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public int Index;
    public Ability Ability;

    public void UplockAbility()
    {
        Ability.Unlock();
    }
}
