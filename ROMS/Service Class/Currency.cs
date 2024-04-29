using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROMS
{
   public class Currency
    {
        public static string NumbersToWords(int inputNumber)
        {
            int inputNo =inputNumber;
            if (inputNo == 0)
                return "Zero";
            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }
            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };
            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs
            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0)
                    {
                        if (sb.ToString() !="")
                          sb.Append(" and ");
                         

                    }
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return "Rupees "+ sb.ToString().TrimEnd() + " only";
        }
        //public static string CurrencyToWord(string MyNumber)
        //{
        //    dynamic Temp = null;
        //    string Rupees = null;
        //    string Paisa = null;
        //    dynamic DecimalPlace = null;
        //    dynamic iCount = null;
        //    string Hundreds = null;
        //    string Words = null;
        //    string[] Place = new string[10];
        //    Place[0] = " Thousand ";
        //    Place[2] = " Lakh ";
        //    Place[4] = " Crore ";
        //    Place[6] = " Arab ";
        //    Place[8] = " Kharab ";
        //    // ERROR: Not supported in C#: OnErrorStatement

        //    // Convert MyNumber to a string, trimming extra spaces.
        //    MyNumber = Strings.Trim(Conversion.Str(MyNumber));

        //    // Find decimal place.
        //    DecimalPlace = Strings.InStr(MyNumber, ".");

        //    // If we find decimal place...
        //    if (DecimalPlace > 0)
        //    {
        //        // Convert Paisa
        //        Temp = Strings.Left(Strings.Mid(MyNumber, DecimalPlace + 1) + "00", 2);
        //        Paisa = " and " + ConvertTens(Temp) + " Paisa";

        //        // Strip off paisa from remainder to convert.
        //        MyNumber = Strings.Trim(Strings.Left(MyNumber, DecimalPlace - 1));
        //    }

        //    // Convert last 3 digits of MyNumber to ruppees in word.
        //    Hundreds = ConvertHundreds(Strings.Right(MyNumber, 3));
        //    // Strip off last three digits
        //    MyNumber = Strings.Left(MyNumber, Strings.Len(MyNumber) - 3);

        //    iCount = 0;
        //    while (!string.IsNullOrEmpty(MyNumber))
        //    {
        //        //Strip last two digits
        //        Temp = Strings.Right(MyNumber, 2);
        //        if (Strings.Len(MyNumber) == 1)
        //        {
        //            Words = ConvertDigit(Temp) + Place[iCount] + Words;
        //            MyNumber = Strings.Left(MyNumber, Strings.Len(MyNumber) - 1);

        //        }
        //        else
        //        {
        //            Words = ConvertTens(Temp) + Place[iCount] + Words;
        //            MyNumber = Strings.Left(MyNumber, Strings.Len(MyNumber) - 2);
        //        }
        //        iCount = iCount + 2;
        //    }

        //    return "Rupees " + Words + Hundreds + Paisa + " Only";

        //}

        //// Conversion for hundreds
        ////*****************************************
        //public static object ConvertHundreds(string MyNumber)
        //{
        //    object functionReturnValue = null;
        //    string Result = null;

        //    // Exit if there is nothing to convert.
        //    if (Conversion.Val(MyNumber) == 0)
        //        return functionReturnValue;

        //    // Append leading zeros to number.
        //    MyNumber = Strings.Right("000" + MyNumber, 3);

        //    // Do we have a hundreds place digit to convert?
        //    if (Strings.Left(MyNumber, 1) != "0")
        //    {
        //        Result = ConvertDigit(Strings.Left(MyNumber, 1)) + " Hundred ";
        //    }

        //    // Do we have a tens place digit to convert?
        //    if (Strings.Mid(MyNumber, 2, 1) != "0")
        //    {
        //        Result = Result + ConvertTens(Strings.Mid(MyNumber, 2));
        //    }
        //    else
        //    {
        //        // If not, then convert the ones place digit.
        //        Result = Result + ConvertDigit(Strings.Mid(MyNumber, 3));
        //    }

        //    functionReturnValue = Strings.Trim(Result);
        //    return functionReturnValue;
        //}

        //// Conversion for tens
        ////*****************************************
        //public static object ConvertTens(string MyTens)
        //{
        //    string Result = null;

        //    // Is value between 10 and 19?
        //    if (Conversion.Val(Strings.Left(MyTens, 1)) == 1)
        //    {
        //        switch (Conversion.Val(MyTens))
        //        {
        //            case 10:
        //                Result = "Ten";
        //                break;
        //            case 11:
        //                Result = "Eleven";
        //                break;
        //            case 12:
        //                Result = "Twelve";
        //                break;
        //            case 13:
        //                Result = "Thirteen";
        //                break;
        //            case 14:
        //                Result = "Fourteen";
        //                break;
        //            case 15:
        //                Result = "Fifteen";
        //                break;
        //            case 16:
        //                Result = "Sixteen";
        //                break;
        //            case 17:
        //                Result = "Seventeen";
        //                break;
        //            case 18:
        //                Result = "Eighteen";
        //                break;
        //            case 19:
        //                Result = "Nineteen";
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        // .. otherwise it's between 20 and 99.
        //        switch (Conversion.Val(Strings.Left(MyTens, 1)))
        //        {
        //            case 2:
        //                Result = "Twenty ";
        //                break;
        //            case 3:
        //                Result = "Thirty ";
        //                break;
        //            case 4:
        //                Result = "Forty ";
        //                break;
        //            case 5:
        //                Result = "Fifty ";
        //                break;
        //            case 6:
        //                Result = "Sixty ";
        //                break;
        //            case 7:
        //                Result = "Seventy ";
        //                break;
        //            case 8:
        //                Result = "Eighty ";
        //                break;
        //            case 9:
        //                Result = "Ninety ";
        //                break;
        //            default:
        //                break;
        //        }

        //        // Convert ones place digit.
        //        Result = Result + ConvertDigit(Strings.Right(MyTens, 1));
        //    }

        //    return Result;
        //}

        //public static object ConvertDigit(string MyDigit)
        //{
        //    object functionReturnValue = null;
        //    switch (Conversion.Val(MyDigit))
        //    {
        //        case 1:
        //            functionReturnValue = "One";
        //            break;
        //        case 2:
        //            functionReturnValue = "Two";
        //            break;
        //        case 3:
        //            functionReturnValue = "Three";
        //            break;
        //        case 4:
        //            functionReturnValue = "Four";
        //            break;
        //        case 5:
        //            functionReturnValue = "Five";
        //            break;
        //        case 6:
        //            functionReturnValue = "Six";
        //            break;
        //        case 7:
        //            functionReturnValue = "Seven";
        //            break;
        //        case 8:
        //            functionReturnValue = "Eight";
        //            break;
        //        case 9:
        //            functionReturnValue = "Nine";
        //            break;
        //        default:
        //            functionReturnValue = "";
        //            break;
        //    }
        //    return functionReturnValue;
        //}


    }
}
