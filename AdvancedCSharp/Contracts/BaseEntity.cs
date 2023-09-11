using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Contracts
{
  // Bir class Entity özelliği gösterebilmesi için Id unique bir key alanı içermelidir.
  // 1 Ali Can 3243242
  // 2 Ali Can 3243244
  public abstract class BaseEntity<TKey> where TKey:IComparable<TKey>
  {
    public TKey Id { get; init; } // Id değeri init ile sadece contructor içinde set edilebilir. Id değeri sınıf dışından yada sınıf içindeki bir method üzerinden set edilmesini kapadık.
  }
}
