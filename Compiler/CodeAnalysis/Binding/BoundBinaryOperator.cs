using CFactorial.CodeAnalysis.Syntax;

namespace CFactorial.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryOperator
    {
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type type)
        : this(syntaxKind, kind, type, type, type)
        {
            
        }
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type operandtype, Type type)
        : this(syntaxKind, kind, operandtype, operandtype, type)
        {
            
        }
        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type leftType, Type rightType, Type type)
        {
            Syntaxkind = syntaxKind;
            Kind = kind;
            LeftType = leftType;
            RightType = rightType;
            Type = type;
        }

        public SyntaxKind Syntaxkind { get; }
        public BoundBinaryOperatorKind Kind { get; }
        public Type LeftType { get; }
        public Type RightType { get; }
        public Type OperandType { get; }
        public Type Type { get; }

        private static BoundBinaryOperator[] _operators = 
        {
            new BoundBinaryOperator(SyntaxKind.PlusToken, BoundBinaryOperatorKind.Addition, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.MinusToken, BoundBinaryOperatorKind.Subtraction, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.StarToken, BoundBinaryOperatorKind.Multiplication, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.SlashToken, BoundBinaryOperatorKind.Division, typeof(int)),
            
            new BoundBinaryOperator(SyntaxKind.EqualsEqualsToken, BoundBinaryOperatorKind.Equals, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.BangEqualsToken, BoundBinaryOperatorKind.NotEquals, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.AmpersandAmpersandToken, BoundBinaryOperatorKind.LogicalAnd, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.PipePipeToken, BoundBinaryOperatorKind.LogicalOr, typeof(bool)),
        };

        public static BoundBinaryOperator Bind(SyntaxKind syntaxKind, Type leftType, Type rightType)
        {
            foreach (var op in _operators)
            {
                if (op.Syntaxkind == syntaxKind && op.LeftType == leftType && op.RightType == rightType)
                    return op;
            }

            return null;
        }
    }
}