using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Map;

/*
 *  该文件记录了[指令战术][Buff]及
 */

namespace Command
{
    /// <summary>
    /// 基本指令结构,指令指的是:角色在地图上可执行的命令
    /// </summary>
    public class BaseCommand
    {
        public static BaseCommand GetNewCommand(string commandId)
        {
            switch (commandId)
            {
                case "2":
                    break;
                default:
                    break;

            }

            return new BaseCommand();
        }

        

        /// <summary>
        /// 指令的执行者(持有者)
        /// </summary>
        protected BasePO actor;

        /// <summary>
        /// 执行者所在地
        /// </summary>
        protected Square standing;

        public string CommandName
        {
            get; private set;
        }

        protected string CommandId;

        public virtual Result Plan(Square targetPosition)
        {
            return new Result();
        }

        public virtual Result Plan(BasePO target)
        {
            return new Result();
        }

        public virtual Result Excute()
        {
            return new Result();
        }



        /// <summary>
        /// 返回可以释放指令的目标格子范围,如射程的判定等
        /// </summary>
        /// <returns></returns>
        public virtual List<Square> CommandRangeJudge()
        {
            return null;
        }

        protected virtual void Initial()
        {

        }

    }

    public class Action
    {
    }

    /// <summary>
    /// 行动结果
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 行动是否成功
        /// </summary>
        public bool Succes;
        /// <summary>
        /// 结果描述
        /// </summary>
        public ResultTag Tag;
        /// <summary>
        /// 行动对数值的影响
        /// </summary>
        public float Effect;

    }

    public enum CommandTag
    {
        CharaTarget, SqureTarget,
    }

    public enum ResultTag
    {
        
    }

}






