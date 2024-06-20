using System;
class Programm
{
    static void Main(string[] args)
    {
        byte nmin, nmax;    // объявление переменных минимального и максимального числа для метода проверки чисел

        (string name, string lastname, byte age, string agename, string[] pets, string[] favcolors) Anketa;
        Console.WriteLine("Введите своё имя:");
        Anketa.name = InputName(true, true, true, true, true);
        Console.Clear();

        Console.WriteLine("Введите фамилию:");
        Anketa.lastname = InputName(true, true, true, true, true);
        Console.Clear();

        Console.WriteLine("Введите ваш возраст:");
        nmin = 7; nmax = 125;   // допускается ввод возраста от 7 до 125 лет 
        Anketa.age = InputNum(nmin, nmax);
        Anketa.agename = AgeName(Anketa.age);
        Console.Clear();

        Console.WriteLine("У вас есть питомец (д/н)?\n");
        nmin = 1; nmax = 7;   // допускается ввод количества питомцев от 1 до 7
        Anketa.pets = HaveAItem(out _, 1, nmin, nmax);  // 1 - если питомец, 2 - если цвет
        Console.Clear();

        Console.WriteLine("У вас есть любимые цвета (д/н)?\n");
        nmin = 1; nmax = 4;   // допускается ввод количества питомцев от 1 до 4
        Anketa.favcolors = HaveAItem(out _, 2, nmin, nmax); // 1 - если питомец, 2 - если цвет
        Console.Clear();

        Display(Anketa);

    }
    static string InputName(bool a, bool b, bool c, bool d, bool e)
    {
        char[] alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        string name = Console.ReadLine();
        bool found = false;

        // Проверка на пустое поле
        if (name.Length == 0 && a == true) { Console.WriteLine("Введенное поле не может быть пустым"); return InputName(a, b, c, d, e); }
        //-----------------------------------------------------------------------------------------------------
        // Проверяем, что введенные данные содержит только русские буквы
        for (var i = 0; i < name.Length; i++)
        {
            if (b == false) break;
            found = false;
            for (var j = 0; j < alphabet.Length; j++)
            { if (Convert.ToChar(name[i]) == alphabet[j]) { found = true; break; } }
            if (!found) { Console.WriteLine("Допускается ввод только русских букв"); return InputName(a, b, c, d, e); }
        }
        //--------------------------------------------------------------------------------------------------
        // Проверяем, что первая буква должна быть заглавная
        found = false;
        for (var i = 0; i < 32; i++)
        {
            if (c == false) break;
            if (Convert.ToChar(name[0]) == alphabet[i])
            {
                found = true;
                break;
            }
        }
        if (!found) { Console.WriteLine("Первая буква должна быть заглавная"); return InputName(a, b, c, d, e); }
        //----------------------------------------------------------------------------------------------
        // Проверяем, что все буквы кроме первой строчные
        for (var i = 1; i < name.Length; i++)
        {
            if (d == false) break;
            found = false;
            for (var j = 32; j < alphabet.Length; j++)
            {
                if (Convert.ToChar(name[i]) == alphabet[j])
                {
                    found = true;
                    break;
                }
            }
            if (!found) { Console.WriteLine("Заглавная буква может быть только в начале"); return InputName(a, b, c, d, e); }
        }
        //-----------------------------------------------------------------------------------------------------
        //Проверяем, что больше 2х букв
        if (name.Length < 2 && e == true) { Console.WriteLine("Должно быть более 1й буквы"); return InputName(a, b, c, d, e); }
        //       
        return name;
    }
    static byte InputNum(byte nmin, byte nmax)
    {
        char[] numarray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        string input = Console.ReadLine();
        if (input.Length == 0) { Console.WriteLine("Введенное поле не может быть пустым"); return InputNum(nmin, nmax); }
        foreach (var ch in input)
        {
            if (!numarray.Contains(Convert.ToChar(ch))) { Console.WriteLine("Допускается ввод только цифр"); return InputNum(nmin, nmax); }
        }
        byte numresult = Convert.ToByte(input);
        if (numresult < nmin || numresult > nmax) { Console.WriteLine($"Вводимое значение дольно быть от {nmin} до {nmax}"); return InputNum(nmin, nmax); }
        return numresult;
    }
    static string AgeName(byte age)
    {
        if (age % 10 == 1 && age % 100 != 11) { return "год"; }
        else if ((age % 10 >= 2 && age % 10 <= 4) && !(age % 100 >= 12 && age % 100 <= 14)) { return "года"; }
        else { return "лет"; }
    }
    static string[] HaveAItem(out string[] items, byte itemindex, byte nmin, byte nmax)
    {
        bool item_en = false;
        int cursorLeft = Console.CursorLeft;
        int cursorTop = Console.CursorTop;
        while (true)
        {
            var key = Console.ReadKey();
            Console.SetCursorPosition(cursorLeft, cursorTop);
            if (char.ToLower(key.KeyChar) == 'д') { item_en = true; break; }
            if (char.ToLower(key.KeyChar) == 'н') { item_en = false; break; }
        }
        Console.Clear();
        items = IemCount(item_en, itemindex, nmin, nmax);
        return items;
    }
    static string[] IemCount(bool item_en, byte itemindex, byte nmin, byte nmax)
    {
        byte item_num = 0;
        if (item_en == true)
        {
            Console.WriteLine("Сколько?");
            item_num = InputNum(nmin, nmax);
        }
        if (itemindex == 1) return PetNames(item_num);
        if (itemindex == 2) return ColorName(item_num);
        return new string[0];
    }

