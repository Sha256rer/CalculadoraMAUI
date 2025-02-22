
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

namespace Calculator;

public static class Calculator
{
    public static double Calculate(double value1, double value2, string mathOperator)
    {
        double result = 0;

        switch (mathOperator)
        {
            case "÷":
                result = value1 / value2;
                break;
            case "×":
                result = value1 * value2;
                break;
            case "+":
                result = value1 + value2;
                break;
            case "-":
                result = value1 - value2;
                break;
        }

        return result;
    }
    /// <summary>
    /// Metodo que tranforma un numero decimal en binario
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String TransformBin(int value) {
        Debug.WriteLine("Viene De: " + value );
        String resS = (Convert.ToString(value, 2));
        Debug.WriteLine("Sale String : " + resS);
       
        return resS;
    }
    /// <summary>
    /// Metodo que transforma un numero binario en un decimal
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String TransformDec(int value)
    {
        String s=  value.ToString();
        int test = Convert.ToInt32(s, 2);
        Debug.WriteLine("Viene Bin: " + value);
        String res = Convert.ToString(test, 10);
        Debug.WriteLine("Sale: " + test);
        return res;
    }

}

public static class DoubleExtensions
{
    public static string ToTrimmedString(this double target, string decimalFormat)
    {
        string strValue = target.ToString(decimalFormat); //Get the stock string

        //If there is a decimal point present
        if (strValue.Contains("."))
        {
            //Remove all trailing zeros
            strValue = strValue.TrimEnd('0');

            //If all we are left with is a decimal point
            if (strValue.EndsWith(".")) //then remove it
                strValue = strValue.TrimEnd('.');
        }

        return strValue;
    }
}
