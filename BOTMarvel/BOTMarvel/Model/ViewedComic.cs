using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOTMarvel.Model
{
    public partial class ViewedComic
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? ComicId { get; set; }
    }
}
