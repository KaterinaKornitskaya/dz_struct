
using System.Reflection.Metadata.Ecma335;

namespace _RGB_color;

// Задание 3
// Создайте структуру «RGB цвет».
// Определите внутри неё необходимые поля и методы.
// Реализуйте следующую функциональность:
// ■ Перевод в HEX формат;
// ■ Перевод в HSL;
// ■ Перевод в CMYK
internal class Program
{
    static void Main(string[] args)
    {
        RGBColor rGB = new RGBColor(0, 0, 255);
        Console.WriteLine($"HEX format: {rGB.ToHEX()}");
        Console.WriteLine($"HSL format: {rGB.ToHSL()}");
        Console.WriteLine($"CMYK format: {rGB.ToCMYK()}");
    }
}

struct RGBColor
{
    int R;
    int G;
    int B;

    public RGBColor(int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    public string ToHEX()
    {
        string hex_r = R.ToString("X2");
        string hex_g = G.ToString("X2");
        string hex_b = B.ToString("X2");
        return $"{hex_r}{hex_g}{hex_b}";
    }

    public string ToHSL()
    {
       
        // Значения R,G,B делятся на 255, чтобы изменить диапазон от 0..255 до 0..1:
        float r = R/255;
        float g = G/255;
        float b = B/255;

        // поиск максимального и минимального
        float max = Math.Max(r, Math.Max(g, b));
        float min = Math.Min(r, Math.Min(g, b));

        // разница между макс и мин
        float delta = max - min;

        // Расчет легкости:
        float lightness = (max+min) /2;

        // Если цвет оттенковый, то насыщенность равна 0
        if (delta == 0f)
        {
            return $"HSL(0, 0%, {(int)(lightness * 100)}%)";
        }

        // Вычисляем насыщенность
        float saturation = delta / (lightness < 0.5f ? (2f * lightness) : (2f - 2f * lightness));

        // Вычисляем оттенок
        float hue = 0f;
        if (r == max)
        {
            hue = (g - b) / delta;
        }
        else if (g == max)
        {
            hue = 2f + (b - r) / delta;
        }
        else if (b == max)
        {
            hue = 4f + (r - g) / delta;
        }
        hue *= 60f;
        if (hue < 0f)
        {
            hue += 360f;
        }

        return $"HSL({(int)hue}, {(int)(saturation * 100)}%, {(int)(lightness * 100)}%)";
    }

    public string ToCMYK()
    {
        double r = R / 255.0;
        double g = G / 255.0;
        double b = B / 255.0;

        double k = 1 - Math.Max(r, Math.Max(g, b));
        double c = (1 - r - k) / (1 - k);
        double m = (1 - g - k) / (1 - k);
        double y = (1 - b - k) / (1 - k);

        return $"C: {c * 100:0}%, M: {m * 100:0}%, Y: {y * 100:0}%, K: {k * 100:0}%";
    }
}