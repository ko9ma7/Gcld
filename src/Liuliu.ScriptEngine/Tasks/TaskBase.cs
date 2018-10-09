// -----------------------------------------------------------------------
//  <copyright file="TaskBase.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-03 17:45</last-date>
// -----------------------------------------------------------------------

using Liuliu.ScriptEngine.Models;
using System.Diagnostics;

namespace Liuliu.ScriptEngine.Tasks
{
    /// <summary>
    /// 任务基类，基派生类是任务执行的具体内容
    /// </summary>
    public abstract class TaskBase
    {
        protected TaskBase(TaskContext context)
        {
            TaskContext = context;
            Role = context.Role;
            Dm = context.Role.Window.Dm;
        }

        public IRole Role { get; }
        public DmPlugin Dm { get; }

        public TaskContext TaskContext { get; }

        public string Name
        {
            get { return TaskContext.Function.Name; }
        }

        /// <summary>
        /// 获取 是否可以最小化
        /// </summary>
        public virtual bool CanMin
        {
            get { return TaskContext.Role.Window.Dm.IsFree; }
        }

        protected virtual TaskResult CanRun(TaskContext context)
        {
            return TaskResult.Success;
        }

        /// <summary>
        /// 重写以实现任务步骤的初始化
        /// </summary>
        protected abstract TaskStep[] StepsInitialize();

        /// <summary>
        /// 获取当前任务步骤序号
        /// </summary>
        /// <param name="context">任务上下文</param>
        /// <returns>返回当前所在步骤序号</returns>
        protected abstract int GetStepIndex(TaskContext context);

        /// <summary>
        /// 重写以实现任务启动前的任务
        /// </summary>
        /// <param name="context">任务上下文</param>
        protected virtual void OnStarting(TaskContext context)
        { }

        /// <summary>
        /// 重写以实现任务停止前的任务
        /// </summary>
        /// <param name="context">任务上下文</param>
        protected virtual void OnStopping(TaskContext context)
        { }

        public TaskResult Run()
        {
            TaskResult result = CanRun(TaskContext);
            if (result.ResultType != TaskResultType.Success)
            {
                return result;
            }
            //_context.Role.Window.LockInput(InputLockType.Mouse);
            //任务启动前的任务
            OnStarting(TaskContext);
            //初始化任务步骤,获取执行到哪一步
            TaskContext.TaskSteps = StepsInitialize();
            TaskContext.StepIndex = GetStepIndex(TaskContext);
            if (TaskContext.StepIndex == 0)
            {
                return new TaskResult(TaskResultType.Fail, "获取任务执行步骤时出错");
            }
            while (true)
            {
                TaskStep step = TaskContext.TaskSteps[TaskContext.StepIndex - 1];
                Debug.WriteLine("执行步骤" + TaskContext.StepIndex + ":" + step.Name);
                //执行任务步骤
                result = step.RunFunc(TaskContext);
                if (result.Stopping)
                {
                    return result;
                }
                if (result.ResultType == TaskResultType.Jump)
                {
                    continue;
                }
                TaskContext.StepIndex++;
                if (TaskContext.StepIndex > TaskContext.TaskSteps.Length)
                {
                    //TaskContext.StepIndex = 1;
                    return new TaskResult(TaskResultType.Finished,"任务执行步骤已经完成");
                }
            }
         

        }

        public void Stop()
        {
            //任务结束后要做的任务
            OnStopping(TaskContext);
            IRole role = TaskContext.Role;
            //if (!role.IsAlive && role.IsMoving())
            //{
            //    role.Window.Dm.MoveToClick(400, 300);
            //}
            //role.Window.LockInput(InputLockType.None);
        }
    }
}