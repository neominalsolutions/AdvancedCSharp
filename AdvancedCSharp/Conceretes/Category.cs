using AdvancedCSharp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Conceretes
{
  public class Category:BaseEntity<int>
  {
    public string Name { get; set; }

    public int Limit { get; set; }

  }
}
