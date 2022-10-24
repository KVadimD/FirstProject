/*
Имя;
Фамилия;
Возраст;
Наличие питомца;
Если питомец есть, то запросить количество питомцев;
Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
Запросить количество любимых цветов;
Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
Корректный ввод: ввод числа типа int больше 0.
*/

static (
    string FirstName, 
    string LastName,
    byte Age,
    bool HasPet,
    byte PetQuantity,
    string[] Pets,
    byte ColorQuantity,
    string[] Colors
) GetMainInfo()
{
    (
        string FirstName,
        string LastName,
        byte Age,
        bool HasPet,
        byte PetQuantity,
        string[] Pets,
        byte ColorQuantity,
        string[] Colors
    ) User;
    User.FirstName = GetCorrectedString("Введите ваше имя:");
    User.LastName = GetCorrectedString("Введите вашу фамилию:");
    User.Age = GetCorrectedPositiveNumber("Введите ваш возраст в годах:");
    User.HasPet = GetHasPet();
    User.PetQuantity = User.HasPet
        ? GetCorrectedPositiveNumber("Введите количество питомцев:")
        : (byte)0;
    User.Pets = new string[User.PetQuantity];
    for (byte i = 0; i < User.Pets.Length; i++)
    {
        User.Pets[i] = GetCorrectedString(
            string.Format("Введите имя питомца №{0}", i + 1)
        );
    }
    User.ColorQuantity = GetCorrectedPositiveNumber("Введите количество любимых цветов:");
    User.Colors = new string[User.ColorQuantity];
    for (byte i = 0; i < User.Colors.Length; i++)
    {
        User.Colors[i] = GetCorrectedString(
            string.Format("Введите название цвета №{0}", i + 1)
        );
    }
    return User;
}

static bool GetHasPet()
{
    Console.WriteLine("Есть ли у вас питомец? (Да/Нет):");
    var text = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(text))
    {
        Console.WriteLine("Значение не может быть пустым.");
        return GetHasPet();
    }

    if (text.ToLower() == "да")
    {
        return true;
    }
    if (text.ToLower() == "нет")
    {
        return false;
    }
    Console.WriteLine("Введите \"Да\" или \"Нет\".");
    return GetHasPet();
}
static string GetCorrectedString(string text)
{
    Console.WriteLine(text);
    var result = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(result))
    {
        Console.WriteLine("Строка не может быть пустой.");
        return GetCorrectedString(text);
    }
    return result;
}
static byte GetCorrectedPositiveNumber(string text)
{
    Console.WriteLine(text);
    var input = Console.ReadLine();
    byte result;
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Значение не может быть пустым.");
        return GetCorrectedPositiveNumber(text);
    }
    var IsParsed = byte.TryParse(input, out result);   
    if (!IsParsed)
    {
        Console.WriteLine("Значение не может быть пустым, меньше нуля и больше 255.");
        return GetCorrectedPositiveNumber(text);
    }
    return result;
}
(
    string FirstName,
    string LastName,
    byte Age,
    bool HasPet,
    byte PetQuantity,
    string[] Pets,
    byte ColorQuantity,
    string[] Colors
) = GetMainInfo();
Console.WriteLine("------------------------");
Console.WriteLine("Ваше имя: {0};", FirstName);
Console.WriteLine("Ваша фамилия: {0};", LastName);
Console.WriteLine("Ваш возраст: {0};", Age);
Console.WriteLine("Есть ли у вас питомец: {0};", HasPet ? "Да" : "Нет");
Console.WriteLine("Количество питомцев: {0};", PetQuantity);
for(byte i = 0; i < Pets.Length; i++)
{
    Console.WriteLine("Имя питомца №{0}: {1}", i + 1, Pets[i]);
}
Console.WriteLine("Количество ваших любимых цветов: {0};", ColorQuantity);
for (byte i = 0; i < Colors.Length; i++)
{
    Console.WriteLine("Цвет №{0}: {1}", i + 1, Colors[i]);
}