    static string[] PetNames(byte petnum)
    {
        Console.Clear();
        string[] pets = new string[petnum];
        for (int i = 0; i < petnum; i++)
        {
            Console.WriteLine("Введите кличку питомца №" + (i + 1));
            pets[i] = InputName(true, true, true, true, true);
        }
        return pets;
    }

    static string[] ColorName(byte colornum)
    {
        Console.Clear();
        string[] colors = new string[colornum];
        for (int i = 0; i < colornum; i++)
        {
            Console.WriteLine("Введите цвет №" + (i + 1));
            string tmpcolor = InputName(true, true, true, true, true);
            if (CheckColors(tmpcolor) == false) i--;
            if (colors.Contains(tmpcolor)) { Console.WriteLine("Такой цвет уже был"); i--; }
            else colors[i] = tmpcolor;
        }
        return colors;
    }

    static bool CheckColors(string tmpcolor)
    {
        string[] colorarry = { "Красный", "Оранжевый", "Желтый", "Зеленый", "Голубой", "Синий", "Фиолетовый", "Розовый", "Коричневый", "Черный", "Белый", "Серый", "Бежевый", "Бирюзовый", "Бордовый", "Лиловый", "Малиновый", "Персиковый", "Салатовый" };
        {
            if (!colorarry.Contains(tmpcolor)) { Console.WriteLine("Такого цвета не существует"); return false; }
        }
        return true;
    }
    static ConsoleColor GetColor(string colorName)
    {
        switch (colorName)
        {
            case "Красный": return ConsoleColor.Red;
            case "Оранжевый": return ConsoleColor.DarkYellow;
            case "Желтый": return ConsoleColor.Yellow;
            case "Зеленый": return ConsoleColor.Green;
            case "Голубой": return ConsoleColor.Cyan;
            case "Синий": return ConsoleColor.Blue;
            case "Фиолетовый": return ConsoleColor.Magenta;
            case "Розовый": return ConsoleColor.Magenta;
            case "Коричневый": return ConsoleColor.DarkRed;
            case "Черный": return ConsoleColor.Black;
            case "Белый": return ConsoleColor.White;
            case "Серый": return ConsoleColor.Gray;
            case "Бежевый": return ConsoleColor.DarkYellow;
            case "Бирюзовый": return ConsoleColor.Cyan;
            case "Бордовый": return ConsoleColor.DarkRed;
            case "Лиловый": return ConsoleColor.Magenta;
            case "Малиновый": return ConsoleColor.DarkMagenta;
            case "Персиковый": return ConsoleColor.DarkYellow;
            case "Салатовый": return ConsoleColor.Green;
            default: return ConsoleColor.White;
        }
    }

    static void Display((string name, string lastname, byte age, string agename, string[] pets, string[] favcolors) Anketa)
    {
        Console.Clear();
        Console.WriteLine("РЕЗУЛЬТАТЫ ОПРОСА");
        Console.WriteLine("~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"Вас зовут: {Anketa.name} {Anketa.lastname}");
        Console.WriteLine($"Вам {Anketa.age} {Anketa.agename}");
        if (Anketa.pets.Length == 0) Console.WriteLine("У вас нет питомцев");
        else Console.WriteLine("Ваши питомцы: " + string.Join(", ", Anketa.pets));
        if (Anketa.favcolors.Length == 0) Console.WriteLine("У вас нет любимых цветов");
        else
        {
            Console.WriteLine("Ваши любимые цвета:");
            foreach (var x in Anketa.favcolors)
            {
                Console.BackgroundColor = GetColor(x);
                Console.Write(" ");
                Console.ResetColor();
                Console.Write(" " + x + " ");
                Console.BackgroundColor = GetColor(x);
                Console.Write(" \n");
                Console.ResetColor();
            }
        }

    }
}

