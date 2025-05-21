using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public void ChooseIsrael()
    {
        GameManager.Instance.StartAs(PlayerSide.Israel);
    }

    public void ChoosePalestine()
    {
        GameManager.Instance.StartAs(PlayerSide.Palestine);
    }
}
