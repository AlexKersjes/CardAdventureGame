using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInstance : MonoBehaviour
{
    #region fields

    public Character character;
    public Image image;

    private int hp;
    private int block;


    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Block
    {
        get { return block; }
        set { block = value; }
    }
    #endregion
    private void Start()
    {
        if (!character)
            throw new System.NullReferenceException("CharacterInstance was not given a character");
        Init(character);
    }

    public virtual void TakeDamage(int dmg)
    {
        if (block > 0)
        {
            block -= dmg;
            if (block <= 0)
            {
                dmg = -block;
                block = 0;
            }
            else
            {
                dmg = 0;
            }
        }
        hp -= dmg;
    }
    public virtual void GainBlock(int block)
    {
        this.block += block;
    }

    public virtual void ResetBlock()
    {
        block = 0;
    }

    public void Init(Character character)
    {
        image.sprite = character.sprite;
        hp = character.maxHp;
        this.name = character.name;
    }
}
