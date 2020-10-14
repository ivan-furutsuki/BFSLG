using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command;
using Map;

namespace Character
{
    public class BaseChar : BasePO
    {
        /*
         * 目录
         * 
         *  1. 属性
         *      1.1 六维属性_Attribute(一级属性)
         *          1.1.1 力量
         *          1.1.2 感知
         *          1.1.3 知能
         *          1.1.4 耐力
         *          1.1.5 迅捷
         *          1.1.6 意志
         *      1.2 通用数值_Property(二级属性,参考基本规则Sheet二级属性(Property))
         *          1.2.1 HP上限
         *          1.2.2 AP上限
         *          1.2.3 MP上限
         *          等
         *      1.3 常变数值
         *          1.3.1
         *      1.X 地图方位(继承自Base物体)
         *  2. 地图指令
         * 
         */



        #region 1.1 六维属性 Attribute
        /// <summary>
        /// 力量(Strength最终结果)
        /// </summary>
        public virtual int STR
        {
            get
            {
                return attrBase.STR + buffControl.attrOutput.STR;
            }
        }
        /// <summary>
        /// 感知(Perception最终结果)
        /// </summary>
        public virtual int PER
        {
            get
            {
                return attrBase.PER + buffControl.attrOutput.PER;
            }
        }
        /// <summary>
        /// 知能(Inteligence最终结果)
        /// </summary>
        public virtual int INT
        {
            get
            {
                return attrBase.INT + buffControl.attrOutput.INT;
            }
        }
        /// <summary>
        /// 耐力(endurance最终结果)
        /// </summary>
        public virtual int END
        {
            get
            {
                return attrBase.END + buffControl.attrOutput.END;
            }
        }
        /// <summary>
        /// 迅捷(Agility最终结果)
        /// </summary>
        public virtual int AGI
        {
            get
            {
                return attrBase.AGI + buffControl.attrOutput.AGI;
            }
        }
        /// <summary>
        /// 意志(Will最终结果)
        /// </summary>
        public virtual int WIL
        {
            get
            {
                return attrBase.WIL + buffControl.attrOutput.WIL;
            }
        }
        /// <summary>
        /// 该角色的基础数值
        /// </summary>
        protected Attribute attrBase;

        #endregion


        #region 1.2 通用数值 
        /// <summary>
        /// HP上限
        /// </summary>
        public virtual float HPMax
        {
            get
            {
                return CommonUtil.HP_Base + END * CommonUtil.HPEnd_multi
                    + STR * CommonUtil.HPStr_multi
                    + buffControl.propOutput.HPMax;
            }
        }

        /// <summary>
        /// AP上限
        /// </summary>
        public virtual float APMax
        {
            get
            {
                return CommonUtil.AP_Base
                    + END * CommonUtil.APEND_multi
                    //+ WIL * CommonUtil.APWIL_multi
                    + buffControl.propOutput.APMax;
            }
        }

        public virtual float APRecover
        {
            get
            {
                return CommonUtil.APRec_Base
                    + CommonUtil.APRec_ENDMult * END
                    + CommonUtil.APRec_WILMult * WIL
                    + buffControl.propOutput.APRecover;
            }
        }

        /// <summary>
        /// MP上限
        /// </summary>
        public virtual float MPMax
        {
            get
            {
                return CommonUtil.MP_Base
                    + CommonUtil.MP_WILMult * WIL
                    + buffControl.propOutput.MPMax;
            }
        }

        /// <summary>
        /// 物理抗性
        /// </summary>
        public virtual float PhyRes
        {
            get
            {
                return CommonUtil.PhyRes_Base
                    + CommonUtil.PhyRes_STRMult
                    + buffControl.propOutput.PhyRes;
            }
        }


        /// <summary>
        /// 精神抗性
        /// </summary>
        public virtual float PsyRes
        {
            get
            {
                return CommonUtil.PsyRes_Base
                    + CommonUtil.PsyRes_WILMult * WIL
                    + buffControl.propOutput.PsyRes;
            }
        }

        /// <summary>
        /// 冲击修正
        /// </summary>
        public virtual float ImpPow
        {
            get
            {
                return CommonUtil.ImpPow_Base
                   + CommonUtil.ImpPow_STRMult * STR
                   + buffControl.propOutput.ImpPow;
            }
        }

        public virtual float ItmEff
        {
            get
            {
                return CommonUtil.ItmEff_Base
                    + CommonUtil.ItmEff_INTMult * INT
                    + buffControl.propOutput.ItmEff;
            }
        }

