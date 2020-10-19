using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Excel.Grammar;

namespace Excel
{
    class ExcelVisitor : CalculatorBaseVisitor<int>
    {
        private Dictionary<string, int> tableIdentifier = new Dictionary<string, int>();

        public override int VisitCompileUnit(CalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override int VisitNumberExpr(CalculatorParser.NumberExprContext context)
        {
            var result = int.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        public override int VisitIdentifierExpr(CalculatorParser.IdentifierExprContext context)
        {
            var result = context.GetText();
            int value;
            return (tableIdentifier.TryGetValue(result, out value)) 
                ? value 
                : 0;
        }

        public override int VisitParenthesizedExpr(CalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override int VisitExponentialExpr(CalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            
            Debug.WriteLine("{0} ^ {1}", left, right);
            return (int)System.Math.Pow(left, right);
        }

        public override int VisitAdditiveExpr(CalculatorParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == CalculatorLexer.PLUS)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            Debug.WriteLine("{0} - {1}", left, right);
            return left - right;
        }

        public override int VisitMultiplicativeExpr(CalculatorParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == CalculatorLexer.MULTIPLY)
            {
                Debug.WriteLine("{0} * {1}", left, right);
                return left * right;
            }
            Debug.WriteLine("{0} / {1}", left, right);
            return left / right;
        }

        public override int VisitUnaryExpr([NotNull] CalculatorParser.UnaryExprContext context)
        {
            var result = int.Parse(context.GetText());
            return result;
        }

        public override int VisitModDivExpr([NotNull] CalculatorParser.ModDivExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            return context.operatorToken.Type == CalculatorLexer.MOD
                ? left % right
                : left / right;
        }

        private int WalkLeft(CalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CalculatorParser.ExpressionContext>(0));
        }
        
        private int WalkRight(CalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CalculatorParser.ExpressionContext>(1));
        }
    }
}