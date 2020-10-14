using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 共通类,包含常数,通用公式
/// </summary>
public class CommonUtil
{
    /*
     * 目录
     * 
     * 1 常数
     * 
     * 2 方法
     * 
     * 
     */

    /*
     * 1 常数 START 
     */

    /// <summary>
    /// HP上线(MaxHp_Base)计算耐力系数
    /// </summary>
    public const float HPEnd_multi = 2.5f;

    /// <summary>
    /// HP上线(MaxHp_Base)计算力量系数
    /// </summary>
    public const float HPStr_multi = 1f;

    /// <summary>
    /// HP上线(MaxHp_Base)基数,即最低上线
    /// </summary>
    public const float HP_Base = 10f;

    /// <summary>
    /// AP上线(MaxAP_Base)计算耐力系数
    /// </summary>
    public const float APEND_multi = 2.5f;

    /// <summary>
    /// AP上线(MaxAP_Base)计算意志系数
    /// </summary>
    public const float APWIL_multi = 1f;

    /// <summary>
    /// AP上线(MaxAP_Base,法师用)计算意志系数
    /// </summary>
    public const float MPWIL_multi = 3f;

    /// <summary>
    /// AP上线(MaxAP_Base)基数,最低AP上线
    /// </summary>
    public const float AP_Base = 10f;

    /// <summary>
    /// AP回复基数
    /// </summary>
    public const float APRec_Base = 4f;

    /// <summary>
    /// AP回复基数,END回复系数
    /// </summary>
    public const float APRec_ENDMult = 0.5f;

    /// <summary>
    /// AP回复基数,WIL回复系数
    /// </summary>
    public const float APRec_WILMult = 0.5f;

    /// <summary>
    /// MP上线基数
    /// </summary>
    public const float MP_Base = 50f;

    /// <summary>
    /// MP上限,WIL系数
    /// </summary>
    public const float MP_WILMult = 10f;

    /// <summary>
    /// 物理抗性基数
    /// </summary>
    public const float PhyRes_Base = 0f;

    /// <summary>
    /// 物理抗性STR系数
    /// </summary>
    public const float PhyRes_STRMult = 1f;

    /// <summary>
    /// 精神抗性基数
    /// </summary>
    public const float PsyRes_Base = 0f;

    /// <summary>
    /// 精神抗性,WIL系数
    /// </summary>
    public const float PsyRes_WILMult = 1f;

    /// <summary>
    /// 冲击力修正基数
    /// </summary>
    public const float ImpPow_Base = 0f;

    /// <summary>
    /// 冲击力修正,力量系数
    /// </summary>
    public const float ImpPow_STRMult = 0.5f;

    /// <summary>
    /// 物品效果基数
    /// </summary>
    public const float ItmEff_Base = 0f;
    /// <summary>
    /// 物品效果智力系数
    /// </summary>
    public const float ItmEff_INTMult = 1f;

    /// <summary>
    /// 法术强度基数
    /// </summary>
    public const float SpPow_Base = 0f;
    /// <summary>
    /// 法术强度,智力系数
    /// </summary>
    public const float SpPow_INTMult = 1f;

    /// <summary>
    /// 精准基数
    /// </summary>
    public const float Accuracy_Base = 0f;
    /// <summary>
    /// 精准感知系数
    /// </summary>
    public const float Accuracy_PERMult = 0f;

    public const float Defence_Base = 0f;
    public const float Dodge_Base = 0f;
    public const float Critical_Base = 0f;
    public const float Mobility_Base = 4f;
    //public const float Barrier_Base = 0f;
    //public const float Shield_Base = 0f;
    public const float RecLvl_Base = 0f;
    public const float SnkLvl_Base = 0f;
    public const float ChargeLvl_Base = 0f;
    public const float Armor_Base = 0f;
    public const float DmgCut_Base = 0f;
    public const float Climb_Base = 0f;
    public const float Jump_Base = 0f;



    public const float Defence_PERMult = 0f;
    public const float Defence_AGIMult = 0f;
    public const float Dodge_AGIMult = 0f;
    public const float Critical_PERMult = 0f;

    public const float Critical_INTMult = 0f;

    public const float MovingDuration = 1f;
    /*
     * 1 常数 END 
     */

    /*
     * 2 方法 START 
     */


    /*
     * 2 方法 END
     */

}
