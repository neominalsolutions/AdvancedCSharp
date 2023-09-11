using AdvancedCSharp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharp.Conceretes
{
  public class CategoryRepository:BaseRepository<Category,int>
  {

    public override void Delete(int id)
    {
      base.Delete(id);
    }
  }
}
