using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Contracts
{
  public abstract class BaseRepository<Tentity, Tkey> : IRepository<Tentity, Tkey> 
    where Tentity:BaseEntity<Tkey>
    where Tkey:IComparable<Tkey>
  {

    // propery ise public tanımlanır, ilgili nesne dışına çıkar.
    public IReadOnlyList<Tentity> Items => items; // get edilebilir, dışarıdan liste koruma altında set edilemez.

    // field, nesne içerisine gömülü değişkenlerimiz
    private List<Tentity> items = new List<Tentity>();


    // methodlar entityden entitye davranış değişikliği içerebilir diye virtual keyword ile işaretledik.bunları BaseRepository den kalıtım alan sınıflarda ovveride edeceğiz.
    public virtual void Create(Tentity entity)
    {
      // çalışma zamanın aşağıdaki kod ile entity tipi taranır ve taranan bu entity tipi içindeki propertylerde gezinti yapılır her birini değeri alını
      foreach (var propertyInfo in typeof(Tentity).GetProperties())
      { int index = 0;
        Console.WriteLine("property",propertyInfo.GetValue(entity));
        index++;
      }

      // bunlar bütün repositorylerde çalışacak kodlar
      Console.WriteLine($"insert into {typeof(Tentity).Name} values({entity.Id})");

      items.Add(entity);
    }

    public virtual void Delete(Tkey id)
    {
      Console.WriteLine($"delete from {typeof(Tentity).Name} where Id({id})");

       var entity = items.Find(x => x.Id.Equals(id));
      var entityIndex = items.FindIndex(x => x.Id.Equals(id));

      if(entity is null)
      {
        throw new Exception("Id bulunamadı.Silinemez");
      }

      items.Remove(entity);

      // items.RemoveAt(entityIndex);
    }

    public virtual Tentity FindById(Tkey id)
    {
      Console.Write($"select * from {typeof(Tentity).Name} where Id({id})");

      // Reflection ile entity instance aldık.
      // Product p = new Product();

      // kolesiyon içerisinde idsine göre bulma işlemi
      var entity = items.Find(x => x.Id.Equals(id));

      if (entity is null) throw new Exception("Entity bulunamadı");

      return entity;
    }

    public virtual List<Tentity> ToList()
    {

      return items.ToList();
    }

    public virtual void Update(Tentity entity)
    {
      Console.WriteLine($"update set {typeof(Tentity).Name} where Id({entity.Id})");

      // aynı id ait birden fazla kayıt varsa FirstOrDefault ilk bulduğunu döndürür.
      // eğer hiç birşey bulamaz ise null değer döndürür.
      var entityFind = items.FirstOrDefault(x => x.Id.Equals(entity.Id));

    }

    // Func<Entity,bool> InMemory ramdeki listeyi filtrelemeyi temsil eder. IEnumarable,
    // Expression<Entity,bool> Persistance yani veri kaynağındaki filtrelemeyi temsil eder. IQuerable denilen bir query tipi ile çalışır. 
    public virtual List<Tentity> Where(Func<Tentity, bool> lamda)
    {
      
      Console.WriteLine($"select * from {typeof(Tentity).Name} where(?,?,?)");

      return items.Where(lamda).ToList();
    }
  }
}
