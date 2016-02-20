using System.Linq.Expressions;

namespace DAL
{
    public class ExpressionModifier<T> : ExpressionVisitor
    {
        ParameterExpression _parameter;

        public ExpressionModifier(ParameterExpression parameter)
        {
            _parameter = parameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.MemberType == System.Reflection.MemberTypes.Property)
            {
                MemberExpression memberExpression = null;
                var memberName = node.Member.Name;
                var otherMember = typeof(T).GetProperty(memberName);
                memberExpression = Expression.Property(Visit(node.Expression), otherMember);
                return memberExpression;
            }
            else
            {
                return base.VisitMember(node);
            }
        }
    }
}
