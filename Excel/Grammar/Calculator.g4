grammar Calculator;

/*
* Parser Rules
*/

compileUnit : expression EOF;

expression :
    LPAREN expression RPAREN #ParenthesizedExpr
    | operatorToken=(MINUS | PLUS) expression #UnaryExpr
    | expression EXPONENT expression #ExponentialExpr
    | expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
    | expression operatorToken=(PLUS | MINUS) expression #AdditiveExpr
    | operatorToken=(MOD | DIV) LPAREN expression SEP expression RPAREN #ModDivExpr
    | INT #NumberExpr
    | IDENTIFIER #IdentifierExpr
    ;
/*
* Lexer Rules
*/

INT : ('0'..'9')+;
EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : ';';
LPAREN : '(';
RPAREN : ')';
MINUS : '-';
PLUS: '+';
MOD: 'mod';
DIV: 'div';
SEP: ',';

WS : [ \t\r\n] -> channel(HIDDEN);