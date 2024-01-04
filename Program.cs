using CA240104;

//Függvények, Metódusok
static void Beolvasas(List<Terepjaro> lista) 
{
    StreamReader sr = new(@"..\..\..\src\terepjarok.txt");
	while (!sr.EndOfStream)
	{
		lista.Add(new Terepjaro(sr.ReadLine()));
	}
	sr.Close();
}
static List<Terepjaro> Feladat12(List<Terepjaro> lista) 
{
	var legujabbDieselEvjarat = lista
		.Where(a => a.UzemanyagTipus == "Dízel")
		.OrderByDescending(a => a.Evjarat)
		.Select(a => a.Evjarat)
		.First();

	return lista.Where(a => a.UzemanyagTipus == "Hibrid" && a.Evjarat < legujabbDieselEvjarat).ToList();
}
static void Kiiras(List<Terepjaro> lista) 
{
	StreamWriter sw = new(@"..\..\..\src\ujfile.txt");
	for (int i = 0; i < lista.Count; i++) sw.WriteLine($"Márka modell: {lista[i].MarkaModell}, Évjárat: {lista[i].Evjarat}, Tömege: {lista[i].TomegFontba} Font");
	sw.Close();
}

//Main
List<Terepjaro> terepjarok = new();
Beolvasas(terepjarok);

//7.feladat
for (int i = 0; i < 3; i++)
{
	Console.WriteLine(terepjarok[i]);
}

//9.feladat
double ToyotaAtlagTomeg = terepjarok.Where(a => a.MarkaModell.StartsWith("Toyota")).Average(a => a.Tomeg);
Console.WriteLine($"\n9.feladat: Toyota terepjárók átlagos tömege: {ToyotaAtlagTomeg} kg");

//10.feladat
List<Terepjaro> Feladat10 = terepjarok.Where(a => a.Hajtas == "Összkerékhajtás" && a.Evjarat >= 2019).ToList();
Console.WriteLine($"\n10.feladat: {Feladat10.Count} db");

//11.feladat
List<Terepjaro> Feladat11 = terepjarok.Where(a => a.Tomeg == terepjarok.Min(a => a.Tomeg)).ToList();
Console.WriteLine("\n11.feladat: ");
foreach (var item in Feladat11)
{
    Console.WriteLine(item);
}

//12.feladat
List<Terepjaro> Feladat12Lista = Feladat12(terepjarok);
Console.WriteLine("\n12.feladat: ");
try
{
	Console.WriteLine(Feladat12Lista[0]);
}
catch
{
    Console.WriteLine("Nincs ilyen!");
}

//13.feladat
List<Terepjaro> Feladat13 = terepjarok.Where(a => a.Hajtas == "Összkerékhajtás").ToList();
Console.WriteLine("\n13.feladat: ");
foreach (var item in Feladat13)
{
    Console.WriteLine(item);
}

//15.feladat
try
{
	Kiiras(terepjarok);
    Console.WriteLine("15.feladat:\n\tSikeres kiírás!");
}
catch
{
    Console.WriteLine("15.feladat:\n\tHiba a fájlba való kiírás során!");
}