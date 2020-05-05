using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Windows;
using DexWF4._0.WorkFlowActivity;

namespace DexWF4._0.WorkFlowCodeActivity
{
    public sealed class RunChildrenActivity : NativeActivity
    {
        public Activity SubActivity { get; set; }

        protected override bool CanInduceIdle { get { return true; } }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(NativeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            context.ScheduleActivity(SubActivity, Completed);
        }
        void Completed(NativeActivityContext SubContext, ActivityInstance instance)
        {
            Console.WriteLine("子流程结束");
        }
    }
}
