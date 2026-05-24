### Dekonstruktor `~Person()`

```csharp
class Person
{
    string name;
    int age;

    // Konstruktor — obyekt yaradılarkən işləyir
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Dekonstruktor — obyekt yaddaşdan silinərkən işləyir
    ~Person()
    {
        Console.WriteLine($"{name} adlı obyekt yaddaşdan silindi.");
    }
}
```

---

### İş prinsipi:
```csharp
static void Main()
{
    var p = new Person("Əli", 25); // Konstruktor işləyir
    Console.WriteLine("Proqram bitir...");

} // Proqram bitəndə Garbage Collector ~Person() çağırır
```

**Çıxış:**
```
Proqram bitir...
Əli adlı obyekt yaddaşdan silindi.
```

---

### Əsas qaydalar:

| | |
|---|---|
| `~` işarəsi | Sinif adının önünə yazılır |
| Parametr yoxdur | Heç nə qəbul etmir |
| Qaytarma tipi yoxdur | `void` də yazılmır |
| Əl ilə çağırılmır | Garbage Collector özü çağırır |
| Nə vaxt işləyir | Obyekt yaddaşdan silinərkən |

---

### Sənin kodunda istifadəsi:
```csharp
class Person
{
    string name;
    int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Deconstruct(out string personName, out int personAge)
    {
        personName = name;
        personAge = age;
    }

    ~Person() // Dekonstruktor
    {
        Console.WriteLine($"{name} adlı obyekt yaddaşdan silindi.");
    }
}
```

---

### Üç fərqli şey:

| | Konstruktor | Deconstruct | Dekonstruktor |
|---|---|---|---|
| **İşarə** | `Person()` | `Deconstruct()` | `~Person()` |
| **Nə edir?** | Obyekt yaradır | Dəyişənlərə parçalayır | Yaddaşı təmizləyir |
| **Nə vaxt?** | `new` ilə | `var (a, b) = p` ilə | Proqram bitəndə |
| **Lazımdırmı?** | Bəzən | Bəzən | Çox nadir |