        public virtual float SpPow
        {
            get
            {
                return CommonUtil.SpPow_Base 
                    + CommonUtil.SpPow_INTMult * INT
                    + buffControl.propOutput.SpPow;
            }
        }
        public virtual float Accuracy
        {
            get
            {
                return CommonUtil.Accuracy_Base 
                    +CommonUtil.Accuracy_PERMult* PER
                    + buffControl.propOutput.Accuracy;
            }
        }
        public virtual float Defence
        {
            get
            {
                return CommonUtil.Defence_Base
                    + CommonUtil.Defence_PERMult * PER
                    + CommonUtil.Defence_AGIMult * AGI
                    + buffControl.propOutput.Defence;

            }
        }
        public virtual float Dodge
        {
            get
            {
                return CommonUtil.Dodge_Base +
                    CommonUtil.Dodge_AGIMult * AGI
                    + buffControl.propOutput.Dodge;
            }
        }
        public virtual float Critical
        {
            get
            {
                return CommonUtil.Critical_Base
                    + CommonUtil.Critical_PERMult * PER
                    + CommonUtil.Critical_INTMult * INT
                    + buffControl.propOutput.Critical;
            }
        }
        public virtual float MobilityMax
        {
            get
            {
                return CommonUtil.Mobility_Base + buffControl.propOutput.MobilityMax;
            }
        }


        public virtual float RecLvl
        {
            get
            {
                return CommonUtil.RecLvl_Base + buffControl.propOutput.RecLvl;
            }
        }
        public virtual float SnkLvl
        {
            get
            {
                return CommonUtil.SnkLvl_Base + buffControl.propOutput.SnkLvl;
            }
        }
        public virtual float ChargeLvl
        {
            get
            {
                return CommonUtil.ChargeLvl_Base + buffControl.propOutput.ChargeLvl;
            }
        }
        public virtual float Armor
        {
            get
            {
                return CommonUtil.Armor_Base + buffControl.propOutput.Armor;
            }
        }
        public virtual float DmgCut
        {
            get
            {
                return CommonUtil.DmgCut_Base + buffControl.propOutput.DmgCut;
            }
        }
        public virtual float Climb
        {
            get
            {
                return CommonUtil.Climb_Base + buffControl.propOutput.Climb;
            }
        }
        public virtual float Jump
        {
            get
            {
                return CommonUtil.Jump_Base + buffControl.propOutput.Jump;
            }
        }





        #endregion

        #region 常变数值
        /// <summary>
        /// 护盾
        /// </summary>
        public virtual float Barrier
        {
            get
            {
                return buffControl.BarrierValueTotal;
            }
        }
        public bool UnderBarrier
        {
            get
            {
                return buffControl.BarrierValueTotal >= 0;
            }
        }

        public float Mobility
        {
            get;private set;
        }

        public virtual void TakeDamage(float damageTaken)
        {
            float barCheck = 0;
            if (UnderBarrier)
            {
                barCheck = buffControl.BarrierDamage(damageTaken);
            }

            hp += barCheck;
        }
        #endregion



        #region 1.X 地图方位

        #endregion


        /*
         *  2. 地图指令 START
         */
        /// <summary>
        /// 该角色持有的地图指令
        /// </summary>
        public List<BaseCommand> mapCommands;
        /*
         *  2. 地图指令 END
         */


        // Start is called before the first frame update
        void Start()
        {
            buffControl = new BuffControl(this);
        }

        // Update is called once per frame
        void Update()
        {

        }

    }

    /// <summary>
    /// 六维属性结构体,用于便利的组成基数+Buff的计算结构
    /// </summary>
    public class Attribute
    {
        #region fields数值
        /// <summary>
        /// 力量
        /// </summary>
        public int STR = 0;
        /// <summary>
        /// 感知
        /// </summary>
        public int PER = 0;
        /// <summary>
        /// 知能
        /// </summary>
        public int INT = 0;
        /// <summary>
        /// 耐力
        /// </summary>
        public int END = 0;
        /// <summary>
        /// 迅捷
        /// </summary>
        public int AGI = 0;
        /// <summary>
        /// 意志
        /// </summary>
        public int WIL = 0;
        #endregion
        /// <summary>
        /// 数值的加算
        /// </summary>
        /// <param name="moder"></param>
        public void AttrPlus(Attribute moder)
        {
            this.STR += moder.STR;
            this.PER += moder.PER;
            this.INT += moder.INT;
            this.END += moder.END;
            this.AGI += moder.AGI;
            this.WIL += moder.WIL;
        }

