using Antlr4.Runtime;
using Excel.Grammar;

namespace Excel
{
    public class Calculator
    {
        public static int Evaluate(string expression)
        {
            var lexer = new CalculatorLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());
            
            var tokens = new CommonTokenStream(lexer);
            var parser = new CalculatorParser(tokens);

            var tree = parser.compileUnit();
            
            var visitor = new ExcelVisitor();

            return visitor.Visit(tree);
        }
    }
}