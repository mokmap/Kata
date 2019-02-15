using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Interfaces
{
    public interface IItemAction
    {
        void Update(Item item);
        int UpdateState(int sellIn);
        void UpdateQuality(Item item);
        void UpdateSellIn(Item item);
    }
}
