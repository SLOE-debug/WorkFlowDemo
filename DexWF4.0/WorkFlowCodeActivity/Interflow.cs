using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Windows;

namespace DexWF4._0.WorkFlowCodeActivity
{

    public sealed class Interflow<T> : NativeActivity<T>
    {
        public InArgument<string> Name { get; set; }

        protected override bool CanInduceIdle { get { return true; } }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。

        protected override void Execute(NativeActivityContext context)
        {
            string BookName = context.GetValue(Name);
            var FlowID = int.Parse(BookName.Split('_')[0]);
            if (Guid.Parse(new DAL.FlowService().GetFlowByID(FlowID).F_FlowInstanceID) == default)
            {
                new DAL.FlowService().UpdateFlowInstanceID(FlowID, context.WorkflowInstanceId.ToString());
            }
            context.CreateBookmark(BookName, new BookmarkCallback(CallBlack));
        }

        void CallBlack(NativeActivityContext context, Bookmark bookmark, object value)
        {
            if (typeof(T) == typeof(int))
            {
                Result.Set(context, int.Parse(value.ToString()));
                return;
            }
            else if (typeof(T) == typeof(string))
            {
                Result.Set(context, value.ToString());
                return;
            }
            Result.Set(context, (T)value);
        }
    }
}
