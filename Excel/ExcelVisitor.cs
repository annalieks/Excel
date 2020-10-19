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
    class ExcelVisitor : CalculatorBaseVisitor<double>
    {
        public override double VisitCompileUnit(CalculatorParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(CalculatorParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        public override double VisitParenthesizedExpr(CalculatorParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(CalculatorParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            
            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(CalculatorParser.AdditiveExprContext context)
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

        public override double VisitMultiplicativeExpr(CalculatorParser.MultiplicativeExprContext context)
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

        public override double VisitUnaryExpr([NotNull] CalculatorParser.UnaryExprContext context)
        {
            var result = WalkLeft(context);

            if(context.operatorToken.Type == CalculatorLexer.MINUS)
            {
                Debug.WriteLine("-{0}", result);
                return -result;
            }
            Debug.WriteLine("{0}", result);
            return result;
        }

        public override double VisitModDivExpr([NotNull] CalculatorParser.ModDivExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            return context.operatorToken.Type == CalculatorLexer.MOD
                ? left % right
                : (int)left / (int)right;
        }

        private double WalkLeft(CalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CalculatorParser.ExpressionContext>(0));
        }
        
        private double WalkRight(CalculatorParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CalculatorParser.ExpressionContext>(1));
        }
    }
}