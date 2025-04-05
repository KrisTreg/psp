using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Порядковый номер в десятичной системе
        int orderNumber = 12;
        // Преобразуем в двоичное число (пятиразрядное)
        string binaryString = Convert.ToString(orderNumber, 2).PadLeft(5, '0');
        Console.WriteLine($"Пятиразрядное двоичное число: {binaryString}");

        // Кодирование
        string nrz = EncodeNRZ(binaryString);
        string nrzi = EncodeNRZI(binaryString);
        string ami = EncodeAMI(binaryString);
        string manchester = EncodeManchester(binaryString);

        // Вывод результатов
        Console.WriteLine($"NRZ: {nrz}");
        Console.WriteLine($"NRZI: {nrzi}");
        Console.WriteLine($"AMI: {ami}");
        Console.WriteLine($"Manchester: {manchester}");
    }

    static string EncodeNRZ(string binary)
    {
        return binary; // NRZ просто передает битовые значения
    }
    /// <summary>
    /// //
    /// </summary>
    /// <param name="binary"></param>
    /// <returns></returns>
    /// 
    //////////////////////////////////////////////////
    //////////////////////

    static string EncodeNRZI(string binary)
    {
        char previousSignal = '0'; // Начальное состояние (можно считать как '0')
        string result = "";

        foreach (char bit in binary)
        {
            if (bit == '1')
            {
                previousSignal = (previousSignal == '0') ? '1' : '0'; // Инвертируем сигнал
            }
            result += previousSignal;
        }

        return result;
    }

    static string EncodeAMI(string binary)
    {
        char lastSignal = '0'; // Начальное состояние
        string result = "";

        foreach (char bit in binary)
        {
            if (bit == '1')
            {
                lastSignal = (lastSignal == '0') ? '1' : '0'; // Чередуем сигналы
                result += lastSignal;
            }
            else
            {
                result += '0'; // Ноль остается нулем
            }
        }

        return result;
    }

    static string EncodeManchester(string binary)
    {
        string result = "";

        foreach (char bit in binary)
        {
            if (bit == '1')
            {
                result += "10"; // 1 кодируется как 10
            }
            else
            {
                result += "01"; // 0 кодируется как 01
            }
        }

        return result;
    }
}
