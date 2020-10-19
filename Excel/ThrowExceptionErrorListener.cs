using System;
using Antlr4.Runtime;

namespace Excel
{
    public class ThrowExceptionErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            throw new ArgumentException("Некоректний вираз");
        }

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            throw new ArgumentException("Некоректний вираз");
        }
    }
}