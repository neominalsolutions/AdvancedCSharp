using AdvancedCSharp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Conceretes
{
  // Base sınıftan kalıtım alarak ilgili özellleri bu sınıfta kod yazmadan erişmiş olduk
  public class ProductRepository:BaseRepository<Product,string>
  {

    public ProductRepository()
    {
      /*
      Create(new Product()); // ürün oluştur
      Update(new Product()); // ürün güncelle
      Delete("1");
      ToList(); // tüm ürünler listesi
      Where(x => x.Price > 10); // P 10 dan büyük olan ürünler listesi
      FindById("1"); // Tek instance
      */
    }

    /// <summary>
    /// Polymorphism 
    /// Delete Method, Create Methoduna ait özellikler Base Repository sınıfı içerisinde yazılıp, Base Reposity sınıfına encapsulate edilmiştir. ProductRepository gibi sınıflar bu methodları içlerinde nasıl bir algoritma çalıştığını bilmeden kullanır. ve ilgili db operasyonlarını yönetir.
    /// </summary>
    /// <param name="id"></param>,
   
    public override void Delete(string id)
    {
      Console.WriteLine("Product Entity Delete Log Start");

       base.Delete(id); // ana delete işlemini yapıcak ama delete işlemi öncesinde mail atabiliriz, loglama yapabiliriz. ovveride ederek işin yapılış şeklinde eklemeler yaptık

      Console.WriteLine("Product Entity Delete Log End");
    }
  }
}
