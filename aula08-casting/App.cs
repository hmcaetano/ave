using System;

class Program{

    void conv1(Object r) { 
        /*
         *  casting explicito => geração da instrução IL castclass
         */
        String str = (String) r;
        /*
         * casting implícito => copia normal entre duas variaveis
         */
        Object r2 = str;
    }

    void conv2(Object r)
    {
        /*
         * gera o operador isinst
         */
        String str = r as String;

    }

    /*
     * Resultado igual ao de conv2, MAS MENOS eficiente.
     */
    void conv3(Object r)
    {
        String str = null;
        
        if (r is String) { // => gera o isinst

            str = (String) r; // => gera o castclass
        }

    }

    static void Main(){
        
	}

}