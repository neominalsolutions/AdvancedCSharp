using AdvancedCSharp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Conceretes
{
  // Kalıtım ile Product Entity ortak olan Id özelliği kazandırdık.
  public class Product:BaseEntity<string>
  {

    public Product() // init constructor düzeyinde set etme işlemini gerçekştirmiş olduk.
    {
      Id = Guid.NewGuid().ToString();
    }

    public decimal Price { get; set; }
    public short Stock { get; set; }


    //public void SetId()
    //{
    //  Id = Guid.NewGuid().ToString();
    //}
  }
}