        /// <summary>
        /// 移除数值的影响
        /// </summary>
        /// <param name="moder"></param>
        public void AttrRemove(Attribute moder)
        {
            this.STR -= moder.STR;
            this.PER -= moder.PER;
            this.INT -= moder.INT;
            this.END -= moder.END;
            this.AGI -= moder.AGI;
            this.WIL -= moder.WIL;
        }
    }

    /// <summary>
    /// 直接属性,二级属性
    /// </summary>
    public class Property
    {
        #region fields数值
        /// <summary>
        /// HP上限
        /// </summary>
        public float HPMax;
        /// <summary>
        /// 行动力上限
        /// </summary>
        public float APMax;
        /// <summary>
        /// 行动力回复
        /// </summary>
        public float APRecover;
        /// <summary>
        /// 精神力上限
        /// </summary>
        public float MPMax;
        /// <summary>
        /// 物理抗性
        /// </summary>
        public float PhyRes;
        /// <summary>
        /// 精神抗性
        /// </summary>
        public float PsyRes;
        /// <summary>
        /// 冲击强化
        /// </summary>
        public float ImpPow;
        /// <summary>
        /// 物品效果
        /// </summary>
        public float ItmEff;
        /// <summary>
        /// 法强
        /// </summary>
        public float SpPow;
        /// <summary>
        /// 命中
        /// </summary>
        public float Accuracy;
        /// <summary>
        /// 防御性
        /// </summary>
        public float Defence;
        /// <summary>
        /// 闪避性
        /// </summary>
        public float Dodge;
        /// <summary>
        /// 暴击率
        /// </summary>
        public float Critical;

        /// <summary>
        /// 侦察等级
        /// </summary>
        public float RecLvl;
        /// <summary>
        /// 潜行等级
        /// </summary>
        public float SnkLvl;
        /// <summary>
        /// 冲锋强度
        /// </summary>
        public float ChargeLvl;
        /// <summary>
        /// 护甲值
        /// </summary>
        public float Armor;
        /// <summary>
        /// 伤害减免
        /// </summary>
        public float DmgCut;
        /// <summary>
        /// 移动力
        /// </summary>
        public float MobilityMax;
        /// <summary>
        /// 攀爬力
        /// </summary>
        public float Climb;
        /// <summary>
        /// 跃下力
        /// </summary>
        public float Jump;
        #endregion
        public void PropPlus(Property moder)
        {
            this.HPMax += moder.HPMax;
            this.APMax += moder.APMax;
            this.APRecover += moder.APRecover;
            this.MPMax += moder.MPMax;
            this.PhyRes += moder.PhyRes;
            this.PsyRes += moder.PsyRes;
            this.ImpPow += moder.ImpPow;
            this.ItmEff += moder.ItmEff;
            this.SpPow += moder.SpPow;
            this.Accuracy += moder.Accuracy;
            this.Defence += moder.Defence;
            this.Dodge += moder.Dodge;
            this.Critical += moder.Critical;
            this.MobilityMax += moder.MobilityMax;
            this.RecLvl += moder.RecLvl;
            this.SnkLvl += moder.SnkLvl;
            this.ChargeLvl += moder.ChargeLvl;
            this.Armor += moder.Armor;
            this.DmgCut += moder.DmgCut;
            this.Climb += moder.Climb;
            this.Jump += moder.Jump;
        }

        public void PropRemove(Property moder)
        {
            this.HPMax -= moder.HPMax;
            this.APMax -= moder.APMax;
            this.APRecover -= moder.APRecover;
            this.MPMax -= moder.MPMax;
            this.PhyRes -= moder.PhyRes;
            this.PsyRes -= moder.PsyRes;
            this.ImpPow -= moder.ImpPow;
            this.ItmEff -= moder.ItmEff;
            this.SpPow -= moder.SpPow;
            this.Accuracy -= moder.Accuracy;
            this.Defence -= moder.Defence;
            this.Dodge -= moder.Dodge;
            this.Critical -= moder.Critical;
            this.MobilityMax -= moder.MobilityMax;
            this.RecLvl -= moder.RecLvl;
            this.SnkLvl -= moder.SnkLvl;
            this.ChargeLvl -= moder.ChargeLvl;
            this.Armor -= moder.Armor;
            this.DmgCut -= moder.DmgCut;
            this.Climb -= moder.Climb;
            this.Jump -= moder.Jump;
        }
    }

}

