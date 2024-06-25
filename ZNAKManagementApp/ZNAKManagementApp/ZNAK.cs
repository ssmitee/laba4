using System;

public class ZNAK : ICloneable, IComparable<ZNAK>
{
    // Поля класса ZNAK
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string ZodiacSign { get; set; }
    public int[] BirthDate { get; set; } // Массив из трех чисел: день, месяц, год
    public object IdentificationNumber { get; set; } // Обобщенное поле для идентификационного номера

    // Конструктор класса
    public ZNAK(string lastName, string firstName, string zodiacSign, int[] birthDate, object idNumber)
    {
        LastName = lastName;
        FirstName = firstName;
        ZodiacSign = zodiacSign;
        BirthDate = birthDate;
        IdentificationNumber = idNumber;
    }

    // Методы интерфейса ICloneable для клонирования объекта
    public object Clone()
    {
        return new ZNAK(LastName, FirstName, ZodiacSign, (int[])BirthDate.Clone(), IdentificationNumber);
    }

    // Методы интерфейса IComparable для сравнения объектов по знаку Зодиака
    public int CompareTo(ZNAK other)
    {
        return string.Compare(this.ZodiacSign, other.ZodiacSign);
    }

    // Переопределение метода ToString для удобного вывода информации
    public override string ToString()
    {
        return $"{LastName} {FirstName}, знак Зодиака: {ZodiacSign}, дата рождения: {BirthDate[0]}.{BirthDate[1]}.{BirthDate[2]}, ID: {IdentificationNumber}";
    }
}
