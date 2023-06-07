using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

class Class
{
    // 运算符
    enum Compute
    {
        add,
        sub,
        mul,
        div
    }

    // 获取运算符号
    static int GetSign(string expression)
    {
        int sign = 0;
        if (expression.Contains("+"))
        {
            sign = (int)Compute.add;
        }
        else if (expression.Contains("-"))
        {
            sign = (int)Compute.sub;
        }
        else if (expression.Contains('*'))
        {
            sign = (int)Compute.mul;
        }
        else if (expression.Contains("/"))
        {
            sign = (int)Compute.div;
        }
        return sign;
    }

    // 获取两个数字
    static void GetNumberFromExpression(string expression, ref float num1, ref float num2)
    {
        int signIndex = 0;  // 符号位置

        int sign = GetSign(expression);
        switch (sign)
        {
            case 0:     signIndex = expression.IndexOf('+');    break;
            case 1:     signIndex = expression.IndexOf('-');    break;
            case 2:     signIndex = expression.IndexOf('*');    break;
            case 3:     signIndex = expression.IndexOf('/');    break;
            default:    signIndex = -1;                         break;
        }

        num1 = float.Parse(expression.Substring(0, signIndex));
        num2 = float.Parse(expression.Substring(signIndex + 1));
    }

    // 加法
    static void Addition(string addition, ref float result)
    {
        float num1 = 0;
        float num2 = 0; // 加数

        GetNumberFromExpression(addition, ref num1, ref num2);
        result = num1 + num2;
    }

    // 减法
    static void Subtraction(string subtraction, ref float result)
    {
        float num1 = 0;
        float num2 = 0; // 加数

        GetNumberFromExpression(subtraction, ref num1, ref num2);
        result = num1 - num2;
    }

    // 乘法
    static void Multiplication(string multiplication, ref float result)
    {
        float num1 = 0;
        float num2 = 0; // 加数

        GetNumberFromExpression(multiplication, ref num1, ref num2);
        result = num1 * num2;
    }

    // 除法
    static void Division(string division, ref float result)
    {
        float num1 = 0;
        float num2 = 0; // 加数

        GetNumberFromExpression(division, ref num1, ref num2);
        result = num1 * num2;
    }

    // 一次流程
    static int OnceProcess(string inputValue, ref float result)
    {
        Console.Write("（退出输入exit）输入算式：");
        inputValue = Console.ReadLine();

        // 检查是否退出
        int state = 0;
        if(inputValue == "exit")
        {
            state = 1;
            return state;
        }

        int sign = GetSign(inputValue);
        switch (sign)
        {
            case 0: Addition        (inputValue, ref result); break;
            case 1: Subtraction     (inputValue, ref result); break;
            case 2: Multiplication  (inputValue, ref result); break;
            case 3: Division        (inputValue, ref result); break;
            default: ; break;
        }
        Console.WriteLine($"{inputValue}的结果是{result}。");

        return state;
    }

    // 主函数
    static void Main(string[] args)
    {
        string? inputValue = null;
        float result = 0;
        int state = 0;

        while(true)
        {
            state = OnceProcess(inputValue, ref result);
            if(state == 1)
            {
                break;
            }
        }

    }

}