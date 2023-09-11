// See https://aka.ms/new-console-template for more information
using AdvancedCSharp.Conceretes;
using System.Diagnostics;

Console.WriteLine("Hello, World!");


//public class Program
//{
//  public static void Main(string args[])
//  {

//  }
//} 

// OOP Temel Prensipler
// Encapsulation, (Nesne içerisindeki davranışların gizlenmesi)
// Inheritance, (Bir sınıfın ortak özelliklerinin bu sınıftan kalıtım alan sınıflara aktarımı)
// Polymorphism, (Bir işin farklı şekilde yapılabilmesini sağlayan bir yapı, çok  biçimlilik)
// Abstraction (özetleme, soyut), işi detaylandırmadan işin özetini çıkarma işlemi. 


// Repository Design Pattern => 
// Bir veri kaynağı ile belirli standartlar dahilince çalışma imkanı sağlıyor. Msql, Mysql, PostrgreSql, (Database Provider)
// Create,Update,Delete,List


// DI Yani Dependecy Injection Pattern
// Dependecy Injection (Bağlılılıkların Enjekte edilmesini sağlayan bir tasarım deseni)
// IoC => Inversion Of Control, (Kontrollerin ters çevrilmesi, kontrollerin bağımsız bir şekilde yönetimi.)
// IoC Container => Uygulamadaki nesnelerin IoC davranışı gösterebilmesi için IoC Container içerisinde nesnleri tanımlamamız gerekiyor.

var p = new Product(); // instance alma, ramde heap bölgesinde nesnein bir referansını tutuyor.  
// Product için p obje'nin özelliklerini tutabilmek için bir şablon, blueprint.
// Product bizim için bir kek kalıbı
// p ise Product kek kalıbı ile yapılan bir top kek.
p.Price = 10;
p.Stock = 25;
//p.Id = "234234234";

var productRepository = new ProductRepository();
productRepository.Create(p);
//Product pEntity = productRepository.FindById(p.Id);

//p.Price = 15;
//p.Stock = 55;


//productRepository.Update(p);
//productRepository.Delete(p.Id);


//List<Product> plist = productRepository.ToList();
//List<Product> plistWhere = productRepository.Where(x => x.Stock > 10);

// Kod standartı aynı kalsın diye yaptık

//var category = new Category();
//category.Name = "Kategori-1";

//var categoryRepository = new CategoryRepository();
//categoryRepository.Create(category);


// List<T> şeklinde kullan, tip tanımlı listeleme yapmamıza imkan sağlayan, en yaygın kullandığımız bir kolleksiyon tipi. GenericList

//Category[] clist = new Category[5]; // 0,1,2,3,4
//clist[0] = new Category();
//clist[5] = new Category();

//Array.Resize(ref clist, 10);
//Array.Sort(clist);

//List<Category> clist = new List<Category>(); // category tipinde bir liste
//clist.Insert(2, new Category());
//clist.RemoveAt(0);
//clist.RemoveAll(x => x.Name.Contains("a"));
//clist.Count();
//clist.Clear();
//clist.Where(x => x.Id == 1).ToList();

// Kategori Repository Lamda Expression işlemler


var c1 = new Category { Id = 1, Name = "Elektronik Eşya", Limit = 10 }; // bu yazım şeklide değerler init aşamasında gönderilir. burada init değerleri set edebiliyoruz.
var c2 = new Category { Id = 2, Name = "Ev Eşyası", Limit = 10 };

var c3 = new Category { Id = 3, Name = "Temizlik Malzemesi", Limit = 30 };
//var c2 = new Category(); // bu kod bloğunda init oldu bu sebeple id init yazıldığı için set edilemedi.
//c2.Id = 2;
//c2.Name = "Kategori2";


var cRepo = new CategoryRepository();
cRepo.Create(c1);
cRepo.Create(c2);
cRepo.Create(c3);

var items = cRepo.Items;
var items2 = cRepo.ToList();


// Lamda expression ifadeler ile çalışma

var f1 = cRepo.Where(x => x.Id == 1).ToList(); // her zaman dizi döndürür
var f2 = cRepo.Where(x => x.Name.StartsWith("E"));
var f3 = cRepo.Where(x => x.Name.EndsWith("S"));
var f4 = cRepo.Where(x => x.Name.Contains("a"));
var f5 = cRepo.Where(x => x.Limit > 5 && x.Limit <= 15); // 5 dahil değil 15 dahil.
// Not orderby işlemlerinden sonra ToList ile sırlamanın generic listeye alınmasını sağlayalım. Normalde OrderBy ve  OrderByDescending IOrderedEnumarable döndürür.
var s1 = cRepo.Items.OrderBy(x => x.Limit).ToList(); // itemları Limit ifadesine göre Ascending
var s2 = cRepo.Items.OrderByDescending(x => x.Id).ToList(); // Id descending
var g1 = cRepo.Items.GroupBy(x => x.Limit).Select(a => new
{
    Key = a.Key,
    Count = a.Count(),
}).ToList(); // grouplama sonrasında grupolanmış result set listeye yansıt
var a1 = cRepo.Items.Max(x => x.Limit); // Limiti maksimum olanı bul
var a2 = cRepo.Items.Sum(x => x.Limit); // Tüm Category limit toplamlarını al
var a3 = cRepo.Items.Average(x => x.Limit); // Ortalama Limit
var a4 = cRepo.Items.Count(x => x.Name.Contains("a")); // içinde a geçenlerin sayısını ver
var a5 = cRepo.Items.Contains(c1); // c1 nesnesi var mı

// sayfalama 
// 2 kayıt atlat 2 kayıt al (2 ile 4 arasındaki kaydı)
int page = 0;
var k = cRepo.Items.OrderBy(x => x.Limit).Skip(2 * page).Take(2).ToList(); // 50 kayıt için 2 lik kümelerden 25 sayfa oluşacak.

int limit =  cRepo.Items[0].Limit; // Generic List yapılarında da indeks mekanizması var.

cRepo.Delete(cRepo.Items.FirstOrDefault(x => x.Limit == 30).Id);

cRepo.ToList().Clear(); 




