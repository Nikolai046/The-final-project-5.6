using System;
using System.Diagnostics.Metrics;
using System.Net.WebSockets;
using System.Xml.Linq;

class Programm
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Введите своё имя:");
       // var name = InputName();
        Console.Clear();
        Console.WriteLine("Введите фамилию:");
       // var surname = InputName();
        Console.Clear();
        Console.WriteLine("Введите ваш возраст:");
        //var age = InputNum(7,125);
        //var agename = AgeName(age);
        Console.Clear();
        // Console.WriteLine($"Вас зовут: {name} {surname}");
        //Console.WriteLine($"Вам: {age} {agename}");
        Console.WriteLine("У вас есть питомец (д/н)?\n");
        //var jkk = pets[0]; 
        string[] pets = Pet(out _);
        Console.Clear();
        if (pets.Length == 0) Console.WriteLine("У вас нет питомцев");
        foreach (var p in pets) {Console.WriteLine(p + " ");}

    }
    static string InputName()
    {
        char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        string name = Console.ReadLine();
        bool found = false;

        // Проверка на пустое поле
        if (name.Length == 0) { Console.WriteLine("Введенное поле не может быть путым"); return InputName(); }
        //-----------------------------------------------------------------------------------------------------
        // Проверяем, что введенные данные содержит только русские буквы
        for (var i = 0; i < name.Length; i++)
        {   found = false;
            for (var j = 0; j < alphabet.Length; j++)
            { if (Convert.ToChar(name[i]) == alphabet[j]) { found = true; break; } }
            if (!found) { Console.WriteLine("Допускается ввод только русских букв"); return InputName(); }
        }
        //--------------------------------------------------------------------------------------------------
        // Проверяем, что первая буква должна быть заглавная
        found = false;
        for (var i = 0; i < 32; i++)
        {
            if (Convert.ToChar(name[0]) == alphabet[i])
            {
                found = true;
                break;
            }
        }
           if (!found) { Console.WriteLine("Первая буква должна быть заглавная"); return InputName(); }
        //----------------------------------------------------------------------------------------------
        // Проверяем, что все буквы кроме первой строчные
        for (var i=1; i < name.Length; i++)
        {
            found = false;
            for (var j = 32; j < alphabet.Length; j++)
            {
                if (Convert.ToChar(name[i]) == alphabet[j])
                {
                    found = true;
                    break;
                }
            }
            if (!found) { Console.WriteLine("Заглавная буква может быть только в начале"); return InputName(); }
        }
        //-----------------------------------------------------------------------------------------------------
        //Проверяем, что больше 2х букв
        if (name.Length < 2) { Console.WriteLine("Должно быть более 1й буквы"); return InputName(); }
        //       
            return name;
    }
    static byte InputNum(byte nmin, byte nmax)
    {
        char[] numarray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string input = Console.ReadLine();
        if (input.Length == 0) { Console.WriteLine("Введенное поле не может быть путым"); return InputNum(nmin, nmax); }
        foreach (var ch in input)
        {
            if (!numarray.Contains(Convert.ToChar(ch))) { Console.WriteLine("Допускается ввод только цифр"); return InputNum(nmin, nmax); }
        }
            byte numresult = Convert.ToByte(input);
            if (numresult < nmin || numresult > nmax) { Console.WriteLine($"Вводимое значение дольно быть от {nmin} до {nmax}"); return InputNum(nmin, nmax); }
            return numresult;
    }
    static string AgeName (byte age)
    {
        if (age % 10 == 1 && age % 100 != 11) {return "год";}
        else if ((age % 10 >= 2 && age % 10 <= 4) && !(age % 100 >= 12 && age % 100 <= 14)) {return "года";}
        else {return "лет";}
    }
    static string[] Pet(out string[] pets)
    {
        bool pet_en = false;
        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;
        while (true)
        {
            var key = Console.ReadKey();
            Console.SetCursorPosition(cursorLeft, cursorTop);
            if (char.ToLower(key.KeyChar) == 'д') {pet_en = true; break; }
            if (char.ToLower(key.KeyChar) == 'н') {pet_en = false; break; }
        }
        Console.Clear();
        pets = InputPet(pet_en);
        return pets;
    }
    static string[] InputPet(bool pet_en)
    {
        byte petnum = 0;
        if (pet_en == true)
        {
            Console.WriteLine("Сколько у вас питомцев?");
            petnum = InputNum(1, 7);
            Console.WriteLine($"У вас {petnum} питомцев");
        }
        string[] pets = new string[petnum];
        for (int i = 0; i < petnum; i++)
        {
            Console.WriteLine("Введите имя питомца №" + (i+1));
            pets[i] = InputName();
        }
        return pets;
    }

    //static void InputColors(string[] args)
    //{

    //}
    //static Color CheckColor(Color col)
    //{

    //}
}
