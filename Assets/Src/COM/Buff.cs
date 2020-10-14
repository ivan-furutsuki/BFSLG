using UnityEngine;
using System.Collections;
using Command;
using Character;
using System.Collections.Generic;

namespace Command
{



    /// <summary>
    /// Buff效果,不按技能源计算
    /// </summary>
    public class BaseBuff
    {
        /// <summary>
        /// Buff使用的计数器,如弹药数,层级等
        /// </summary>
        public float token { get; private set; }

        public float TokenPlus(float plus)
        {
            token += plus;
            return token;
        }

        public bool Expired
        {
            get; private set;
        }

        /// <summary>
        /// 约束自己的BuffControl
        /// </summary>
        protected BuffControl controler;
        protected BaseChar holder;



        protected virtual void InitiateSelf()
        {

        }

        /// <summary>
        /// 挂载Buff
        /// </summary>
        /// <param name="myControl">控制器</param>
        /// <param name="from">施加者</param>
        public virtual void Attach(BaseChar myControl, BaseChar from)
        {
            InitiateSelf();
            Expired = false;
            holder = myControl;
            controler = holder.buffControl;
            giver = from;

            //加载属性修正数值
            if (this.tagList.ContainsKey(BuffTag.AttrModer))
            {
                controler.attrOutput.AttrPlus((Attribute)tagList[BuffTag.AttrModer]);
            }
            if (this.tagList.ContainsKey(BuffTag.PropModer))
            {
                controler.propOutput.PropPlus((Property)tagList[BuffTag.PropModer]);
            }


        }



        /// <summary>
        /// 剩余回合数
        /// </summary>
        public int TurnRemain { get; private set; }

        /// <summary>
        /// 计时器读数方法,在回合交替时调用
        /// </summary>
        public virtual void CountDown()
        {
            TurnRemain--;
            if (TurnRemain == 0)
            {
                Expire();
            }
        }
        /// <summary>
        /// 终结
        /// </summary>
        public virtual void Expire()
        {
            Expired = true;
            //卸载属性修正
            if (this.tagList.ContainsKey(BuffTag.AttrModer))
            {
                controler.attrOutput.AttrRemove((Attribute)tagList[BuffTag.AttrModer]);
            }
            //
            if (this.tagList.ContainsKey(BuffTag.PropModer))
            {
                controler.propOutput.PropPlus((Property)tagList[BuffTag.PropModer]);
            }
            if (this.tagList.ContainsKey(BuffTag.Command))
            {
                holder.mapCommands.Remove((BaseCommand)tagList[BuffTag.Command]);
            }
        }

        /// <summary>
        /// 驱除
        /// </summary>
        public virtual void Dispose()
        {
            Expired = true;

        }

        /// <summary>
        /// Key:BuffTag,Value:其对应物
        /// </summary>
        public Dictionary<BuffTag, object> tagList;
        BaseChar giver;
    }

    public delegate void BuffAcivity(BasePO BuffHolder, BasePO BuffGiver);

    public class BuffControl
    {
        private BasePO holder;
        public List<BaseBuff> Buffs;
        public Attribute attrOutput;
        public Property propOutput;

        /// <summary>
        /// 护盾计算方式
        /// </summary>
        public float BarrierValueTotal
        {
            get
            {
                float barrier = 0;
                foreach (BaseBuff buf in Buffs)
                {
                    if (buf.tagList.ContainsKey(BuffTag.Barrier))
                    {
                        barrier += (float)buf.tagList[BuffTag.Barrier];
                    }

                }
                return barrier;
            }
        }
        #region BuffControl 初始化
        public BuffControl(BasePO holder)
        {
            this.holder = holder;
            Buffs = new List<BaseBuff>();
            attrOutput = new Attribute();
            propOutput = new Property();


        }
        #endregion

        /// <summary>
        /// 移除失效Buff
        /// </summary>
        public void RemoveUnavalibleBuff()
        {
            for (int i = Buffs.Count - 1; i >= 0; i--)
            {
                if (Buffs[i].Expired)
                {
                    Buffs.RemoveAt(i);
                }
            }
        }


        /// <summary>
        /// 消化护盾方法
        /// </summary>
        /// <param name="Damage">伤害值</param>
        /// <returns>护盾剩余量,负数则需要继续伤害吸收</returns>
        public float BarrierDamage(float Damage)
        {
            float barrier = BarrierValueTotal;
            foreach (BaseBuff buff in Buffs)
            {
                if (buff.tagList.ContainsKey(BuffTag.Barrier))
                {
                    float bar = (float)buff.tagList[BuffTag.Barrier];
                    if (Damage > bar)
                    {
                        barrier -= bar;
                        Damage -= bar;
                        buff.tagList[BuffTag.Barrier] = 0f;
                        buff.Dispose();
                    }
                    else
                    {
                        barrier -= Damage;
                        bar -= Damage;
                        buff.tagList[BuffTag.Barrier] = bar;
                        return 0;
                    }
                }
            }
            return Damage * -1;
        }


    }

    public enum BuffTag
    {
        增益, 减益, 增技能, 回合执行, 友善, 敌对, 物理, 法术, Barrier, AttrModer, PropModer,Command
    }
}
