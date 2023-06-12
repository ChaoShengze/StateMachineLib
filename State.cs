
namespace StateMachineLib
{
    /// <summary>
    /// 状态，包含Before、Now、After三个阶段
    /// </summary>
    public class State
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        public string StateName = "UNNAMED";
        /// <summary>
        /// 状态对象的所处状态
        /// </summary>
        public StateStage StateStage = StateStage.INACTIVE;
        /// <summary>
        /// 正式进入某个状态前的准备工作
        /// </summary>
        public virtual void BeforeStateChange() 
        {
            StateStage = StateStage.BEFORE;
        }
        /// <summary>
        /// 处于某个状态
        /// </summary>
        public virtual void NowStateChange()
        {
            StateStage = StateStage.NOW;
        }
        /// <summary>
        /// 离开或者准备进入一个新状态前的资源释放和收尾工作
        /// </summary>
        public virtual void AfterStateChange()
        {
            StateStage = StateStage.AFTER;
        }
    }

    /// <summary>
    /// 状态阶段
    /// </summary>
    public enum StateStage
    { 
        /// <summary>
        /// 未激活
        /// </summary>
        INACTIVE,
        /// <summary>
        /// 正式进入某个状态前，此阶段主要进行准备工作
        /// </summary>
        BEFORE,
        /// <summary>
        /// 处于某个状态
        /// </summary>
        NOW,
        /// <summary>
        /// 离开或者准备进入一个新状态前，主要进行资源释放和收尾工作
        /// </summary>
        AFTER
    }
}
