using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Contracts
{
  // Generic ifadeler Farklı tipller ile çalışmamızı sağlayan yapılar
  // entity kayıt altına alınacak olan nesneler.
  // Abstraction => soyutlama işin detayın girmedik işin özetini çıkardık.
  public interface IRepository<Tentity,Tkey> 
    where Tentity:BaseEntity<Tkey> // entity olabilmesi için BaseEntity den türemelidir. code defencing yapısı
    where Tkey:IComparable<Tkey> // int,string,double, bool (value types)
  {
    void Create(Tentity entity);
    void Update(Tentity entity);
    void Delete(Tkey id);

    List<Tentity> ToList();

    Tentity FindById(Tkey id);

    List<Tentity> Where(Func<Tentity, bool> lamda); // x=> x.Id=1

  }
}
