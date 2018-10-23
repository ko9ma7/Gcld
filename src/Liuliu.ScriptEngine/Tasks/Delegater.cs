using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Liuliu.ScriptEngine.Tasks
{
    /// <summary>
    /// 委托辅助操作类
    /// </summary>
    public static class Delegater
    {
        /// <summary>
        /// 重复执行指定代码直到成功
        /// </summary>
        /// <param name="trueFunc">要执行的返回成功的操作</param>
        /// <param name="failAction">每次执行失败时，执行的动作</param>
        /// <param name="maxCount">重试的最大次数，0为一直重试</param>
        /// <returns>最终是否成功</returns>
        public static bool WaitTrue(Func<bool> trueFunc, Action failAction = null, int maxCount = 0)
        {
            failAction = failAction ?? (() => { });
            if (maxCount == 0)
            {
                while (!trueFunc())
                {
                    failAction();
                }
                return true;
            }
            int count = 0;
            while (!trueFunc() && count < maxCount)
            {
                failAction();
                count++;
            }
            return count < maxCount;
        }


        /// <summary>
        /// 重复执行指定代码直到成功，满足指定条件时立即失败
        /// </summary>
        /// <param name="trueFunc">要执行的返回成功的操作</param>
        /// <param name="failAction">每次执行失败时，执行的动作</param>
        /// <param name="breakFunc">当此代码执行成功时，立即中断并返回失败</param>
        /// <param name="maxCount">重试的最大次数，0为一直重试</param>
        /// <returns>最终是否成功</returns>
        //public static bool WaitTrue(Func<bool> trueFunc, Action failAction, Func<bool> breakFunc, int maxCount = 0)
        //{
        //    failAction = failAction ?? (() => { });
        //    if (maxCount == 0)
        //    {
        //        while (!trueFunc())
        //        {
        //            if (breakFunc())
        //            {
        //                return false;
        //            }
        //            failAction();
        //        }
        //        return true;
        //    }
        //    int count = 0;
        //    while (!trueFunc() && count < maxCount)
        //    {
        //        if (breakFunc())
        //        {
        //            return trueFunc();
        //        }
        //        failAction();
        //        count++;
        //    }
        //    return count < maxCount;
        //}


        /// <summary>
        /// 满足指定条件时立即成功,否则重复执行指定代码直到指定条件出现
        /// </summary>
        /// <param name="trueFunc">要执行的返回成功的操作</param>
        /// <param name="trueFlag">要判断已经成功的操作</param>
        /// <param name="failAction">每次执行失败时，执行的动作</param>
        /// <param name="milliseconds">多长时间内出现条件则成功ms</param>
        /// <returns></returns>
        public static bool WaitTrue(Func<bool> trueFunc,Func<bool> trueFlag,Action failAction,long milliseconds=4000,int maxCount=0)
        {
            failAction = failAction ?? (() => { });
            //如果trueFlag存在则表示已经在指定画面,或者取的标志存在多个
            if (trueFlag())
            {
                Debug.WriteLine("Err:已经在指定画面,或者取的标志存在多个");
                return true;
            }
            Stopwatch sw = new Stopwatch();
            int i = 0;
            if (maxCount==0)
            {
                while(true)
                {  //一直运行到成功为止
                    while (!trueFunc()&&i<10)
                    {
                        failAction();
                        i++;
                    }
                    if (i >=10)
                    {
                        Debug.WriteLine("要返回真的操作,无法返回真!");
                        return false;
                    }
                    else
                    {
                        Debug.WriteLine("要返回真的操作,返回成功了!");
                    }
                    sw.Start();
                    while (sw.ElapsedMilliseconds <= milliseconds)
                    {
                       
                        if (trueFlag())
                        {
                            Debug.WriteLine("出现成功的标志了,延时:"+sw.ElapsedMilliseconds);
                            sw.Stop();
                            sw.Reset();
                            return true;
                        }
                    }
                    sw.Stop();
                    sw.Reset();
                    i = 0;
                    Debug.WriteLine(milliseconds + "ms后还没有出现,操作失败了,网络延时严重!");
                }
            }
            int count = 0;
            i = 0;
            while(count < maxCount)
            {
                while (!trueFunc()&&i<10)
                {
                    failAction();
                    i++;
                }
                if (i >= 10)
                {
                    Debug.WriteLine("要返回真的操作,无法返回真!");
                    return false;
                }
                sw.Start();
                while (sw.ElapsedMilliseconds <= milliseconds)
                {
                    if (trueFlag())
                    {
                        sw.Stop();
                        sw.Reset();
                        return true;
                    }
                }
                sw.Stop();
                sw.Reset();
                i = 0;
                Debug.WriteLine(milliseconds + "ms后还没有出现,操作失败了,网络延时严重!");
            }
            return count < maxCount;
        }
    }
}
