using UnityEngine;
public abstract class Character : ScriptableObject
{
    protected int maxHp;
    protected int hp;
    protected int block;

    public virtual void TakeDamage(int dmg)
    {
        if(block > 0)
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
}
