using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    public class DynamicObject<TObject> : IDynamicMetaObjectProvider
        where TObject : class
    {
        protected static readonly Func<string, object> NullDefaults = (string name) => { return null; };
        protected readonly TObject _value;
        private readonly Func<string, object> _defaults;
        private readonly Func<TObject, string, object> _getter;
        private readonly Action<TObject, string, object> _setter;
        private readonly Func<TObject, string, object[], object> _invoke;

        protected DynamicObject(TObject value, Func<TObject, string, object> getter, Action<TObject, string, object> setter, Func<string, object> defaults, Func<TObject, string, object[], object> invoke)
        {
            _value = value;
            _getter = getter;
            _setter = setter;
            _defaults = defaults;
            _invoke = invoke;
        }

        #region - IDynamicMetaObjectProvider implementation -

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
        {
            return new MetaObject(parameter, _value, _getter, _setter, _defaults, _invoke);
        }

        #endregion - IDynamicMetaObjectProvider implementation -

        public class MetaObject : DynamicMetaObject
        {
            private readonly TObject _value;
            private readonly Func<string, object> _defaults;
            private readonly Func<TObject, string, object> _getter;
            private readonly Action<TObject, string, object> _setter;
            private readonly Func<TObject, string, object[], object> _invoke;

            public MetaObject(Expression expression, TObject value, Func<TObject, string, object> getter, Action<TObject, string, object> setter, Func<string, object> defaults, Func<TObject, string, object[], object> invoke)
                : base(expression, BindingRestrictions.Empty, value)
            {
                _value = value;
                _getter = getter;
                _setter = setter;
                _defaults = defaults;
                _invoke = invoke;
            }

            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                // Setup the Get method call expression
                var getter = Expression.Call(
                    instance: Expression.Convert(Expression, LimitType),
                    method: _getter.Method,
                    arguments: new Expression[]
                    {
                        Expression.Constant(binder.Name)
                    });

                // return a meta object to invoke Get later:
                return new DynamicMetaObject(
                    expression: getter,
                    restrictions: BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            }

            public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
            {
                string message = string.Format("Calling {0}({1})", binder.Name, string.Join(", ", args.Select(o => o.Value)));

                var methodCall = Expression.Call(
                    instance: Expression.Convert(Expression, LimitType),
                    method: _invoke.Method,
                    arguments: new Expression[]
                    {
                        Expression.Constant(message)
                    });

                var methodInfo = new DynamicMetaObject(
                    expression: methodCall,
                    restrictions: BindingRestrictions.GetTypeRestriction(Expression, LimitType));

                return methodInfo;
            }

            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                // Setup the Set method call expression
                var setter = Expression.Call(
                    instance: Expression.Convert(expression: Expression, type: LimitType),
                    method: _setter.Method,
                    arguments: new Expression[]
                    {
                        // First parameter is the name of the property to Set
                        Expression.Constant(binder.Name),

                        // Second parameter is the value
                        Expression.Convert(value.Expression, typeof(object))
                    });

                // return a meta object to invoke Set later:
                return new DynamicMetaObject(
                    expression: setter,
                    // setup the binding restrictions
                    restrictions: BindingRestrictions.GetTypeRestriction(Expression, LimitType));
            }
        }
    }
}
